using OtenkiBotCore.Entity;
using System;
using System.Linq;

namespace OtenkiBotCore.Logic
{
    /// <summary>
    /// 天気予報以外：発言内容に関するデータを制御するクラス
    /// </summary>
    public class MentionMstLogic
    {
        /// <summary>
        /// ひとりごとに該当する発言内容群からランダムに1つを取得します。
        /// </summary>
        /// <returns></returns>
        public string GetRandomSoliloquy()
        {
            return Get((int)MentionTypeMst.MentionType.Soliloquy, (int)MentionSubTypeMst.MentionSubType.Unknown);
        }

        /// <summary>
        /// 該当する発言タイプIDの発言内容群からランダムに1つを取得します。
        /// </summary>
        /// <param name="mentionTypeId"></param>
        /// <param name="mentionSubTypeId"></param>
        /// <returns></returns>
        public string GetRandomOne(int mentionTypeId, int mentionSubTypeId)
        {
            return Get(mentionTypeId, mentionSubTypeId);
        }

        /// <summary>
        /// 内部処理：該当する発言タイプIDの発言内容群からランダムに1つを取得します。
        /// </summary>
        /// <param name="id">発言タイプID</param>
        /// <param name="subId">発言サブタイプID</param>
        /// <returns>発言内容</returns>
        private string Get(int id, int subId)
        {
            using (var context = new OtenkiBotDbContext())
            {
                var t = from m in context.MentionMsts
                        where m.MentionTypeMstId == id
                        && m.MentionSubTypeMstId == subId
                        select m;

                var index = new Random().Next(t.Count());
                return t.ToArray()[index].Mention;
            }
        }
    }
}
