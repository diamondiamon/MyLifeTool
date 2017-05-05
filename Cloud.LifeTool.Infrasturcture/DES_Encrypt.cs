using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Security.Cryptography;

namespace Cloud.LifeTool.Infrasturcture
{
    /// <summary>
    /// DES
    /// </summary>
    public class DES_Encrypt
    {
        /// <summary>
        /// Key
        /// </summary>
        private static byte[] Key = new byte[] { 198, 135, 72, 171, 191, 100, 247, 34 };
        /// <summary>
        /// IV
        /// </summary>
        private static byte[] IV = new byte[] { 241, 17, 19, 84, 228, 6, 19, 16 };

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="Input">待加密字串</param>
        /// <param name="encode">编码</param>
        /// <returns>加密字节</returns>
        public static byte[] Encode(string Input, Encoding encode)
        {
            byte[] buffer;
            if (string.IsNullOrEmpty(Input))
                buffer = new byte[0];
            else
            {

                try
                {
                    buffer = Encode(encode.GetBytes(Input));
                }
                catch (Exception e)
                {
                    buffer = new byte[0];
                    //DES加密异常
                }
            }
            return buffer;
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="Input">加密字节</param>
        /// <param name="encode">编码</param>
        /// <returns>解密字串</returns>
        public static string Decode(byte[] Input, Encoding encode)
        {
            string output;
            if (Input == null || Input.Length == 0)
                output = "";
            else
            {
                try
                {
                    byte[] buffer = Decode(Input);
                    if (buffer.Length > 0)
                    {
                        string decode = encode.GetString(buffer);
                        if (decode.Length > 0)
                            output = decode;
                        else
                            output = "";
                    }
                    else
                        output = "";
                }
                catch (Exception e)
                {
                    output = "";
                    //DES解密异常
                }
            }
            return output;
        }
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="Input">待加密字节</param>
        /// <returns>加密字节</returns>
        public static byte[] Encode(byte[] Input)
        {
            byte[] output;
            try
            {
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    des.Key = Key;
                    des.IV = IV;
                    MemoryStream mStream = new MemoryStream();
                    using (CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(Input, 0, Input.Length);
                        cStream.FlushFinalBlock();
                    }
                    output = mStream.ToArray();
                }
            }
            catch (Exception e)
            {
                output = new byte[0];
                //DES加密异常
            }
            return output;
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="Input">加密字节</param>
        /// <returns>解密字节</returns>
        public static byte[] Decode(byte[] Input)
        {
            byte[] output;
            try
            {
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    des.Key = Key;
                    des.IV = IV;
                    MemoryStream mStream = new MemoryStream();
                    using (CryptoStream cStream = new CryptoStream(mStream, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(Input, 0, Input.Length);
                        cStream.FlushFinalBlock();
                    }
                    output = mStream.ToArray();
                }
            }
            catch (Exception e)
            {
                output = new byte[0];
                //DES解密异常
            }
            return output;
        }

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="Input">待加密字串</param>
        /// <param name="Key">Key</param>
        /// <param name="IV">IV</param>
        /// <returns>加密字串</returns>
        public static string EncodeToBase64(string Input)
        {
            string output;
            if (string.IsNullOrEmpty(Input))
                output = "";
            else
            {
                try
                {
                    byte[] buffer = Encode(Encoding.UTF8.GetBytes(Input), Key, IV);
                    if (buffer.Length > 0)
                        return Convert.ToBase64String(buffer);
                    else
                        output = "";
                }
                catch (Exception e)
                {
                    output = "";
                    //DES加密异常
                    throw new Exception("DES_Encrypt.EncodeToBase64(string)" + Input + ":" + e.Message);
                }
            }
            return output;
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="Input">加密字串</param>
        /// <param name="Key">Key</param>
        /// <param name="IV">IV</param>
        /// <returns>解密字串</returns>
        public static string DecodeFromBase64(string Input)
        {
            string output;
            if (string.IsNullOrEmpty(Input))
                output = "";
            else
            {
                try
                {
                    var s = Convert.FromBase64String(Input);
                    byte[] buffer = Decode(Convert.FromBase64String(Input), Key, IV);
                    if (buffer.Length > 0)
                    {
                        string decode = Encoding.UTF8.GetString(buffer);
                        if (decode.Length > 0)
                            output = decode;
                        else
                            output = "";
                    }
                    else
                        output = "";
                }
                catch (Exception e)
                {
                    output = "";
                    LogHelper.Instance.Error("DES_Encrypt.EncodeToBase64(string)" + Input + ":" + e.Message);
                    LogHelper.Instance.Error(e);
                    //DES解密异常
                    //throw new Exception("DES_Encrypt.EncodeToBase64(string)" + Input + ":" + e.Message);
                }
            }
            return output;
        }

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="Input">待加密字节</param>
        /// <param name="Key">Key</param>
        /// <param name="IV">IV</param>
        /// <returns>加密字节</returns>
        internal static byte[] Encode(byte[] Input, byte[] Key, byte[] IV)
        {
            byte[] output;
            try
            {
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    des.Key = Key;
                    des.IV = IV;
                    MemoryStream mStream = new MemoryStream();
                    using (CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(Input, 0, Input.Length);
                        cStream.FlushFinalBlock();
                    }
                    output = mStream.ToArray();
                }
            }
            catch (Exception e)
            {
                output = new byte[0];
                //DES加密异常
                throw new Exception("DES_Encrypt.EncodeToBase64(string):" + e.Message);
            }
            return output;
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="Input">加密字节</param>
        /// <param name="Key">Key</param>
        /// <param name="IV">IV</param>
        /// <returns>解密字节</returns>
        internal static byte[] Decode(byte[] Input, byte[] Key, byte[] IV)
        {
            byte[] output;
            try
            {
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    des.Key = Key;
                    des.IV = IV;
                    MemoryStream mStream = new MemoryStream();
                    using (CryptoStream cStream = new CryptoStream(mStream, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(Input, 0, Input.Length);
                        cStream.FlushFinalBlock();
                    }
                    output = mStream.ToArray();
                }
            }
            catch (Exception e)
            {
                output = new byte[0];
                //DES解密异常
                throw new Exception("DES_Encrypt.EncodeToBase64(string):" + e.Message);
            }
            return output;
        }
    }
}
