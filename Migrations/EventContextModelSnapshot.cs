﻿// <auto-generated />
using System;
using HappierU.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HappierU.Migrations
{
    [DbContext(typeof(EventContext))]
    partial class EventContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HappierU.Models.Comedian", b =>
                {
                    b.Property<int>("ComedianId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComedianFirstName");

                    b.Property<string>("ComedianLastName");

                    b.Property<string>("ComedianPhone");

                    b.HasKey("ComedianId");

                    b.ToTable("Comedians");

                    b.HasData(
                        new
                        {
                            ComedianId = 1,
                            ComedianFirstName = "Krusty",
                            ComedianLastName = "Clown",
                            ComedianPhone = "+55 (11) 98765-4321"
                        },
                        new
                        {
                            ComedianId = 2,
                            ComedianFirstName = "Stan",
                            ComedianLastName = "Pines",
                            ComedianPhone = "+55 (11) 91234-5678"
                        });
                });

            modelBuilder.Entity("HappierU.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EventDate");

                    b.Property<string>("EventName");

                    b.Property<int?>("VenueId");

                    b.HasKey("EventId");

                    b.HasIndex("VenueId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            EventDate = new DateTime(2019, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "The Great-ish Show",
                            VenueId = 1
                        });
                });

            modelBuilder.Entity("HappierU.Models.Gig", b =>
                {
                    b.Property<int>("GigId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ComedianId");

                    b.Property<int?>("EventId");

                    b.Property<string>("GigHeadline");

                    b.Property<int>("GigLengthInMinutes");

                    b.HasKey("GigId");

                    b.HasIndex("ComedianId");

                    b.HasIndex("EventId");

                    b.ToTable("Gigs");

                    b.HasData(
                        new
                        {
                            GigId = 1,
                            ComedianId = 1,
                            EventId = 1,
                            GigHeadline = "Back to the... Present!",
                            GigLengthInMinutes = 45
                        },
                        new
                        {
                            GigId = 2,
                            ComedianId = 2,
                            EventId = 1,
                            GigHeadline = "I'll chase you",
                            GigLengthInMinutes = 45
                        });
                });

            modelBuilder.Entity("HappierU.Models.Venue", b =>
                {
                    b.Property<int>("VenueId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("VenueAvailableSeats");

                    b.Property<string>("VenueCity");

                    b.Property<string>("VenueName");

                    b.Property<string>("VenueNeighbor");

                    b.Property<string>("VenueStreet");

                    b.Property<string>("VenueZipCode");

                    b.HasKey("VenueId");

                    b.ToTable("Venues");

                    b.HasData(
                        new
                        {
                            VenueId = 1,
                            VenueAvailableSeats = 100,
                            VenueCity = "São Paulo",
                            VenueName = "CrediCard Hall",
                            VenueNeighbor = "Vila Almeida",
                            VenueStreet = "Av. das Nações Unidas, 17955",
                            VenueZipCode = "04795-100"
                        });
                });

            modelBuilder.Entity("HappierU.Models.Event", b =>
                {
                    b.HasOne("HappierU.Models.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId");
                });

            modelBuilder.Entity("HappierU.Models.Gig", b =>
                {
                    b.HasOne("HappierU.Models.Comedian", "Comedian")
                        .WithMany()
                        .HasForeignKey("ComedianId");

                    b.HasOne("HappierU.Models.Event", "Event")
                        .WithMany("Gigs")
                        .HasForeignKey("EventId");
                });
#pragma warning restore 612, 618
        }
    }
}
