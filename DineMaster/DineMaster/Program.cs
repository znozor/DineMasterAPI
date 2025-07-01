using DineMaster.Data;
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

builder.Services.AddScoped<ITableRepo, TableService>();
builder.Services.AddScoped<IReservationRepo, ReservationService>(); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
