using OtenkiBotCore.Entity;
using System.Linq;

namespace OtenkiBotCore.Logic
{
    /// <summary>
    /// 天気予報以外：リプライ解析に関するデータを制御するクラス
    /// </summary>
    public class MentionKeywordMstLogic
    {
        /// <summary>
        /// <para>発言を解析して発言タイプを取得します。</para>
        /// <para>発言タイプは天気予報以外の発言を取得する際に使用することを想定します。</para>
        /// </summary>
        /// <param name="mention">発言</param>
        /// <returns>発言タイプ</returns>
        public int GetMentionTypeId(string mention)
        {
            using (var context = new OtenkiBotDbContext())
            {
                var t = from m in context.MentionKeywordMsts
                        where mention.Contains(m.Keyword)
                        orderby m.Priority  // Priority順にソート
                        select m;

                return (t.Count() == 0) ?
                    (int)MentionTypeMst.MentionType.Unknown : t.First().MentionTypeMstId;
            }
        }
    }
}
