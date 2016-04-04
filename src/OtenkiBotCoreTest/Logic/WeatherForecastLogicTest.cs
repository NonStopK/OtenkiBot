﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OtenkiBotCore.Entity;
using OtenkiBotCore.Logic;

namespace OtenkiBotCoreTest.Logic
{
    [TestFixture]
    public class WeatherForecastLogicTest
    {
        [SetUp]
        public void SetUp() { }

        [TearDown]
        public void TearDown() { }

        [TestCase("稚内", "稚内", "北海道")]
        [TestCase("旭川", "旭川", "北海道")]
        [TestCase("道北", "旭川", "北海道")]
        [TestCase("留萌", "留萌", "北海道")]
        [TestCase("札幌", "札幌", "北海道")]
        [TestCase("道央", "札幌", "北海道")]
        [TestCase("北海道", "札幌", "北海道")]
        [TestCase("岩見沢", "岩見沢", "北海道")]
        [TestCase("倶知安", "倶知安", "北海道")]
        [TestCase("網走", "網走", "北海道")]
        [TestCase("北見", "北見", "北海道")]
        [TestCase("紋別", "紋別", "北海道")]
        [TestCase("根室", "根室", "北海道")]
        [TestCase("釧路", "釧路", "北海道")]
        [TestCase("道東", "釧路", "北海道")]
        [TestCase("帯広", "帯広", "北海道")]
        [TestCase("室蘭", "室蘭", "北海道")]
        [TestCase("浦河", "浦河", "北海道")]
        [TestCase("道南", "函館", "北海道")]
        [TestCase("函館", "函館", "北海道")]
        [TestCase("江差", "江差", "北海道")]
        [TestCase("青森", "青森", "青森県")]
        [TestCase("むつ", "むつ", "青森県")]
        [TestCase("八戸", "八戸", "青森県")]
        [TestCase("秋田", "秋田", "秋田県")]
        [TestCase("横手", "横手", "秋田県")]
        [TestCase("岩手", "盛岡", "岩手県")]
        [TestCase("盛岡", "盛岡", "岩手県")]
        [TestCase("宮古", "宮古", "岩手県")]
        [TestCase("大船渡", "大船渡", "岩手県")]
        [TestCase("宮城", "仙台", "宮城県")]
        [TestCase("仙台", "仙台", "宮城県")]
        [TestCase("白石", "白石", "宮城県")]
        [TestCase("山形", "山形", "山形県")]
        [TestCase("米沢", "米沢", "山形県")]
        [TestCase("酒田", "酒田", "山形県")]
        [TestCase("新庄", "新庄", "山形県")]
        [TestCase("福島", "福島", "福島県")]
        [TestCase("小名浜", "小名浜", "福島県")]
        [TestCase("若松", "若松", "福島県")]
        [TestCase("茨城", "水戸", "茨城県")]
        [TestCase("水戸", "水戸", "茨城県")]
        [TestCase("つくば", "土浦", "茨城県")]
        [TestCase("土浦", "土浦", "茨城県")]
        [TestCase("宇都宮", "宇都宮", "栃木県")]
        [TestCase("栃木", "宇都宮", "栃木県")]
        [TestCase("大田原", "大田原", "栃木県")]
        [TestCase("群馬", "前橋", "群馬県")]
        [TestCase("前橋", "前橋", "群馬県")]
        [TestCase("みなかみ", "みなかみ", "群馬県")]
        [TestCase("さいたま", "さいたま", "埼玉県")]
        [TestCase("浦和", "さいたま", "埼玉県")]
        [TestCase("岩槻", "さいたま", "埼玉県")]
        [TestCase("埼玉", "さいたま", "埼玉県")]
        [TestCase("春日部", "さいたま", "埼玉県")]
        [TestCase("所沢", "さいたま", "埼玉県")]
        [TestCase("上尾", "さいたま", "埼玉県")]
        [TestCase("川越", "さいたま", "埼玉県")]
        [TestCase("川口", "さいたま", "埼玉県")]
        [TestCase("大宮", "さいたま", "埼玉県")]
        [TestCase("蕨", "さいたま", "埼玉県")]
        [TestCase("熊谷", "熊谷", "埼玉県")]
        [TestCase("秩父", "秩父", "埼玉県")]
        [TestCase("23区", "東京", "東京都")]
        [TestCase("阿佐ヶ谷", "東京", "東京都")]
        [TestCase("羽田", "東京", "東京都")]
        [TestCase("荻窪", "東京", "東京都")]
        [TestCase("葛飾", "東京", "東京都")]
        [TestCase("吉祥寺", "東京", "東京都")]
        [TestCase("錦糸町", "東京", "東京都")]
        [TestCase("駒込", "東京", "東京都")]
        [TestCase("恵比寿", "東京", "東京都")]
        [TestCase("原宿", "東京", "東京都")]
        [TestCase("五反田", "東京", "東京都")]
        [TestCase("御徒町", "東京", "東京都")]
        [TestCase("江戸川", "東京", "東京都")]
        [TestCase("荒川", "東京", "東京都")]
        [TestCase("高円寺", "東京", "東京都")]
        [TestCase("高田馬場", "東京", "東京都")]
        [TestCase("国分寺", "東京", "東京都")]
        [TestCase("三鷹", "東京", "東京都")]
        [TestCase("市ヶ谷", "東京", "東京都")]
        [TestCase("秋葉原", "東京", "東京都")]
        [TestCase("渋谷", "東京", "東京都")]
        [TestCase("小金井", "東京", "東京都")]
        [TestCase("上野", "東京", "東京都")]
        [TestCase("新橋", "東京", "東京都")]
        [TestCase("新宿", "東京", "東京都")]
        [TestCase("新大久保", "東京", "東京都")]
        [TestCase("神田", "東京", "東京都")]
        [TestCase("杉並", "東京", "東京都")]
        [TestCase("世田谷", "東京", "東京都")]
        [TestCase("西日暮里", "東京", "東京都")]
        [TestCase("赤羽", "東京", "東京都")]
        [TestCase("千代田", "東京", "東京都")]
        [TestCase("浅草", "東京", "東京都")]
        [TestCase("巣鴨", "東京", "東京都")]
        [TestCase("足立", "東京", "東京都")]
        [TestCase("多摩", "東京", "東京都")]
        [TestCase("代々木", "東京", "東京都")]
        [TestCase("台場", "東京", "東京都")]
        [TestCase("台東", "東京", "東京都")]
        [TestCase("大崎", "東京", "東京都")]
        [TestCase("大塚", "東京", "東京都")]
        [TestCase("大田", "東京", "東京都")]
        [TestCase("池袋", "東京", "東京都")]
        [TestCase("中野", "東京", "東京都")]
        [TestCase("町田", "東京", "東京都")]
        [TestCase("調布", "東京", "東京都")]
        [TestCase("田端", "東京", "東京都")]
        [TestCase("田町", "東京", "東京都")]
        [TestCase("東京", "東京", "東京都")]
        [TestCase("東京都港", "東京", "東京都")]
        [TestCase("東京都中央", "東京", "東京都")]
        [TestCase("東京都北", "東京", "東京都")]
        [TestCase("日暮里", "東京", "東京都")]
        [TestCase("八王子", "東京", "東京都")]
        [TestCase("板橋", "東京", "東京都")]
        [TestCase("飯田橋", "東京", "東京都")]
        [TestCase("品川", "東京", "東京都")]
        [TestCase("浜松町", "東京", "東京都")]
        [TestCase("府中", "東京", "東京都")]
        [TestCase("武蔵野", "東京", "東京都")]
        [TestCase("文京", "東京", "東京都")]
        [TestCase("北千住", "東京", "東京都")]
        [TestCase("墨田", "東京", "東京都")]
        [TestCase("木場", "東京", "東京都")]
        [TestCase("目黒", "東京", "東京都")]
        [TestCase("目白", "東京", "東京都")]
        [TestCase("有楽町", "東京", "東京都")]
        [TestCase("立川", "東京", "東京都")]
        [TestCase("練馬", "東京", "東京都")]
        [TestCase("鶯谷", "東京", "東京都")]
        [TestCase("大島", "大島", "東京都")]
        [TestCase("八丈島", "八丈島", "東京都")]
        [TestCase("父島", "父島", "東京都")]
        [TestCase("ディズニー", "千葉", "千葉県")]
        [TestCase("稲毛", "千葉", "千葉県")]
        [TestCase("浦安", "千葉", "千葉県")]
        [TestCase("花見川", "千葉", "千葉県")]
        [TestCase("市原", "千葉", "千葉県")]
        [TestCase("市川", "千葉", "千葉県")]
        [TestCase("若葉", "千葉", "千葉県")]
        [TestCase("松戸", "千葉", "千葉県")]
        [TestCase("成田", "千葉", "千葉県")]
        [TestCase("千葉", "千葉", "千葉県")]
        [TestCase("船橋", "千葉", "千葉県")]
        [TestCase("柏", "千葉", "千葉県")]
        [TestCase("美浜", "千葉", "千葉県")]
        [TestCase("幕張", "千葉", "千葉県")]
        [TestCase("銚子", "銚子", "千葉県")]
        [TestCase("館山", "館山", "千葉県")]
        [TestCase("磯子", "横浜", "神奈川県")]
        [TestCase("横須賀", "横浜", "神奈川県")]
        [TestCase("横浜", "横浜", "神奈川県")]
        [TestCase("神奈川", "横浜", "神奈川県")]
        [TestCase("瀬谷", "横浜", "神奈川県")]
        [TestCase("川崎", "横浜", "神奈川県")]
        [TestCase("鎌倉", "小田原", "神奈川県")]
        [TestCase("茅ヶ崎", "小田原", "神奈川県")]
        [TestCase("厚木", "小田原", "神奈川県")]
        [TestCase("小田原", "小田原", "神奈川県")]
        [TestCase("相模原", "小田原", "神奈川県")]
        [TestCase("長野", "長野", "長野県")]
        [TestCase("塩尻", "松本", "長野県")]
        [TestCase("松本", "松本", "長野県")]
        [TestCase("飯田", "飯田", "長野県")]
        [TestCase("甲府", "甲府", "山梨県")]
        [TestCase("山梨", "甲府", "山梨県")]
        [TestCase("小淵沢", "甲府", "山梨県")]
        [TestCase("河口湖", "河口湖", "山梨県")]
        [TestCase("静岡", "静岡", "静岡県")]
        [TestCase("網代", "網代", "静岡県")]
        [TestCase("三島", "三島", "静岡県")]
        [TestCase("浜松", "浜松", "静岡県")]
        [TestCase("愛知", "名古屋", "愛知県")]
        [TestCase("名古屋", "名古屋", "愛知県")]
        [TestCase("豊橋", "豊橋", "愛知県")]
        [TestCase("岐阜", "岐阜", "岐阜県")]
        [TestCase("高山", "高山", "岐阜県")]
        [TestCase("三重", "津", "三重県")]
        [TestCase("津", "津", "三重県")]
        [TestCase("尾鷲", "尾鷲", "三重県")]
        [TestCase("新潟", "新潟", "新潟県")]
        [TestCase("長岡", "長岡", "新潟県")]
        [TestCase("高田", "高田", "新潟県")]
        [TestCase("相川", "相川", "新潟県")]
        [TestCase("富山", "富山", "富山県")]
        [TestCase("伏木", "伏木", "富山県")]
        [TestCase("金沢", "金沢", "石川県")]
        [TestCase("石川", "金沢", "石川県")]
        [TestCase("輪島", "輪島", "石川県")]
        [TestCase("福井", "福井", "福井県")]
        [TestCase("敦賀", "敦賀", "福井県")]
        [TestCase("滋賀", "大津", "滋賀県")]
        [TestCase("大津", "大津", "滋賀県")]
        [TestCase("彦根", "彦根", "滋賀県")]
        [TestCase("右京", "京都", "京都府")]
        [TestCase("下京", "京都", "京都府")]
        [TestCase("京都", "京都", "京都府")]
        [TestCase("左京", "京都", "京都府")]
        [TestCase("山科", "京都", "京都府")]
        [TestCase("上京", "京都", "京都府")]
        [TestCase("西京", "京都", "京都府")]
        [TestCase("中京", "京都", "京都府")]
        [TestCase("東山", "京都", "京都府")]
        [TestCase("伏見", "京都", "京都府")]
        [TestCase("舞鶴", "舞鶴", "京都府")]
        [TestCase("阿倍野", "大阪", "大阪府")]
        [TestCase("此花", "大阪", "大阪府")]
        [TestCase("住吉", "大阪", "大阪府")]
        [TestCase("住之江", "大阪", "大阪府")]
        [TestCase("城東", "大阪", "大阪府")]
        [TestCase("生野", "大阪", "大阪府")]
        [TestCase("西成", "大阪", "大阪府")]
        [TestCase("大阪", "大阪", "大阪府")]
        [TestCase("天王寺", "大阪", "大阪府")]
        [TestCase("都島", "大阪", "大阪府")]
        [TestCase("東成", "大阪", "大阪府")]
        [TestCase("平野", "大阪", "大阪府")]
        [TestCase("淀川", "大阪", "大阪府")]
        [TestCase("浪速区", "大阪", "大阪府")]
        [TestCase("神戸", "神戸", "兵庫県")]
        [TestCase("須磨", "神戸", "兵庫県")]
        [TestCase("垂水", "神戸", "兵庫県")]
        [TestCase("長田", "神戸", "兵庫県")]
        [TestCase("灘", "神戸", "兵庫県")]
        [TestCase("兵庫", "神戸", "兵庫県")]
        [TestCase("豊岡", "豊岡", "兵庫県")]
        [TestCase("奈良", "奈良", "奈良県")]
        [TestCase("風屋", "風屋", "奈良県")]
        [TestCase("和歌山", "和歌山", "和歌山県")]
        [TestCase("潮岬", "潮岬", "和歌山県")]
        [TestCase("岡山", "岡山", "岡山県")]
        [TestCase("玉島", "岡山", "岡山県")]
        [TestCase("水島", "岡山", "岡山県")]
        [TestCase("倉敷", "岡山", "岡山県")]
        [TestCase("津山", "津山", "岡山県")]
        [TestCase("呉", "広島", "広島県")]
        [TestCase("広島", "広島", "広島県")]
        [TestCase("尾道", "広島", "広島県")]
        [TestCase("庄原", "庄原", "広島県")]
        [TestCase("松江", "松江", "島根県")]
        [TestCase("島根", "松江", "島根県")]
        [TestCase("浜田", "浜田", "島根県")]
        [TestCase("西郷", "西郷", "島根県")]
        [TestCase("鳥取", "鳥取", "鳥取県")]
        [TestCase("米子", "米子", "鳥取県")]
        [TestCase("徳島", "徳島", "徳島県")]
        [TestCase("日和佐", "日和佐", "徳島県")]
        [TestCase("香川", "高松", "香川県")]
        [TestCase("高松", "高松", "香川県")]
        [TestCase("愛媛", "松山", "愛媛県")]
        [TestCase("松山", "松山", "愛媛県")]
        [TestCase("新居浜", "新居浜", "愛媛県")]
        [TestCase("宇和島", "宇和島", "愛媛県")]
        [TestCase("高知", "高知", "高知県")]
        [TestCase("室戸", "室戸", "高知県")]
        [TestCase("清水", "清水", "高知県")]
        [TestCase("下関", "下関", "山口県")]
        [TestCase("山口", "山口", "山口県")]
        [TestCase("柳井", "柳井", "山口県")]
        [TestCase("萩", "荻", "山口県")]
        [TestCase("博多", "福岡", "福岡県")]
        [TestCase("福岡", "福岡", "福岡県")]
        [TestCase("北九州", "福岡", "福岡県")]
        [TestCase("八幡", "八幡", "福岡県")]
        [TestCase("飯塚", "飯塚", "福岡県")]
        [TestCase("久留米", "久留米", "福岡県")]
        [TestCase("大分", "大分", "大分県")]
        [TestCase("中津", "中津", "大分県")]
        [TestCase("日田", "日田", "大分県")]
        [TestCase("佐伯", "佐伯", "大分県")]
        [TestCase("長崎", "長崎", "長崎県")]
        [TestCase("佐世保", "佐世保", "長崎県")]
        [TestCase("厳原", "厳原", "長崎県")]
        [TestCase("福江", "福江", "長崎県")]
        [TestCase("佐賀", "佐賀", "佐賀県")]
        [TestCase("伊万里", "伊万里", "佐賀県")]
        [TestCase("熊本", "熊本", "熊本県")]
        [TestCase("阿蘇乙姫", "阿蘇乙姫", "熊本県")]
        [TestCase("牛深", "牛深", "熊本県")]
        [TestCase("人吉", "人吉", "熊本県")]
        [TestCase("宮崎", "宮崎", "宮崎県")]
        [TestCase("延岡", "延岡", "宮崎県")]
        [TestCase("都城", "都城", "宮崎県")]
        [TestCase("高千穂", "高千穂", "宮崎県")]
        [TestCase("鹿児島", "鹿児島", "鹿児島県")]
        [TestCase("鹿屋", "鹿屋", "鹿児島県")]
        [TestCase("種子島", "種子島", "鹿児島県")]
        [TestCase("名瀬", "名瀬", "鹿児島県")]
        [TestCase("沖縄", "沖縄", "沖縄県")]
        [TestCase("那覇", "沖縄", "沖縄県")]
        [TestCase("名護", "名護", "沖縄県")]
        [TestCase("久米島", "久米島", "沖縄県")]
        [TestCase("南大東島", "南大東", "沖縄県")]
        [TestCase("宮古島", "宮古島", "沖縄県")]
        [TestCase("石垣島", "石垣島", "沖縄県")]
        [TestCase("与那国島", "与那国島", "沖縄県")]
        public void GetTargetPlaceTest(string area, string cityName, string prefectureName)
        {
            // Arrange
            var mension = string.Format("明日の{0}を教えてください！", area);
            var logic = new WeatherForecastLogic();
            
            // Act
            var record = logic.GetTargetArea(mension);

            // Assert
            Assert.IsNotNull(record);
            Assert.AreEqual(area, record.Area);
            Assert.AreEqual(cityName, record.CityMst.CityName);
            Assert.AreEqual(prefectureName, record.CityMst.PrefectureMst.PrefectureName);
        }
    }
}
