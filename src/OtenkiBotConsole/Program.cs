using OtenkiBotCore.TweetController;
using System;

namespace OtenkiBotConsole
{
    class Program
    {
        /// <summary>
        /// ロガー
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// プログラムのエントリポイント
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            _logger.Info("BOT稼働準備開始");
            IStarter starter = new Starter(
                Properties.Settings.Default.ConsumerKey,
                Properties.Settings.Default.ConsumerSecret,
                Properties.Settings.Default.ReplyInterval,
                Properties.Settings.Default.SoliloquyInterval
                );

            _logger.Info("TwitterサイトからPINCODEを取得");
            IMainController controller = starter.Start();

            Console.Write("PINCODEを入力してください:");
            var pincode = Console.ReadLine();

            _logger.Info("BOT稼働開始");
            controller.Start(pincode);
        }
    }
}
