using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task InitAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while initialising the database");
            throw;
        }
    }
    
    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task TrySeedAsync()
    {
        if (!_context.Cities.Any())
        {
            _context.Cities.Add(new City
            {
                Id = 1,
                Name = "Khujand"
            });

            await _context.SaveChangesAsync();
        }
        
        if (!_context.Orders.Any())
        {
            _context.Orders.Add(new Order
            {
                SenderCityId = 1,
                SenderAddress = "Gagarin st. 1234",
                ReceiverCityId = 1,
                ReceiverAddress = "Tursunzode st 234",
                CargoWeight = 2.35,
                PickupDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(2))
            });

            await _context.SaveChangesAsync();
        }
    }
}