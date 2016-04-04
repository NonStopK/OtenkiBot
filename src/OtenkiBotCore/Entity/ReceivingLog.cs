using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OtenkiBotCore.Entity
{
    /// <summary>
    /// 受信ログ
    /// </summary>
    public class ReceivingLog
    {
        /// <summary>
        /// 受信ログID(PK)
        /// </summary>
        [Key]
        public int ReceivingLogId { get; set; }

        /// <summary>
        /// ステータスID
        /// </summary>
        public long StatusId { get; set; }

        /// <summary>
        /// 受信日時
        /// </summary>
        public DateTime ReceivingDate { get; set; }

        /// <summary>
        /// ユーザー名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 発言
        /// </summary>
        public string Mention { get; set; }

        /// <summary>
        /// 子：送信ログ
        /// </summary>
        public virtual ICollection<SendingLog> SendingLog { get; set; }
    }
}
