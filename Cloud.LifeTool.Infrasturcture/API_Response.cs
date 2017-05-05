using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cloud.LifeTool.Infrasturcture
{
    /// <summary>
    /// 响应数据
    /// </summary>
    public class APIResponse
    {
        /// <summary>
        /// 参数
        /// </summary>
        public string Value;
        /// <summary>
        /// 状态
        /// </summary>
        public int Status;
    }

    /// <summary>
    /// 响应
    /// </summary>
    public class API_Response
    {
        /// <summary>
        /// 超时
        /// </summary>
        private static int TimeOut = 20000;

        /// <summary>
        /// 响应
        /// </summary>
        /// <param name="URI">链接</param>
        /// <param name="Request">请求字节数组</param>
        /// <returns>响应</returns>
        public static string Response(string URI, byte[] Request)
        {

            string response;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URI);
            req.KeepAlive = false;
            req.ProtocolVersion = HttpVersion.Version11;
            req.Method = "POST";
            req.ReadWriteTimeout = TimeOut;
            req.Timeout = TimeOut;
            try
            {
                req.ContentType = "application/x-www-form-urlencoded";
                if (Request == null)
                    req.ContentLength = 0;
                else
                {
                    req.ContentLength = Request.Length;
                    using (Stream writer = req.GetRequestStream())
                        writer.Write(Request, 0, Request.Length);
                }
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                if (resp != null)
                {
                    List<byte> data = new List<byte>();
                    using (Stream read = resp.GetResponseStream())
                    {
                        for (; ; )
                        {
                            int readbyte = read.ReadByte();
                            if (readbyte == -1)
                                break;
                            else
                                data.Add((byte)readbyte);
                        }
                    }
                    byte[] buffer = new byte[data.Count];
                    data.CopyTo(buffer, 0);
                    resp.Close();
                    response = Encoding.UTF8.GetString(buffer);
                }
                else
                {
                    response = "";
                    //获取响应数据为空
                }
            }
            catch (Exception e)
            {
                response = "";
                //获取响应异常
            }
            return response;
        }

        /// <summary>
        /// HttpClient实现Post请求
        /// </summary>
        public static async void Post(string url, Dictionary<string, string> dic, Action<string> complete = null)
        {
            try
            {
                //设置HttpClientHandler的AutomaticDecompression
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                //创建HttpClient（注意传入HttpClientHandler）
                using (var http = new HttpClient(handler))
                {
                    //使用FormUrlEncodedContent做HttpContent
                    var content = new FormUrlEncodedContent(dic);
                    //await异步等待回应

                    using (var response = await http.PostAsync(url, content))
                    {
                        //确保HTTP成功状态值
                        response.EnsureSuccessStatusCode();
                        //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                        //Console.WriteLine(await response.Content.ReadAsStringAsync());

                        var result = await response.Content.ReadAsStringAsync();
                        if (complete != null)
                        {
                            complete.Invoke(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("当前URL：" + url);
                sb.AppendLine(LogHelper.Instance.GetExceptionMessage(ex));

                LogHelper.Instance.Error(sb.ToString());
            }


        }

        /// <summary>
        /// Post请求(同步)
        /// </summary>
        /// <param name="URI">链接</param>
        /// <param name="dic">请求字节数组</param>
        /// <returns>响应</returns>
        public static string PostSync(string url, Dictionary<string, object> dic)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (string key in dic.Keys)
            {
                if (i > 0)
                {
                    sb.AppendFormat("&{0}={1}", key, dic[key]);
                }
                else
                {
                    sb.AppendFormat("{0}={1}", key, dic[key]);
                }
                i++;
            }
            byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());

            return Response(url, bytes);
        }

       
        /// <summary>
        /// HttpClient实现Put请求
        /// </summary>
        public static async void Put(string url, Dictionary<string, string> dic)
        {
            //设置HttpClientHandler的AutomaticDecompression
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            //创建HttpClient（注意传入HttpClientHandler）
            using (var http = new HttpClient(handler))
            {
                //使用FormUrlEncodedContent做HttpContent
                var content = new FormUrlEncodedContent(dic);

                //await异步等待回应

                var response = await http.PutAsync(url, content);
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

        }

        /// <summary>
        /// HttpClient实现Get请求
        /// </summary>
        public static async void Get(string url)
        {
            //创建HttpClient（注意传入HttpClientHandler）
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };

            using (var http = new HttpClient(handler))
            {
                //await异步等待回应
                var response = await http.GetAsync(url);
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();

                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        /// <summary>
        /// Post请求(同步)
        /// </summary>
        /// <param name="URI">链接</param>
        /// <param name="dic">请求字节数组</param>
        /// <returns>响应</returns>
        public static string GetSync(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Timeout = TimeOut;
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(responseStream);
            string line = sr.ReadToEnd();
            return line;
        }

        /// <summary>
        /// 响应
        /// </summary>
        /// <param name="URI">链接</param>
        /// <param name="Request">请求字节数组</param>
        /// <returns>响应</returns>
        public static byte[] GetResponse(string URI)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URI);
                req.KeepAlive = false;
                req.ProtocolVersion = HttpVersion.Version11;
                req.ReadWriteTimeout = 60000;
                req.Timeout = 60000;
                req.ContentType = "application/x-www-form-urlencoded";
                req.Method = "GET";
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                if (resp != null)
                {
                    List<byte> data = new List<byte>();
                    using (Stream read = resp.GetResponseStream())
                    {
                        for (; ; )
                        {
                            int readbyte = read.ReadByte();
                            if (readbyte == -1)
                                break;
                            else
                                data.Add((byte)readbyte);
                        }
                    }
                    byte[] buff = new byte[data.Count];
                    data.CopyTo(buff, 0);
                    //resp.Close();
                    //response = Encoding.UTF8.GetString(buff);
                    return buff;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
