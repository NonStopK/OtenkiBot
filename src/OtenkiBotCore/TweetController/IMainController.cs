namespace OtenkiBotCore.TweetController
{
    /// <summary>
    /// Tweet制御を行うクラスのインタフェース
    /// </summary>
    public interface IMainController
    {
        /// <summary>
        /// Tweetの受信・発信を開始します。
        /// </summary>
        /// <param name="pincode">PINCODE</param>
        void Start(string pincode);
    }
}
