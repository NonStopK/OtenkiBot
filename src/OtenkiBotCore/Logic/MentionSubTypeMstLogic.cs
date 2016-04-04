using OtenkiBotCore.Entity;
using System;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace OtenkiBotCore.Logic
{
    /// <summary>
    /// 
    /// </summary>
    public class MentionSubTypeMstLogic
    {
        public int Get(int mentionTypeMstId, DateTime dt)
        {
            using (var context = new OtenkiBotDbContext())
            {
                // 日付、時刻を数字に変換
                var mmdd = dt.Month * 100 + dt.Day;
                var hhmm = dt.Hour * 100 + dt.Minute;

                var t = from m in context.MentionSubTypeMsts
                        where m.MentionTypeMstId == mentionTypeMstId &&
                        (
                          (
                            // 開始日と終了日の範囲内、または、開始時刻と終了時刻の範囲内
                            (m.BeginDate != 0 && m.BeginDate <= mmdd)
                            && (m.EndDate != 0 && mmdd <= m.EndDate)
                            || (m.BeginTime <= hhmm)
                            && (m.EndTime != 0 && hhmm <= m.EndTime)
                          )
                          ||
                          (
                            // 開始日と終了日の範囲内、かつ、開始時刻と終了時刻の範囲内
                            (m.BeginDate != 0 && m.BeginDate <= mmdd)
                            && (m.EndDate != 0 && mmdd <= m.EndDate)
                            && (m.BeginTime <= hhmm)
                            && (m.EndTime != 0 && hhmm <= m.EndTime)
                          )
                        )
                        select m;

                if (t.Count() == 0)
                {
                    return (int)MentionSubTypeMst.MentionSubType.Unknown;
                }
                else
                {
                    return t.First().MentionSubTypeMstId;
                }
            }
        }
    }
}
