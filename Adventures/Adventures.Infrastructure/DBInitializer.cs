using Adventures.Domain.Models;
using System;
using System.Linq;

namespace Adventures.Infrastructure
{

    public class DBInitializer
    {
        public static void Initialize(TravelContext context)
        {
			context.Database.EnsureCreated();

            // Look for any products.
            if (context.Countries.Any())
            {
                return;   // DB has been seeded
            }

            context.Countries.AddRange(
                new Country { Name = "Iceland" },
                new Country { Name = "USA" },
                new Country { Name = "Namibia" },
                new Country { Name = "South Africa" },
                new Country { Name = "Italy" });
            context.SaveChanges();

            context.Trips.AddRange(
                new Trip { Title = "The Laugavegur trail", CountryId = 1, Description = "The hiking trail between Landmannalaugar and Þórsmörk is one of the most popular hiking trails in Iceland. National Geographic listed it as one of the most beautiful trails in the world.", Price = 1867, Days = 7 },
                new Trip { Title = "The Alta Via 1", CountryId = 5, Description = "The Alta Via 1 is a walking trail through the Italian Dolomites, for 120km from Dobbiaco in the North to Belluno in the South.", Price = 1260, Days = 7 },
                new Trip { Title = "The Ring Road", CountryId = 1, Description = "The Ring Road in Iceland is one of the most popular road trip routes to drive in Iceland, take across the world – and with good reason.", Price = 2398, Days = 10 },
                new Trip { Title = "Wonders of Namibia", CountryId = 3, Description = "From flaming red sand dunes to arid woodlands that harbour some of the world's most majestic game, Namibia bursts with unique natural wonders.", Price = 1965, Days = 21 },
                new Trip { Title = "The American southwest", CountryId = 2, Description = "The American southwest is one of the USA’s best road trip destinations. It’s unbelievable how much there is to see and do here.", Price = 1845, Days = 14 },
                new Trip { Title = "Off road through the highlands", CountryId = 1, Description = "Glaciers, volcanoes, and geysers are the perfect playground for off-roading road trip in Iceland - and yes, you can drive yourself.", Price = 2154, Days = 14 },
                new Trip { Title = "From the Big 5 to Whale, Winelands and More", CountryId = 4, Description = "The Kruger's reserves deliver Africa's most reliable Big 5 game viewing, while Cape Town and its surrounding wine valleys provide an elegant Mediterranean twist.", Price = 1845, Days = 21 },
                new Trip { Title = "Etosha Kalahari Safari", CountryId = 3, Description = "This Safari takes you into Etosha National Park on an affordable wildlife safari offering comfortable accommodation and game viewing drives.", Price = 3451, Days = 21 },
                new Trip { Title = "Namibian Diversity: Wildlife, Scenery, Cultures", CountryId = 3, Description = "This tour includes a huge variety of wildlife, landscapes, game drives and different cultures.", Price = 2447, Days = 14 });
            context.SaveChanges();

            context.Travellers.AddRange(
                new Traveller { Firstname = "John", Lastname = "Smith", Email = "john.smith@at.com" },
                new Traveller { Firstname = "Sarah", Lastname = "Johnson", Email = "sarah.johnson@js.be" },
                new Traveller { Firstname = "David", Lastname = "Wilson", Email = "david.wilson@tele.be" },
                new Traveller { Firstname = "Emily", Lastname = "Brown", Email = "emily.brown@python.com" },
                new Traveller { Firstname = "Michael", Lastname = "Davis", Email = "michael.davis@travel.be" },
                new Traveller { Firstname = "Jessica", Lastname = "Lee", Email = "jessica.lee@bing.com" },
                new Traveller { Firstname = "Daniel", Lastname = "Miller", Email = "daniel.miller@google.com" },
                new Traveller { Firstname = "Olivia", Lastname = "Wilson", Email = "olivia.wilson@google.com" },
                new Traveller { Firstname = "Matthew", Lastname = "Anderson", Email = "matthew.anderson@trea.be" },
                new Traveller { Firstname = "Ava", Lastname = "Martinez", Email = "ava.martinez@mardi.es" });
            context.SaveChanges();

            context.Bookings.AddRange(
                new Booking { TravellerId = 1, TripId = 1 },
                new Booking { TravellerId = 10, TripId = 3 },
                new Booking { TravellerId = 9, TripId = 2 },
                new Booking { TravellerId = 7, TripId = 5 },
                new Booking { TravellerId = 1, TripId = 2 },
                new Booking { TravellerId = 1, TripId = 7 },
                new Booking { TravellerId = 10, TripId = 4 },
                new Booking { TravellerId = 9, TripId = 3 },
                new Booking { TravellerId = 7, TripId = 6 },
                new Booking { TravellerId = 5, TripId = 5 },
                new Booking { TravellerId = 2, TripId = 3 },
                new Booking { TravellerId = 3, TripId = 2 },
                new Booking { TravellerId = 6, TripId = 1 },
                new Booking { TravellerId = 4, TripId = 1 },
                new Booking { TravellerId = 8, TripId = 6 },
                new Booking { TravellerId = 6, TripId = 2 },
                new Booking { TravellerId = 4, TripId = 2 },
                new Booking { TravellerId = 8, TripId = 7 });
            context.SaveChanges();
        }
    }
}
