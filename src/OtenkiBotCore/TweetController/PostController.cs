using CoreTweet;
using CoreTweet.Streaming;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using OtenkiBotCore.Entity;
using OtenkiBotCore.Logic;

namespace OtenkiBotCore.TweetController
{
    /// <summary>
    /// Tweetのポスト制御を制御するクラス
    /// </summary>
    public class PostController : IPostController
    {
        /// <summary>
        /// リプライ間隔デフォルト値
        /// </summary>
        private const int DEFAULT_REPLY_INTERVAL = 10000;

        /// <summary>
        /// ひとりごと間隔デフォルト値
        /// </summary>
        private const int DEFAULT_SOLILOQUY_INTERVAL = 10;

        /// <summary>
        /// リプライフォーマット
        /// </summary>
        private const string REPLY_FORMAT = "@{0} {1}";

        /// <summary>
        /// ロガー
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// トークン
        /// </summary>
        Tokens _tokens = null;

        /// <summary>
        /// プッシュ通知プロバイダー
        /// </summary>
        IObservable<StreamingMessage> _observable = null;

        /// <summary>
        /// リプライ間隔(ms)
        /// </summary>
        private int _replyInterval;

        /// <summary>
        /// ひとりごと間隔(minutes)
        /// </summary>
        private double _soliloquyInterval;

        /// <summary>
        /// PostControllerクラスを初期化します。
        /// </summary>
        /// <param name="tokens">トークン</param>
        /// <param name="observable">プッシュ通知プロバイダー</param>
        /// <param name="replyInterval">リプライ間隔(ms)</param>
        /// <param name="soliloquyInterval">ひとりごと間隔(minutes)</param>
        public PostController(Tokens tokens, IObservable<StreamingMessage> observable, int replyInterval, double soliloquyInterval)
        {
            _tokens = tokens;
            _observable = observable;
            // 短すぎる間隔は設定できないようにしておく
            _replyInterval = (replyInterval < DEFAULT_REPLY_INTERVAL) ?
                DEFAULT_REPLY_INTERVAL : replyInterval;
            _soliloquyInterval = (soliloquyInterval < DEFAULT_SOLILOQUY_INTERVAL) ?
                DEFAULT_SOLILOQUY_INTERVAL : soliloquyInterval;
        }

        /// <summary>
        /// Tweetのポスト制御を開始します。
        /// </summary>
        public void Start()
        {
            using (var connection = _observable.Publish().Connect())
            {
                // 無限ループ
                while (true)
                {
                    try
                    {
                        // 一定時間待機
                        Thread.Sleep(_replyInterval);

                        // 対象のメンションを取得する
                        var log = new ReceivingLogLogic().GetLatestReceivingLog();
                        if (log == null)
                        {
                            // ひとりごと or なにもしない
                            TweetSoliloquy(_soliloquyInterval);
                        }
                        else
                        {
                            // 天気予報 or 適当なリプライ
                            TweetForecast(log);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Warn(ex.Message, ex);
                    }
                }
            }
        }

        /// <summary>
        /// ひとりごとを発言します。経過時間に満たない場合は何もしません。
        /// </summary>
        /// <param name="soliloquyInterval">経過時間(分)</param>
        private void TweetSoliloquy(double soliloquyInterval)
        {
            var isPassed = new SendingLogLogic().IsPassed(soliloquyInterval);
            if (!isPassed)
            {
                // 経過時間に満たない場合は中断
                _logger.Info("ひとりごと：経過時間を満たしていません。");
                return;
            }

            // ひとりごと文言を生成
            string soliloquy = new MentionMstLogic().GetRandomSoliloquy();

            // 発言
            var t = new Tweet()
            {
                Status = soliloquy
            };
            _tokens.Statuses.Update(t);
            _logger.Info("ひとりごと発言：" + soliloquy);

            // DBに書き込む
            new SendingLogLogic().SetSendingLog(
                null,
                soliloquy
                );
        }

        /// <summary>
        /// 天気予報、または適当なリプライ発言を行います。
        /// </summary>
        /// <param name="log">リプライ対象の発言情報</param>
        private void TweetForecast(ReceivingLog log)
        {
            // 予報地域取得
            var area = new WeatherForecastLogic().GetTargetArea(log.Mention);

            // リプライ文言を生成
            IReplyCreator creator = new ReplyCreatorFactory().Create(area);
            var reply = string.Format(
                REPLY_FORMAT,
                log.UserName,
                creator.CreateReply(log.Mention)
                );

            // 発言
            var t = new Tweet()
            {
                Status = reply,
                InReplyToStatusId = log.StatusId,              
            };
            _tokens.Statuses.Update(t);
            _logger.Info("リプライ発言：" + reply);

            // DBに書き込む
            new SendingLogLogic().SetSendingLog(
                log.ReceivingLogId,
                reply
                );
        }
    }
}
