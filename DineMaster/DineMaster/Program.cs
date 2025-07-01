using DineMaster.Data;
<<<<<<< Updated upstream
=======
using DineMaster.Mapper;
>>>>>>> Stashed changes
using DineMaster.Repository;
using DineMaster.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddDbContext<DineMasterDbContext>
    (
        options => options.UseSqlServer
        (
            builder.Configuration.GetConnectionString("dbconn")
        )
    );

builder.Services.AddScoped<ITableRepo, TableService>();
builder.Services.AddScoped<IReservationRepo, ReservationService>(); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IMenuCategoryRepo, MenuCategoryServices>();
builder.Services.AddScoped<IMenuCategoryRepo, MenuCategoryServices>();
builder.Services.AddScoped<IMenuItemRepo, MenuItemServices>();
builder.Services.AddAutoMapper(typeof(MappingData));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
