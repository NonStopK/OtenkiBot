using OtenkiBotCore.Auth;

namespace OtenkiBotCore.TweetController
{
    /// <summary>
    /// Twitterを使用開始するためのスタータークラス
    /// </summary>
    public class Starter : IStarter
    {
        /// <summary>
        /// ConsumerKey
        /// </summary>
        private string _consumerKey = null;

        /// <summary>
        /// ConsumerSecret
        /// </summary>
        private string _consumerSecret = null;

        /// <summary>
        /// リプライ間隔(ms)
        /// </summary>
        private int _replyInterval;

        /// <summary>
        /// ひとりごと間隔(minutes)
        /// </summary>
        private double _soliloquyInterval;

        /// <summary>
        /// Starterクラスを初期化します。
        /// </summary>
        /// <param name="consumerKey">ConsumerKey</param>
        /// <param name="consumerSecret">ConsumerSecret</param>
        /// <param name="replyInterval">リプライ間隔(ms)</param>
        /// <param name="soliloquyInterval">ひとりごと間隔(minutes)</param>
        public Starter(string consumerKey, string consumerSecret, int replyInterval, double soliloquyInterval)
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _replyInterval = replyInterval;
            _soliloquyInterval = soliloquyInterval;
        }

        /// <summary>
        /// Twitterを使用開始するため、認証処理を開始します。
        /// </summary>
        /// <returns>Tweetを制御するクラスのインスタンス</returns>
        public MainController Start()
        {
            IOAuth oAuth = new OtenkiBotCore.Auth.OAuth(_consumerKey, _consumerSecret);

            System.Diagnostics.Process.Start(oAuth.GetUri().AbsoluteUri);

            return new MainController(
                oAuth,
                new ReplyController(),
                _replyInterval,
                _soliloquyInterval
                );
        }
    }
}
