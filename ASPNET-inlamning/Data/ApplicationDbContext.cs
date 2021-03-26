using ASPNET_inlamning.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPNET_inlamning.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<AttendeeEvent> AttendeeEvents { get; set; }

        public static void Seed(ApplicationDbContext context)
        {
            if (context.Attendees.Any())
            {
                return;
            }

            /*  this.Attendees.RemoveRange(this.Attendees);
                this.Events.RemoveRange(this.Events);
                this.Organizers.RemoveRange(this.Organizers);*/

            context.Attendees.AddRange(new List<Attendee>()
            {
                new Attendee(){Name = "Samme", PhoneNumber = "0736473039"}
            });

            context.Organizers.AddRange(new List<Organizer>()
            {
                new Organizer(){Name = "FyreFestival AB", Email = "hello@fyre.com", PhoneNumber = "0734022797"}
            });

            context.Events.AddRange(new List<Event>()
            {
                new Event(){Title = "Fyre Festival", Description = "This is a festival", Place = "Exuma", Address= "Bahamas", Date = new DateTime(20200101), SpotsAvalible = 300},
                new Event(){Title = "Ultra Music Festival", Description = "Festival with good music", Place = "United States", Address= "Miami", Date = new DateTime(20200101), SpotsAvalible = 300},
                new Event(){Title = "Tomorrowland", Description = "This is a music festival", Place = "Belgium", Address= "Belgium", Date = new DateTime(20200101), SpotsAvalible = 300},
                new Event(){Title = "Brännbollsyran", Description = "This is a swedish festival", Place = "Umeå", Address= "Storgatan 40", Date = new DateTime(20200101), SpotsAvalible = 300}
            });

            context.SaveChanges();
        }
    }
}
