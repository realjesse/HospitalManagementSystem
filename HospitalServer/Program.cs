using HospitalServer.Data;
using HospitalServer.Hubs;
using HospitalServer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSignalR();

builder.Services.AddDbContext<HospitalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<InventoryService>();

var app = builder.Build();

app.MapHub<HospitalHub>("/hospitalHub");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
