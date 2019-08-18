using HappierU.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappierU.Context
{
    public class EventContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public EventContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Comedian> Comedians { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("HappierU"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasData(new
                {
                    EventId = 1,
                    EventName = "The Great-ish Show",
                    EventDate = new DateTime(2019, 8, 18),
                    VenueId = 1
                });

            modelBuilder.Entity<Venue>()
                .HasData(new
                {
                    VenueId = 1,
                    VenueName = "CrediCard Hall",
                    VenueStreet = "Av. das Nações Unidas, 17955",
                    VenueNeighbor = "Vila Almeida",
                    VenueCity = "São Paulo",
                    VenueZipCode = "04795-100",
                    VenueAvailableSeats = 100
                });

            modelBuilder.Entity<Gig>()
                .HasData(new
                {
                    GigId = 1,
                    EventId = 1,
                    ComedianId = 1,
                    GigHeadline = "Back to the... Present!",
                    GigLengthInMinutes = 45
                }, new
                {
                    GigId = 2,
                    EventId = 1,
                    ComedianId = 2,
                    GigHeadline = "I'll chase you",
                    GigLengthInMinutes = 45
                });

            modelBuilder.Entity<Comedian>()
                .HasData(new
                {
                    ComedianId = 1,
                    ComedianFirstName = "Krusty",
                    ComedianLastName = "Clown",
                    ComedianPhone = "+55 (11) 98765-4321"
                }, new
                {
                    ComedianId = 2,
                    ComedianFirstName = "Stan",
                    ComedianLastName = "Pines",
                    ComedianPhone = "+55 (11) 91234-5678"
                });
        }
    }
}
