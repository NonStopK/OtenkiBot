namespace OtenkiBotCore.TweetController
{
    /// <summary>
    /// リプライを生成するクラスのインタフェース
    /// </summary>
    public interface IReplyCreator
    {
        /// <summary>
        /// メンションに対するリプライの生成をします。
        /// </summary>
        /// <param name="mention">メンション</param>
        /// <returns></returns>
        string CreateReply(string mention);
    }
}
