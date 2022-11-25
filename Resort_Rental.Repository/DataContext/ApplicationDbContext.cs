using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resort_Rental.Domain.Entities;
using Resort_Rental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Repository.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Bill> Bills { get; set; } = null!;
        public DbSet<BillDetail> BillDetails { get; set; } = null!;
        public DbSet<Contract> Contracts { get; set; } = null!;
        public DbSet<ContractDetail> ContractDetails { get; set; } = null!;
        public DbSet<Guest> Guests { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
       
        public DbSet<AppUser> AppUsers { get; set; } = null!;
        public DbSet<AppRole> AppRoles { get; set; } = null!;

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
                new Room()
                {
                    Id= 1,
                    RoomNumber = "P101",
                    Price = 5000000,
                    Square = 50,
                    Description = "1 phòng ngủ, 1 phòng khách, 1 giường 2m, tủ quần áo, điều hòa, bếp gas",
                    ElectricCounter = 0,
                    WaterCounter = 0,
                    Status = 0,
                    CreationTime= DateTime.Now,
                    LastUpdateTime= DateTime.Now,
                    CreatedByUser = null,
                    UpdatedByUser = null
                },
                new Room()
                {
                    Id= 2,
                    RoomNumber = "P102",
                    Price = 4500000,
                    Square = 40,
                    Description = "1 phòng ngủ, Tủ quần áo, Điều hòa, Tủ lạnh, Bếp gas",
                    ElectricCounter = 102,
                    WaterCounter = 301,
                    Status = 0,
                    CreationTime = DateTime.Now,
                    LastUpdateTime = DateTime.Now,
                    CreatedByUser = null,
                    UpdatedByUser = null
                },
                new Room()
                {
                    Id = 3,
                    RoomNumber = "P103",
                    Price = 4750000,
                    Square = 45,
                    Description = "1 phòng ngủ, 1 phòng khách, ban công, full nội thất",
                    ElectricCounter = 0,
                    WaterCounter = 0,
                    Status = 1,
                    CreationTime = DateTime.Now,
                    LastUpdateTime = DateTime.Now,
                    CreatedByUser = null,
                    UpdatedByUser = null
                }
            );
        }*/
    }
}
