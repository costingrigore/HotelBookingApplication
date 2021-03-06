using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Persistence.Seeding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
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
