using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

namespace Cloud.LifeTool.Infrasturcture
{
    /// <summary>
    /// URL管理器
    /// </summary>
    public class UrlManager
    {
        #region  Query

        public static string QueryString(string param)
        {
            try
            {
                string value = queryString(param);
                return value;
            }
            catch (Exception ex)
            {
                //参数不正确
                //Do it
                return string.Empty;
            }
        }

        public static int? QueryInt(string param)
        {
            try
            {
                string value = queryString(param);
                return int.Parse(value);
            }
            catch (Exception ex)
            {
                //参数不正确
                //Do it
                return null;
            }
        }

        public static decimal? QueryDecimal(string param)
        {
            try
            {
                string value = queryString(param);
                return decimal.Parse(value);
            }
            catch (Exception ex)
            {
                //参数不正确
                //Do it
                return null;
            }
        }

        public static DateTime? QueryDateTime(string param)
        {
            try
            {
                string value = queryString(param);
                return DateTime.Parse(value);
            }
            catch (Exception ex)
            {
                //参数不正确
                //Do it
                return null;
            }
        }

        public static bool? QueryBool(string param)
        {
            try
            {
                string value = queryString(param);
                return bool.Parse(value);
            }
            catch (Exception ex)
            {
                //参数不正确
                //Do it
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private static string queryString(string param)
        {
            string value = System.Web.HttpContext.Current.Request.QueryString[param];
            if (value == null)
            {
                var nvc = ParseUrl(System.Web.HttpContext.Current.Request.Url.Query);
                value = nvc[param];
            }
            return value;
        }

        #endregion

        #region Form

        public static string FormString(string param)
        {
            try
            {
                string value = formString(param);
                return value;
            }
            catch (Exception ex)
            {
                //参数不正确
                //Do it
                return string.Empty;
            }
        }

        public static int? FormInt(string param)
        {
            try
            {
                string value = formString(param);
                return int.Parse(value);
            }
            catch (Exception ex)
            {
                //参数不正确
                //Do it
                return null;
            }
        }

        public static decimal? FormDecimal(string param)
        {
            try
            {
                string value = formString(param);
                return decimal.Parse(value);
            }
            catch (Exception ex)
            {
                //参数不正确
                //Do it
                return null;
            }
        }

        public static DateTime? FormDateTime(string param)
        {
            try
            {
                string value = formString(param);
                return DateTime.Parse(value);
            }
            catch (Exception ex)
            {
                //参数不正确
                //Do it
                return null;
            }
        }

        public static bool? FormBool(string param)
        {
            try
            {
                string value = formString(param);
                return bool.Parse(value);
            }
            catch (Exception ex)
            {
                //参数不正确
                //Do it
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private static string formString(string param)
        {
            string value = System.Web.HttpContext.Current.Request.Form[param];
            if (value == null)
            {
                var nvc = ParseUrl(System.Web.HttpContext.Current.Request.Url.Query);
                value = nvc[param];
            }
            return value;
        }

        #endregion

        /// <summary>
        /// URL参数部分转换 
        /// by wk 2015-04-07
        /// </summary>
        /// <param name="url">?Id=0&MainPicture=&Title=&Description=&FunctionDescription=&VersionDescription=</param>
        /// <returns>NameValueCollection</returns>
        public static NameValueCollection ParseUrl(string url)
        {
            url = HttpUtility.UrlDecode(url);
            url = HttpContext.Current.Server.UrlDecode(url);

            NameValueCollection nvList = new NameValueCollection();
            try
            {
                url = url.StartsWith("?") ? url.Substring(1) : url;
                string[] paramArr = url.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

                int tmpIndex;
                foreach (string param in paramArr)
                {
                    if (string.IsNullOrEmpty(param))
                        continue;
                    tmpIndex = param.IndexOf('=');
                    if (tmpIndex == -1)
                        continue;
                    nvList.Add(param.Substring(0, tmpIndex), param.Substring(tmpIndex + 1));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
            return nvList;
        }

        /// <summary>
        /// DES加密方法加密链接参数
        /// </summary>
        public static string DESEncryptEncode(string input, bool UrlEncode = true)
        {
            string encode = DES_Encrypt.EncodeToBase64(input.ToString());
            encode = encode.Replace('/', '~');
            encode = encode.Replace('+', '$');
            encode = encode.Replace("%2b", "$");
            if (UrlEncode)
            {
                encode = HttpUtility.UrlEncode(encode);
            }
            return encode;
        }

        /// <summary>
        /// DES加密方法解密链接参数
        /// </summary>
        public static string DESEncryptDecode(string input, bool UrlDecode = true)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            string decode = input;
            if (UrlDecode)
            {
                decode = HttpUtility.UrlDecode(input);
            }
            decode = decode.Replace('~', '/');
            decode = decode.Replace("$", "+");

            decode = DES_Encrypt.DecodeFromBase64(decode);
            return decode;
        }

        #region NKey

        ///// <summary>
        ///// 生成NKey
        ///// </summary>
        ///// <param name="dic"></param>
        ///// <returns></returns>
        //public static string CreateNKey(Dictionary<string,object> dic,bool UrlEncode=true)
        //{
        //    if (dic == null || dic.Count == 0)
        //        return string.Empty;

        //    StringBuilder sb = new StringBuilder();

        //    foreach (var item in dic)
        //    {
        //        sb.AppendFormat("|&|{0}|:|{1}", item.Key, item.Value);
        //    }

        //    string param = sb.ToString().Trim("|&|".ToCharArray());
        //    string encode = DESEncryptEncode(param, UrlEncode);

        //    return encode;

        //}

        /// <summary>
        /// 生成NKey
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string CreateNKey(Dictionary<string, string> dic, bool UrlEncode = true)
        {
            if (dic == null || dic.Count == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (var item in dic)
            {
                sb.AppendFormat("|&|{0}|:|{1}", item.Key, item.Value);
            }

            string param = sb.ToString().Trim("|&|".ToCharArray());
            string encode = DESEncryptEncode(param, UrlEncode);

            //StringBuilder sb2 = new StringBuilder();
            //sb2.AppendLine(param);
            //sb2.AppendLine(encode);
            //LogHelper.Instance.CreateNKey(sb2.ToString());

            return encode;

        }


        /// <summary>
        /// 解密NKey
        /// </summary>
        /// <param name="nKey"></param>
        /// <returns></returns>
        private static Dictionary<string, string> DESNKey2(string nKey, bool UrlEncode = true)
        {

            var dic = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase); //不区分大小写
            if (string.IsNullOrEmpty(nKey))
                return dic;

            string keyString = DESEncryptDecode(nKey, UrlEncode);
            string[] keys = keyString.Split(new string[] { "|&|" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var key in keys)
            {
                var tmpKey = key.Replace("|:|", "*");
                //string[] param = System.Text.RegularExpressions.Regex.Split(key, "|:|");
                string[] param = tmpKey.Split("*".ToCharArray());
                if (param == null || param.Length != 2)
                    continue;

                string keyName = param[0];
                string value = param[1];

                if (string.IsNullOrEmpty(keyName))
                    continue;
                if (!dic.ContainsKey(key))
                {
                    dic.Add(keyName, value);
                }
            }

            return dic;

        }

        /// <summary>
        /// 解密NKey
        /// </summary>
        /// <param name="nKey"></param>
        /// <returns></returns>
        public static NKeyDictionary DESNKey(string nKey, bool UrlDecode = true)
        {

            NKeyDictionary dic = new NKeyDictionary();
            if (string.IsNullOrEmpty(nKey))
                return dic;

            string keyString = DESEncryptDecode(nKey, UrlDecode);
            string[] keys = keyString.Split(new string[] { "|&|" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var key in keys)
            {
                var tmpKey = key.Replace("|:|", "*");
                //string[] param = System.Text.RegularExpressions.Regex.Split(key, "|:|");
                string[] param = tmpKey.Split("*".ToCharArray());
                if (param == null || param.Length != 2)
                    continue;

                string keyName = param[0];
                string value = param[1];

                if (string.IsNullOrEmpty(keyName))
                    continue;
                if (!dic.ContainsKey(key))
                {
                    dic.Add(keyName, value);
                }
            }

            return dic;
        }
        #endregion

    }
}