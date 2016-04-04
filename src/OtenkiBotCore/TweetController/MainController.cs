using CoreTweet.Streaming;
using CoreTweet.Streaming.Reactive;
using System;
using System.Reactive.Linq;
using OtenkiBotCore.Auth;

namespace OtenkiBotCore.TweetController
{
    /// <summary>
    /// Tweet制御を行うクラス
    /// </summary>
    public class MainController : IMainController
    {
        /// <summary>
        /// 再接続待機時間（秒）
        /// </summary>
        private const int RETRY_LATENCY = 10;

        /// <summary>
        /// ロガー
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// OAuth認証を制御するクラスのインタフェース
        /// </summary>
        private IOAuth _oAuth = null;

        /// <summary>
        /// リプライを制御するクラスのインタフェース
        /// </summary>
        private AbstractReplyController _controller = null;

        /// <summary>
        /// リプライ間隔(ms)
        /// </summary>
        private int _replyInterval;

        /// <summary>
        /// ひとりごと間隔(minutes)
        /// </summary>
        private double _soliloquyInterval;

        /// <summary>
        /// Tweet制御を行うクラスを初期化します。
        /// </summary>
        /// <param name="oAuth">OAuth認証を制御するクラスのインタフェース</param>
        /// <param name="controller">リプライを制御するクラスのインタフェース</param>
        /// <param name="replyInterval">リプライ間隔(ms)</param>
        /// <param name="soliloquyInterval">ひとりごと間隔(minutes)</param>
        public MainController(IOAuth oAuth, AbstractReplyController controller, int replyInterval, double soliloquyInterval)
        {
            _oAuth = oAuth;
            _controller = controller;
            _replyInterval = replyInterval;
            _soliloquyInterval = soliloquyInterval;
        }

        /// <summary>
        /// Tweetの受信・発信を開始します。
        /// </summary>
        /// <param name="pincode">PINCODE</param>
        public void Start(string pincode)
        {
            var tokens = _oAuth.GetTokens(pincode);

            // TODO: 新しい実装方法
            var observable = tokens.Streaming.StartObservableStream(StreamingType.User);

            // 自分のユーザー名を教えておく
            _controller.SelfUserName = tokens.ScreenName;

            // リプライ制御開始（非同期）
            observable.Catch(
                observable.DelaySubscription(
                    TimeSpan.FromSeconds(RETRY_LATENCY)).Retry()
                    )
                    .Repeat()
                    .OfType<StatusMessage>()
                    .Subscribe(
                _controller.CallBackReply,
                _controller.CallBackException,
                _controller.CallBackComplete
                );

            // ポスト制御開始（同期）
            IPostController post = new PostController(
                tokens,
                observable,
                _replyInterval,
                _soliloquyInterval
                );
            post.Start();
        }
    }
}
