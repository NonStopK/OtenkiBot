using CoreTweet;
using System;

namespace OtenkiBotCore.Auth
{
    /// <summary>
    /// TwitterでOAuth認証を行うクラスのインタフェース
    /// </summary>
    public interface IOAuth
    {
        /// <summary>
        /// OAuth認証のためのURIを取得します。
        /// </summary>
        /// <returns>URI</returns>
        Uri GetUri();

        /// <summary>
        /// PINCODEからトークンを取得します。
        /// </summary>
        /// <param name="pincode">PINCODE</param>
        /// <returns>トークン</returns>
        Tokens GetTokens(string pincode);
    }
}
