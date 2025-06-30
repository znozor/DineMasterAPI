using DineMaster.Data;
using DineMaster.DTO;
using DineMaster.Enum;
using DineMaster.Models;
using DineMaster.Repository;
using Microsoft.EntityFrameworkCore;

namespace DineMaster.Service
{
    public class ReservationService : IReservationRepo
    {
        DineMasterDbContext _db;
        public ReservationService(DineMasterDbContext db)
        {
            this._db = db;
        }

        public async Task<CustomerReservationDTO> AddReservation(CustomerReservationDTO dto)
        {
            //var res = new Reservation()
            //{
            //    CustomerName = dto.CustomerName,
            //    Contact = dto.Contact,
            //    GuestCount = dto.GuestCount,
            //    StartTime = dto.StartTime,
            //    EndTime = dto.EndTime,
            //    TableId = dto.TableId,
            //    ReservationDate = dto.ReservationDate,
            //    Status = dto.Status,
            //    UserId = dto.UserId
            //};

            //_db.Reservations.Add(res);
            //await _db.SaveChangesAsync();

            //return dto;




            bool userreserve = await _db.Reservations.AnyAsync(r =>
            r.TableId == dto.TableId &&
            r.ReservationDate.Date == dto.ReservationDate.Date &&
            (
                (dto.StartTime >= r.StartTime && dto.StartTime < r.EndTime) ||  
                (dto.EndTime > r.StartTime && dto.EndTime <= r.EndTime) ||       
                (dto.StartTime <= r.StartTime && dto.EndTime >= r.EndTime)       
            )
        );

            if (userreserve)
            {
                throw new InvalidOperationException("The table is already booked for the selected date and time.");
            }

            var reservation = new Reservation
            {

                //in this the customer name and all will come from session
                CustomerName = dto.CustomerName,
                Contact = dto.Contact,
                GuestCount = dto.GuestCount,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                ReservationDate = dto.ReservationDate,
                TableId = dto.TableId,
                Status = dto.Status,
                UserId = dto.UserId
            };

            _db.Reservations.Add(reservation);
            await _db.SaveChangesAsync();

            return dto;




        }

        public async Task<CustomerReservationDTO> AdminReservation(CustomerReservationDTO dto)
        {
            bool adminreserve = await _db.Reservations.AnyAsync(r =>
            r.TableId == dto.TableId &&
            r.ReservationDate.Date == dto.ReservationDate.Date &&
            (
                (dto.StartTime >= r.StartTime && dto.StartTime < r.EndTime) ||
                (dto.EndTime > r.StartTime && dto.EndTime <= r.EndTime) ||       
                (dto.StartTime <= r.StartTime && dto.EndTime >= r.EndTime)      
            )
        );

            if (adminreserve)
            {
                throw new InvalidOperationException("The table is already booked for the selected date and time.");
            }

            var reservation = new Reservation
            {
                //in this the admin can add reservation by adding the customer details
                CustomerName = dto.CustomerName,
                Contact = dto.Contact,
                GuestCount = dto.GuestCount,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                ReservationDate = dto.ReservationDate,
                TableId = dto.TableId,
                Status = dto.Status,
                UserId = dto.UserId
            };

            _db.Reservations.Add(reservation);
            await _db.SaveChangesAsync();

            return dto;

        }


        //public async Task AdminReservation(AdminReservationDTO dto)
        //{
        //    var reservation = await _db.Reservations.FindAsync(dto.ReservationId);
        //    if (reservation == null)
        //    {
        //        throw new Exception("Reservation not found.");
        //    }

        //    // Update status
        //    reservation.Status = dto.Status;

        //    // Update assigned waiter only if provided
        //    if (dto.AssignedWaiterId.HasValue)
        //    {
        //        var waiter = await _db.Users.FindAsync(dto.AssignedWaiterId.Value);
        //        if (waiter == null)
        //        {
        //            throw new Exception("Assigned waiter not found.");
        //        }

