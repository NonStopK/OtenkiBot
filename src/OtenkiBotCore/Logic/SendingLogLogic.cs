using OtenkiBotCore.Entity;
using System;
using System.Linq;

namespace OtenkiBotCore.Logic
{
    /// <summary>
    /// 送信した発言に関するデータを制御するクラス
    /// </summary>
    public class SendingLogLogic
    {
        /// <summary>
        /// 発言した内容をDBに書き込みます。
        /// </summary>
        /// <param name="recvId">対象の受信ログID</param>
        /// <param name="mention">発言内容</param>
        public void SetSendingLog(int? recvId, string mention)
        {
            using (var context = new OtenkiBotDbContext())
            {
                context.SendingLogs.Add(new SendingLog()
                {
                    SendingDate = DateTime.Now,
                    ReceivingLogId = recvId,
                    Mention = mention
                });
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 最後の発言から経過した時間を検査します。
        /// </summary>
        /// <param name="minutes">経過時間(分)</param>
        /// <returns>true：経過した false：未経過</returns>
        public bool IsPassed(double minutes)
        {
            using (var context = new OtenkiBotDbContext())
            {
                var t = from s in context.SendingLogs
                        orderby s.SendingDate descending
                        select s;

                if (t.Count() == 0)
                {
                    // 少なくとも1回はリプライを受けないとひとりごとを言わせない
                    return false;
                }
                else
                {
                    var borderDate = DateTime.Now.AddMinutes(0 - minutes);
                    var sendingDate = t.First().SendingDate;
                    // 最終発言時刻が基準時刻より過去になった場合にtrue(ひとりごとを言わせる)
                    return sendingDate < borderDate;
                }
            }
        }
    }
}
