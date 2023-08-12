﻿using System.Data;
using CasgemMicroservice.Services.Discount.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CasgemMicroservice.Services.Discount.Context;

public class DapperContext : DbContext
{
   
    //private readonly IConfiguration _configuration;
    //private readonly string _connectionString;

    //public DapperContext(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //    _connectionString = _configuration.GetConnectionString("DefaultConnection");
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=CasgemMicroserviceDiscountDb; User=sa; Password=123456Aa*");
    }

    public DbSet<DiscountCoupons>? DiscountCouponses { get; set; }

    //public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

}