        //        reservation.AssignedWaiterId = dto.AssignedWaiterId;
        //    }
        //    else
        //    {
        //        reservation.AssignedWaiterId = null;
        //    }

        //    await _db.SaveChangesAsync();
        //}

        public async Task<ReservationDetailsDTO> ReservationDetails(int id)
        {
            var reservation = await _db.Reservations
                .Include(r => r.Table)
                .Include(r => r.User)
                .Include(r => r.AssignedWaiter)
                .FirstOrDefaultAsync(r => r.ReservationId == id);

            if (reservation == null)
                throw new Exception("Reservation not found.");

            return new ReservationDetailsDTO
            {
                ReservationId = reservation.ReservationId,
                CustomerName = reservation.CustomerName,
                Contact = reservation.Contact,
                GuestCount = reservation.GuestCount,
                StartTime = reservation.StartTime,
                EndTime = reservation.EndTime,
                ReservationDate = reservation.ReservationDate,
                Status = reservation.Status,
                TableId = reservation.TableId,
                TableName = reservation.Table.TableName,

                UserId = reservation.UserId,
                UserName = reservation.User?.Username,

                AssignedWaiterId = reservation.AssignedWaiterId,
                WaiterName = reservation.AssignedWaiter?.Username
            };
        }


        public async Task<IEnumerable<ReservationDetailsDTO>> GetReservations()
        {


            
                return await _db.Reservations
                    .Include(r => r.Table)
                    .Include(r => r.User)
                    .Include(r => r.AssignedWaiter)
                    .Select(r => new ReservationDetailsDTO
                    {
                        ReservationId = r.ReservationId,
                        CustomerName = r.CustomerName,
                        Contact = r.Contact,
                        GuestCount = r.GuestCount,
                        StartTime = r.StartTime,
                        EndTime = r.EndTime,
                        ReservationDate = r.ReservationDate,
                        Status = r.Status,
                        TableId = r.TableId,
                        TableName = r.Table.TableName,
                        UserId = r.UserId,
                        UserName = r.User != null ? r.User.Username : null,
                        AssignedWaiterId = r.AssignedWaiterId,
                        WaiterName = r.AssignedWaiter != null ? r.AssignedWaiter.Username : null
                    })
                    .ToListAsync();
            



        }


        public async Task CancelReservation(ReservationCancelDTO dto)
        {
            var reservation = await _db.Reservations.FindAsync(dto.ReservationId);

            if (reservation == null)
                throw new Exception("Reservation not found");

            if (reservation.UserId != dto.UserId)
                throw new Exception("Unauthorized cancel attempt");

            reservation.Status = ReservationStatus.Cancelled;

            await _db.SaveChangesAsync();
        }



        public async Task<List<Reservation>> GetUpcomingReservationsByUser(int id)
        {
            var now = DateTime.Now;


            var allReservations = await _db.Reservations
                .Where(r => r.UserId == id && r.Status != ReservationStatus.Cancelled)
                .ToListAsync(); 

            return allReservations
                .Where(r => r.ReservationDate.Add(r.StartTime) > now)
                .ToList(); 

        }



        public async Task<bool> MarkReservationAsCompleted(int id)
        {
            var reservation = await _db.Reservations.FindAsync(id);
            if (reservation == null)
                return false;

            reservation.Status = ReservationStatus.Completed;
            await _db.SaveChangesAsync();
            return true;
        }

        public async  Task<List<Reservation>> ReservationHistory(int id)
        {
            var now = DateTime.Now;


            var allReservations = await _db.Reservations
                .Where(r => r.UserId == id && r.Status != ReservationStatus.Cancelled)
                .ToListAsync();

            return allReservations
                .Where(r => r.ReservationDate.Add(r.StartTime) < now)
                .ToList();
        }


        public async Task<bool> AdminConfirm(int id)
        {
            var reservation = await _db.Reservations.FindAsync(id);
            if (reservation == null)
                return false;

            reservation.Status = ReservationStatus.Completed;
            await _db.SaveChangesAsync();
            return true;
        }



    }
}

