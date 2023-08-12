using CasgemMicroservice.Services.Order.Core.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasgemMicroservice.Services.Order.Infra.Persistance.Data.Context;

public class OrderContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=CasgemMicroserviceOrderDb; User=sa; Password=123456Aa*");
    }

    public DbSet<Address>? Addresses { get; set; }
    public DbSet<OrderDetail>? OrderDetails { get; set; }
    public DbSet<Ordering>? Orders { get; set; }
}