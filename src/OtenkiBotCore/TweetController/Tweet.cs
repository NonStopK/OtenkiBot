using CoreTweet;

namespace OtenkiBotCore.TweetController
{
    /// <summary>
    /// ツイート内容を定義するクラス
    /// </summary>
    [TwitterParameters]
    public class Tweet
    {
        /// <summary>
        /// ツイートする文字列
        /// </summary>
        [TwitterParameter("status")]
        public string Status { get; set; }

        /// <summary>
        /// リプライの場合に指定するツイートID
        /// </summary>
        [TwitterParameter("in_reply_to_status_id")]
        public long? InReplyToStatusId { get; set; }
    }
}
