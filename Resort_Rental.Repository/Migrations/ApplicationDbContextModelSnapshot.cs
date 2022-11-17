﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResortRental.Repository.DataContext;

#nullable disable

namespace Resort_Rental.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ResortRental.Domain.Entity.Bill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("BillNumber")
                        .HasColumnType("varchar(20)");

                    b.Property<long?>("ContractId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedByUser")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Period")
                        .HasColumnType("varchar(10)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("RentalPrice")
                        .HasColumnType("double");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedByUser")
                        .HasColumnType("varchar(20)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("UserId");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("ResortRental.Domain.Entity.BillDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("BillId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedByUser")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FirstCounter")
                        .HasColumnType("int");

                    b.Property<int>("LastCounter")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<long?>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<double>("ServicePrice")
                        .HasColumnType("double");

                    b.Property<double>("Subtotal")
                        .HasColumnType("double");

                    b.Property<string>("UpdatedByUser")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("ServiceId");

                    b.ToTable("BillDetail");
                });

            modelBuilder.Entity("ResortRental.Domain.Entity.Contract", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("ContractNumber")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CreatedByUser")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FileLocation")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<long?>("RoomId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedByUser")
                        .HasColumnType("varchar(20)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("ResortRental.Domain.Entity.ContractDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("ContractId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedByUser")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("GuestId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedByUser")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("GuestId");

                    b.ToTable("ContractDetail");
                });

            modelBuilder.Entity("ResortRental.Domain.Entity.Guest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CitizenId")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CreatedByUser")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Fullname")
                        .HasColumnType("varchar(70)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Picture")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedByUser")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Guest");
                });

            modelBuilder.Entity("ResortRental.Domain.Entity.Room", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedByUser")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ElectricCounter")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Square")
                        .HasColumnType("double");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedByUser")
                        .HasColumnType("varchar(20)");

                    b.Property<int>("WaterCounter")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Room");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreationTime = new DateTime(2022, 11, 16, 16, 58, 32, 514, DateTimeKind.Local).AddTicks(6432),
                            Description = "1 phòng ngủ, 1 phòng khách, 1 giường 2m, tủ quần áo, điều hòa, bếp gas",
                            ElectricCounter = 0,
                            LastUpdateTime = new DateTime(2022, 11, 16, 16, 58, 32, 514, DateTimeKind.Local).AddTicks(6441),
                            Price = 5000000.0,
                            RoomNumber = "P101",
                            Square = 50.0,
                            Status = 0,
                            WaterCounter = 0
                        },
                        new
                        {
                            Id = 2L,
                            CreationTime = new DateTime(2022, 11, 16, 16, 58, 32, 514, DateTimeKind.Local).AddTicks(6443),
                            Description = "1 phòng ngủ, Tủ quần áo, Điều hòa, Tủ lạnh, Bếp gas",
                            ElectricCounter = 102,
                            LastUpdateTime = new DateTime(2022, 11, 16, 16, 58, 32, 514, DateTimeKind.Local).AddTicks(6444),
                            Price = 4500000.0,
                            RoomNumber = "P102",
                            Square = 40.0,
                            Status = 0,
                            WaterCounter = 301
                        },
                        new
                        {
                            Id = 3L,
                            CreationTime = new DateTime(2022, 11, 16, 16, 58, 32, 514, DateTimeKind.Local).AddTicks(6445),
                            Description = "1 phòng ngủ, 1 phòng khách, ban công, full nội thất",
                            ElectricCounter = 0,
                            LastUpdateTime = new DateTime(2022, 11, 16, 16, 58, 32, 514, DateTimeKind.Local).AddTicks(6446),
                            Price = 4750000.0,
                            RoomNumber = "P103",
                            Square = 45.0,
                            Status = 1,
                            WaterCounter = 0
                        });
                });

            modelBuilder.Entity("ResortRental.Domain.Entity.Service", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedByUser")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<string>("ServiceName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Unit")
                        .HasColumnType("longtext");

                    b.Property<string>("UpdatedByUser")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("ResortRental.Domain.Entity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Authority")
                        .HasColumnType("int");

                    b.Property<string>("CreatedByUser")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UpdatedByUser")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ResortRental.Domain.Entity.Bill", b =>
                {
                    b.HasOne("ResortRental.Domain.Entity.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId");

                    b.HasOne("ResortRental.Domain.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Contract");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ResortRental.Domain.Entity.BillDetail", b =>
                {
                    b.HasOne("ResortRental.Domain.Entity.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("BillId");

                    b.HasOne("ResortRental.Domain.Entity.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId");

                    b.Navigation("Bill");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ResortRental.Domain.Entity.Contract", b =>
                {
                    b.HasOne("ResortRental.Domain.Entity.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.HasOne("ResortRental.Domain.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ResortRental.Domain.Entity.ContractDetail", b =>
                {
                    b.HasOne("ResortRental.Domain.Entity.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId");

                    b.HasOne("ResortRental.Domain.Entity.Guest", "Guest")
                        .WithMany()
                        .HasForeignKey("GuestId");

                    b.Navigation("Contract");

                    b.Navigation("Guest");
                });
#pragma warning restore 612, 618
        }
    }
}
