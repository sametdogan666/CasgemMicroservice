﻿// <auto-generated />
using CasgemMicroservice.Services.Cargo.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CasgemMicroservice.Services.Cargo.DataAccess.Migrations
{
    [DbContext(typeof(CargoContext))]
    [Migration("20230814151705_mig_1")]
    partial class mig_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CasgemMicroservice.Services.Cargo.Entities.Entities.CargoDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CargoStateId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CargoStateId");

                    b.ToTable("CargoDetails");
                });

            modelBuilder.Entity("CasgemMicroservice.Services.Cargo.Entities.Entities.CargoState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CargoStates");
                });

            modelBuilder.Entity("CasgemMicroservice.Services.Cargo.Entities.Entities.CargoDetail", b =>
                {
                    b.HasOne("CasgemMicroservice.Services.Cargo.Entities.Entities.CargoState", "CargoState")
                        .WithMany("CargoDetails")
                        .HasForeignKey("CargoStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CargoState");
                });

            modelBuilder.Entity("CasgemMicroservice.Services.Cargo.Entities.Entities.CargoState", b =>
                {
                    b.Navigation("CargoDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
