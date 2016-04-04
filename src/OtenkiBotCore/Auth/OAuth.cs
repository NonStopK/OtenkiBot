using CoreTweet;
using System;

namespace OtenkiBotCore.Auth
{
    /// <summary>
    /// TwitterでOAuth認証を行うクラス
    /// </summary>
    public class OAuth : IOAuth
    {
        /// <summary>
        /// ConsumerKey
        /// </summary>
        private readonly string _consumerKey = null;

        /// <summary>
        /// ConsumerSecret
        /// </summary>
        private readonly string _consumerSecret = null;

        /// <summary>
        /// OAuth認証のセッション情報
        /// </summary>
        private CoreTweet.OAuth.OAuthSession _session = null;

        /// <summary>
        /// TwitterでOAuth認証を行うクラスを初期化します。
        /// </summary>
        /// <param name="consumerKey">ConsumerKey</param>
        /// <param name="consumerSecret">ConsumerSecret</param>
        public OAuth(string consumerKey, string consumerSecret)
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
        }

        /// <summary>
        /// OAuth認証のためのURIを取得します。
        /// </summary>
        /// <returns>URI</returns>
        public Uri GetUri()
        {
            _session = CoreTweet.OAuth.Authorize(_consumerKey, _consumerSecret);
            return _session.AuthorizeUri;
        }

        /// <summary>
        /// PINCODEからトークンを取得します。
        /// </summary>
        /// <param name="pincode">PINCODE</param>
        /// <returns>トークン</returns>
        public Tokens GetTokens(string pincode)
        {
            return CoreTweet.OAuth.GetTokens(_session, pincode);
        }
    }
}
