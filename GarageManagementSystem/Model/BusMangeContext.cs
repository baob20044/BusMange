using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementSystem.Model
{
    public class BusManageContext : DbContext
    {
        public BusManageContext()
            : base("name=BusManageContext") // Replace with your connection string name in App.config or Web.config
        {
        }

        // DbSets for your database tables
        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusRoute> BusRoutes { get; set; }
        public DbSet<BusStop> BusStops { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<BookedTicket> BookedTickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleStop> ScheduleStops { get; set; }
        public DbSet<Order> Orders { get; set; }

        // Fluent API configuration
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure relationships, keys, and constraints here if necessary
            modelBuilder.Entity<BusRoute>()
                .HasMany(br => br.BusStops)
                .WithRequired(bs => bs.BusRoute)
                .HasForeignKey(bs => bs.RouteID);

            modelBuilder.Entity<Schedule>()
                .HasMany(s => s.ScheduleStops)
                .WithRequired(ss => ss.Schedule)
                .HasForeignKey(ss => ss.ScheduleID);

            // Configure Order and User relationship
            modelBuilder.Entity<Order>()
                .HasRequired(o => o.User)          // Order requires a User
                .WithMany(u => u.Orders)          // User has many Orders
                .HasForeignKey(o => o.UserID)     // Foreign key is UserID in Order
                .WillCascadeOnDelete(false);      // Configure cascade delete behavior

            // Rename Order table to match database schema
            modelBuilder.Entity<Order>().ToTable("Order");

            base.OnModelCreating(modelBuilder);
        }
    }
}
