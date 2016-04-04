using OtenkiBotCore.Entity;

namespace OtenkiBotCore.TweetController
{
    /// <summary>
    /// リプライを制御するクラス
    /// </summary>
    public class ReplyCreatorFactory
    {
        /// <summary>
        /// 予報地域情報の有無を元に、必要なReplyCreatorクラスのインスタンスを返却します。
        /// </summary>
        /// <param name="area">予報地域</param>
        public IReplyCreator Create(ForecastAreaRelationship area)
        {
            if (area == null)
            {
                // 予報地域を取得できなかった場合
                return new MeaninglessReplyCreator();
            }
            else
            {
                // 予報地域を取得できた場合
                return new ForecastReplyCreator(area);
            }
        }
    }
}
