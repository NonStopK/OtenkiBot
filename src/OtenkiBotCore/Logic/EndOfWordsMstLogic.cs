using OtenkiBotCore.Entity;
using System;
using System.Linq;

namespace OtenkiBotCore.Logic
{
    /// <summary>
    /// 天気予報：語尾に関わるデータを制御するクラス
    /// </summary>
    public class EndOfWordsMstLogic
    {
        /// <summary>
        /// 語尾情報群からランダムに1つを取得します。
        /// </summary>
        /// <returns>語尾</returns>
        public string GetRandomOne()
        {
            using (var context = new OtenkiBotDbContext())
            {
                var t = from eow in context.EndOfWordsMsts
                        select eow;

                var index = new Random().Next(t.Count());
                return (t.Count() == 0) ?
                    "" : t.ToArray()[index].Word;
            }
        }
    }
}
