using Microsoft.EntityFrameworkCore;
using DineMaster.Models;

namespace DineMaster.Data
{
    public class DineMasterDbContext : DbContext
    {
        public DineMasterDbContext(DbContextOptions<DineMasterDbContext> options) : base(options) { }

        // DbSet declarations
        public DbSet<User> Users { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<ReservationSlot> ReservationSlots { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemIngredient> MenuItemIngredients { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<ShiftMaster> ShiftMasters { get; set; }
        public DbSet<StaffShift> StaffShifts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Restrict delete behavior to prevent cascade delete where it makes sense
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //// Composite key for relationships if needed
            //modelBuilder.Entity<MenuItemIngredient>()
            //    .HasIndex(m => new { m.MenuItemId, m.InventoryItemId })
            //    .IsUnique();

            //modelBuilder.Entity<PurchaseItem>()
            //    .HasIndex(p => new { p.PurchaseId, p.InventoryItemId })
            //    .IsUnique();

            // Reservation: AssignedWaiter and User both relate to User
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.AssignedWaiter)
                .WithMany(u => u.AssignedReservations)
                .HasForeignKey(r => r.AssignedWaiterId)
                .OnDelete(DeleteBehavior.Restrict);

            // Order OrderedBy
            modelBuilder.Entity<Order>()
                .HasOne(o => o.OrderedByUser)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.OrderedBy)
                .OnDelete(DeleteBehavior.Restrict);


            // ShiftDuration is NotMapped so no mapping needed
        }
    }
}
