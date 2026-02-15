using EventTracker.Models;

namespace EventTracker.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        { 
            context.Database.EnsureCreated();

            if (context.Events.Any())
            { 
            return;
            }

            var events = new List<EventModel>
            {
                new EventModel { Title = "Yaz Festivali",IsPinned = true, Description = "Yazın en büyük festivali!", Date = new DateTime(2024, 7, 15) },
                new EventModel { Title = "Teknoloji Konferansı", Description = "En son teknolojik gelişmeler.", Date = new DateTime(2024, 8, 20) },
                new EventModel { Title = "Sanat Sergisi",IsPinned = true, Description = "Yerel sanatçıların eserleri.", Date = new DateTime(2024, 9, 10) },
                new EventModel { Title = "Gastronomi Festivali", Description = "Dünya mutfağı lezzetleri.", Date = new DateTime(2024, 10, 5) },
                new EventModel { Title = "Kış Karnavalı",IsPinned = true, Description = "Buz pateni ve eğlence.", Date = new DateTime(2024, 12, 20) },
                new EventModel { Title = "Müzik Festivali", Description = "Canlı müzik performansları.", Date = new DateTime(2025, 1, 15) },
                new EventModel { Title = "Film Gösterimi", Description = "Bağımsız filmler.", Date = new DateTime(2025, 2, 10) }
            };
            context.Events.AddRange(events);
            context.SaveChanges();
        }

    }
}
