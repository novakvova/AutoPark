﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAutoPark.Data;

#nullable disable

namespace WebAutoPark.Migrations
{
    [DbContext(typeof(AppAutoParkContext))]
    [Migration("20250409145559_AddtblAssignments")]
    partial class AddtblAssignments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("WebAutoPark.Data.Entities.AssignmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AssignedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("RouteId");

                    b.HasIndex("VehicleId");

                    b.ToTable("tblAssignments");
                });

            modelBuilder.Entity("WebAutoPark.Data.Entities.CompanyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("tblCompanies");
                });

            modelBuilder.Entity("WebAutoPark.Data.Entities.DriverEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LicenseExpiryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("tblDrivers");
                });

            modelBuilder.Entity("WebAutoPark.Data.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("tblRoles");
                });

            modelBuilder.Entity("WebAutoPark.Data.Entities.RouteEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("DistanceKm")
                        .HasMaxLength(255)
                        .HasColumnType("double");

                    b.Property<string>("EndLocation")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("StartLocation")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("tblRoutes");
                });

            modelBuilder.Entity("WebAutoPark.Data.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("tblUsers");
                });

            modelBuilder.Entity("WebAutoPark.Data.Entities.VehicleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("StatusId");

                    b.ToTable("tblVehicles");
                });

            modelBuilder.Entity("WebAutoPark.Data.Entities.VehicleStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.ToTable("tblVehicleStatuses");
                });

            modelBuilder.Entity("WebAutoPark.Data.Entities.AssignmentEntity", b =>
                {
                    b.HasOne("WebAutoPark.Data.Entities.DriverEntity", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAutoPark.Data.Entities.RouteEntity", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAutoPark.Data.Entities.VehicleEntity", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Route");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("WebAutoPark.Data.Entities.DriverEntity", b =>
                {
                    b.HasOne("WebAutoPark.Data.Entities.CompanyEntity", "Company")
                        .WithMany("Drivers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("WebAutoPark.Data.Entities.UserEntity", b =>
                {
                    b.HasOne("WebAutoPark.Data.Entities.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebAutoPark.Data.Entities.VehicleEntity", b =>
                {
                    b.HasOne("WebAutoPark.Data.Entities.CompanyEntity", "Company")
                        .WithMany("Vehicles")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAutoPark.Data.Entities.VehicleStatusEntity", "Status")
                        .WithMany("Vehicles")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("WebAutoPark.Data.Entities.CompanyEntity", b =>
                {
                    b.Navigation("Drivers");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("WebAutoPark.Data.Entities.VehicleStatusEntity", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
