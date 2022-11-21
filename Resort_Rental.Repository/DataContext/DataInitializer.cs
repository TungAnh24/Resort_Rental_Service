using Microsoft.EntityFrameworkCore;
using ResortRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Repository.DataContext
{
    public class DataInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DataInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void Seed()
        {
            modelBuilder.Entity<Room>().HasData(
                new Room()
                {
                    RoomNumber = "P101" , Price = 5000000, Square = 50, Description = "1 phòng ngủ, 1 phòng khách, 1 giường 2m, tủ quần áo, điều hòa, bếp gas", ElectricCounter = 0, WaterCounter = 0, Status = 0
                },
                new Room()
                {
                    RoomNumber = "P102",
                    Price = 4500000,
                    Square = 40,
                    Description = "1 phòng ngủ, Tủ quần áo, Điều hòa, Tủ lạnh, Bếp gas",
                    ElectricCounter = 102,
                    WaterCounter = 301,
                    Status = 0
                },
                new Room()
                {
                    RoomNumber = "P103",
                    Price = 4750000,
                    Square = 45,
                    Description = "1 phòng ngủ, 1 phòng khách, ban công, full nội thất",
                    ElectricCounter = 0,
                    WaterCounter = 0,
                    Status = 1
                }
            );
        }
    }
}
