using OtenkiBotCore.Logic;
using System;

namespace OtenkiBotCore.TweetController
{
    /// <summary>
    /// 無意味な(天気予報以外の)発言を生成するクラス
    /// </summary>
    public class MeaninglessReplyCreator : IReplyCreator
    {
        /// <summary>
        /// 無意味な(天気予報以外の)発言を生成します。
        /// </summary>
        /// <param name="mention">発言</param>
        /// <returns>リプライ内容</returns>
        public string CreateReply(string mention)
        {
            // 発言タイプを解析する
            var id = new MentionKeywordMstLogic().GetMentionTypeId(mention);
            // 日時に関する条件を解析する
            var subId = new MentionSubTypeMstLogic().Get(id, DateTime.Now);
            // 該当する発言タイプの発言内容群から1つをランダムに取得する。
            var s = new MentionMstLogic().GetRandomOne(id, subId);
            return s;
        }
    }
}
