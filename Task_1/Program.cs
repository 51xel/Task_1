using Microsoft.EntityFrameworkCore;
using Task_1.Data;
using Task_1.Repositories;
using Task_1.Repositories.IRepositories;
using Task_1.Services;
using Task_1.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version())
    );
});

builder.Services.AddTransient<IExperimentService, ExperimentService>();
builder.Services.AddTransient<IExperimentRepository, ExperimentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
