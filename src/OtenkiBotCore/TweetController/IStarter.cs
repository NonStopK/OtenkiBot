namespace OtenkiBotCore.TweetController
{
    /// <summary>
    /// Twitterを使用開始するためのスタータークラスのインタフェース
    /// </summary>
    public interface IStarter
    {
        /// <summary>
        /// Twitterを使用開始するため、認証処理を開始します。
        /// </summary>
        /// <returns>Tweetを制御するクラスのインスタンス</returns>
        MainController Start();
    }
}
