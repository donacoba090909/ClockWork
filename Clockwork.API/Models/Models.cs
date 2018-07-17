using System;
using Microsoft.EntityFrameworkCore;

namespace Clockwork.API.Models
{
    public class ClockworkContext : DbContext
    {
        private static bool _created = false;
        public DbSet<CurrentTimeQuery> CurrentTimeQueries { get; set; }

        public ClockworkContext()
        {
            if (!_created)
            {
                _created = true;
                // Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=clockwork.db");
            //optionsBuilder.UseSqlite(@"Data Source=d:\Sample.db");
        }
    }

    public class CurrentTimeQuery
    {
        public int CurrentTimeQueryId { get; set; }
        public DateTime Time { get; set; }
        public string ClientIp { get; set; }
        public DateTime UTCTime { get; set; }
    }
}
