using CoreTweet.Streaming;
using System;

namespace OtenkiBotCore.TweetController
{
    /// <summary>
    /// リプライを制御するクラスの抽象クラス
    /// </summary>
    public abstract class AbstractReplyController
    {
        /// <summary>
        /// 自分自身のTwitterユーザー名
        /// </summary>
        public string SelfUserName { get; set; }

        /// <summary>
        /// リプライを受信した時の処理を記述します。
        /// </summary>
        /// <param name="msg">ステータス</param>
        public abstract void CallBackReply(StatusMessage msg);

        /// <summary>
        /// <para>終端のリプライを受信した時の処理を記述します。</para>
        /// <para>（ストリーミングの場合は呼ばれないはず）</para>
        /// </summary>
        public abstract void CallBackComplete();

        /// <summary>
        /// 例外を受信した時の処理を記述します。
        /// </summary>
        /// <param name="ex">例外</param>
        public abstract void CallBackException(Exception ex);
    }
}
