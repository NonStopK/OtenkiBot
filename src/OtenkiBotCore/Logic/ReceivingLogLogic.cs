using OtenkiBotCore.Entity;
using System;
using System.Linq;

namespace OtenkiBotCore.Logic
{
    /// <summary>
    /// 受信した発言に関するデータを制御するクラス
    /// </summary>
    public class ReceivingLogLogic
    {
        /// <summary>
        /// 受信発言群から未処理の発言情報を取得します。
        /// </summary>
        /// <returns>未処理かつ最も古い発言情報</returns>
        public ReceivingLog GetLatestReceivingLog()
        {
            using (var context = new OtenkiBotDbContext())
            {
                var t = from r in context.ReceivingLogs
                        orderby r.ReceivingDate
                        let rec = from s in context.SendingLogs
                                  where s.ReceivingLogId == r.ReceivingLogId
                                  select s
                        where rec.Count() == 0  // 送信ログに不在
                        select r;

                return (t.Count() == 0) ?
                    null : t.First();
            }
        }

        /// <summary>
        /// 受信した発言をDBに書き込みます。
        /// </summary>
        /// <param name="id">ステータスID</param>
        /// <param name="dt">受信日時</param>
        /// <param name="user">発言ユーザー名</param>
        /// <param name="mention">発言内容</param>
        public void SetReceivingLog(long id, DateTime dt, string user, string mention)
        {
            using (var context = new OtenkiBotDbContext())
            {
                context.ReceivingLogs.Add(new ReceivingLog()
                {
                    StatusId = id,
                    ReceivingDate = dt,
                    UserName = user,
                    Mention = mention,
                });
                context.SaveChanges();
            }
        }
    }
}
