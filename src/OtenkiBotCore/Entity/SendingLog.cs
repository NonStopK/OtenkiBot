using System;
using System.ComponentModel.DataAnnotations;

namespace OtenkiBotCore.Entity
{
    /// <summary>
    /// 送信ログ
    /// </summary>
    public class SendingLog
    {
        /// <summary>
        /// 送信ログID(PK)
        /// </summary>
        [Key]
        public int SendingLogId { get; set; }

        /// <summary>
        /// 送信日時
        /// </summary>
        public DateTime SendingDate { get; set; }

        /// <summary>
        /// 受信ログID(FK)
        /// </summary>
        [Association("SendingLogs_ReceivingLogs", "ReceivingLogId", "ReceivingLogId")]
        public int? ReceivingLogId { get; set; }

        /// <summary>
        /// 発言
        /// </summary>
        public string Mention { get; set; }

        /// <summary>
        /// 親：受信ログ
        /// </summary>
        public virtual ReceivingLog ReceivingLog { get; set; }
    }
}
