using OtenkiBotCore.Entity;
using System.Data.Entity;

namespace OtenkiBotCore.Entity
{
    public class OtenkiBotDbContext : DbContext
    {
        public OtenkiBotDbContext() { }
        //public OtenkiBotDbContext(string dbCatalog) { } : base(dbCatalog) { }

        public DbSet<ForecastDayMst> ForecastDayMsts { get; set; }

        public DbSet<PrefectureMst> PrefectureMsts { get; set; }

        public DbSet<CityMst> CityMsts { get; set; }

        public DbSet<ForecastAreaRelationship> ForecastAreaRelationships { get; set; }

        public DbSet<MentionTypeMst> MentionTypeMsts { get; set; }

        public DbSet<MentionSubTypeMst> MentionSubTypeMsts { get; set; }

        public DbSet<MentionKeywordMst> MentionKeywordMsts { get; set; }

        public DbSet<MentionMst> MentionMsts { get; set; }

        public DbSet<ReceivingLog> ReceivingLogs { get; set; }

        public DbSet<SendingLog> SendingLogs { get; set; }

        public DbSet<EndOfWordsMst> EndOfWordsMsts { get; set; }
    }
}
