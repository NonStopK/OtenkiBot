using CoreTweet.Streaming;
using OtenkiBotCore.Logic;
using System;

namespace OtenkiBotCore.TweetController
{
    /// <summary>
    /// リプライを制御するクラス
    /// </summary>
    public class ReplyController : AbstractReplyController
    {
        /// <summary>
        /// ロガー
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// リプライを受信した時の処理を記述します。
        /// </summary>
        /// <param name="msg">ステータス</param>
        public override void CallBackReply(StatusMessage msg)
        {
            try
            {
                var status = (msg as StatusMessage).Status;
                if (status.InReplyToScreenName == SelfUserName)
                {
                    // 自分へのリプライならDBへ書き込む
                    _logger.Info("リプライ受信：" + status.Text);
                    new ReceivingLogLogic().SetReceivingLog(
                        status.Id,
                        status.CreatedAt.LocalDateTime,
                        status.User.ScreenName,
                        status.Text
                        );
                }
            }
            catch (Exception ex)
            {
                _logger.Warn(ex.Message, ex);
            }
        }

        /// <summary>
        /// <para>終端のリプライを受信した時の処理を記述します。</para>
        /// <para>（ストリーミングの場合は呼ばれないはず）</para>
        /// </summary>
        public override void CallBackComplete()
        {
            _logger.Warn("リプライ終端を受信しました。");
        }

        /// <summary>
        /// 例外を受信した時の処理を記述します。
        /// </summary>
        /// <param name="ex">例外</param>
        public override void CallBackException(Exception ex)
        {
            _logger.Warn("例外を受信しました。。");
            _logger.Warn(ex.Message, ex);
        }
    }
}
