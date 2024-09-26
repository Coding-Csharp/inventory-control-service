using Microsoft.EntityFrameworkCore;
using InventoryControlService.Shared.Domain.Repositories;
using InventoryControlService.Shared.Infrastructure.Persistence.EFC.Configuration;
using InventoryControlService.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InventoryControlContext>(context =>
{
    context.UseSqlServer(builder.Configuration.GetConnectionString("InventoryControlService"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.UseCors(
    c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();