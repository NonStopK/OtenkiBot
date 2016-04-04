using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OtenkiBotCore.Entity;

namespace OtenkiBotCoreTest.Entity
{
    [TestFixture]
    public class OtenkiBotDbContextTest
    {
        private const string DB_CATALOG = "OtenkiBot";

        [SetUp]
        public void SetUp() { }

        [TearDown]
        public void TearDown() { }

        [Test]
        public void DbSetTest()
        {
            // ForecastDayMst
            using (var context = new OtenkiBotDbContext())
            {
                var result = from t in context.ForecastDayMsts
                             orderby t.Priority
                             select t;
            }

            // PrefectureMst
            using (var context = new OtenkiBotDbContext())
            {
                var result = from t in context.PrefectureMsts
                             select t;
            }

            // CityMst
            using (var context = new OtenkiBotDbContext())
            {
                var result = from t in context.CityMsts
                             select t;
            }

            // ForecastAreaRelationships
            using (var context = new OtenkiBotDbContext())
            {
                var result = from t in context.ForecastAreaRelationships
                             select t;
            }

            // MentionTypeMsts
            using (var context = new OtenkiBotDbContext())
            {
                var result = from t in context.MentionTypeMsts
                             select t;
            }

            // MentionSubTypeMsts
            using (var context = new OtenkiBotDbContext())
            {
                var result = from t in context.MentionSubTypeMsts
                             select t;
            }

            // MentionKeywordMst
            using (var context = new OtenkiBotDbContext())
            {
                var result = from t in context.MentionKeywordMsts
                             select t;
            }

            // MentionMsts
            using (var context = new OtenkiBotDbContext())
            {
                var result = from t in context.MentionMsts
                             select t;
            }

            // ReceivingLog
            using (var context = new OtenkiBotDbContext())
            {
                var result = from t in context.ReceivingLogs
                             select t;
            }

            // SendingLog
            using (var context = new OtenkiBotDbContext())
            {
                var result = from t in context.SendingLogs
                             select t;
            }

            // EndOfWordsMst
            using (var context = new OtenkiBotDbContext())
            {
                var result = from t in context.EndOfWordsMsts
                             select t;
            }
        }
    }
}
