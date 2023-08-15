using CasgemMicroservice.Services.Cargo.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasgemMicroservice.Services.Cargo.DataAccess.Concrete;

public class CargoContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=CasgemMicroserviceCargoDb; User=sa; Password=123456Aa*");
    }

    public DbSet<CargoDetail>? CargoDetails { get; set; }
    public DbSet<CargoState>? CargoStates { get; set; }
    
}