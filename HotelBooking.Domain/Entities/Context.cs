using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Domain.Entities
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingEntity>().HasOne(u => u.User).WithMany(b => b.Bookings).HasForeignKey(k => k.BookingId);
            modelBuilder.Entity<BookingEntity>().HasOne(h => h.Hotel).WithMany(b => b.Bookings);
            modelBuilder.Entity<HotelEntity>().HasMany(r => r.Rooms).WithOne(h => h.Hotel).HasForeignKey(k => k.HotelId);
            modelBuilder.Entity<HotelEntity>().HasMany(b => b.Bookings).WithOne(h => h.Hotel).HasForeignKey(k => k.HotelId);
            modelBuilder.Entity<RoomEntity>().HasOne(h => h.Hotel).WithMany(r => r.Rooms).HasForeignKey(k => k.HotelId);
            modelBuilder.Entity<UserEntity>().HasMany(b => b.Bookings).WithOne(u => u.User).HasForeignKey(k => k.UserId);

            modelBuilder.Seed();
        }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<HotelEntity> Hotels { get; set; }

    }
}
