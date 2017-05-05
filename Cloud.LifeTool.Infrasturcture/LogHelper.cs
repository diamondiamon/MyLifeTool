using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cloud.LifeTool.Infrasturcture
{
    /// <summary>
    /// 任务输出日志
    /// </summary>
    public sealed class LogHelper
    {
        private static readonly LogHelper _instance = new LogHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        private LogHelper()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public static LogHelper Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {
            Task task = new Task(() =>
            {
                writeMessage("Error", message);
            });
            task.Start();
        }
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message"></param>
        public void Error(Exception ex)
        {
            Task task = new Task(() =>
            {
                string message = GetExceptionMessage(ex);
                Error(message);
            });
            task.Start();
            
        }
        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message)
        {
            //return;
            //writeMessage("Info", message);
            Task task = new Task(() =>
            {
                writeMessage("Info", message);
            });
            task.Start();
        }
        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="message"></param>
        public void Warn(string message)
        {
            //return;
            //writeMessage("Warn", message);
            Task task = new Task(() =>
            {
                writeMessage("Warn", message);
            });
            task.Start();
        }
        /// <summary>
        /// 代金券发放日志
        /// </summary>
        /// <param name="message"></param>
        public void CashCouponSendLog(string message)
        {
            Task task = new Task(() =>
            {
                writeMessage("CashCouponSendLog", message);
            });
            task.Start();
        }

        /// <summary>
        /// 微信用户标识
        /// </summary>
        /// <param name="message"></param>
        public void WXUserFlagLog(string message)
        {
            Task task = new Task(() =>
            {
                writeMessage("WXUserFlagLog", message);
            });
            task.Start();
        }
        /// <summary>
        /// 微信用户标识
        /// </summary>
        /// <param name="message"></param>
        public void User_Limited(string message)
        {
            Task task = new Task(() =>
            {
                writeMessage("User_Limited", message);
            });
            task.Start();
        }
        /// <summary>
        /// 微信用户标识
        /// </summary>
        /// <param name="message"></param>
        public void Shake(string message)
        {
            Task task = new Task(() =>
            {
                writeMessage("Shake", message);
            });
            task.Start();
        }
        
        /// <summary>
        /// 用户与Ticket关系
        /// </summary>
        /// <param name="message"></param>
        public void GetARedPack(string message)
        {
            Task task = new Task(() =>
            {
                writeMessage("GetARedPack", message);
            });
            task.Start();
        }
        /// <summary>
        /// 用户与Ticket关系
        /// </summary>
        /// <param name="message"></param>
        public void GetARedPack2(string message)
        {
            Task task = new Task(() =>
            {
                writeMessage("GetARedPack2", message);
            });
            task.Start();
        }

        /// <summary>
        /// 用户与Ticket关系
        /// </summary>
        /// <param name="message"></param>
        public void RedisAuthentication(string message)
        {
            Task task = new Task(() =>
            {
                writeMessage("RedisAuthentication", message);
            });
            task.Start();
        }

        /// <summary>
        /// 反作弊处理
        /// </summary>
        /// <param name="message"></param>
        public void AntiCheat_Device_Solve(string message)
        {
            Task task = new Task(() =>
            {
                writeMessage("AntiCheat_Device_Solve", message);
            });
            task.Start();
        }
        
        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="message"></param>
        public void Debug(string message)
        {
            //writeMessage("Debug", message);
            Task task = new Task(() =>
            {
                writeMessage("Debug", message);
            });
            task.Start();
        }

        /// <summary>
        /// 微信支付日志
        /// </summary>
        /// <param name="message"></param>
        public void WechantPayLog(string message)
        {
            Task task = new Task(() =>
            {
                writeMessage("WechantPayLog", message);
            });
            task.Start();
        }

        /// <summary>
        /// 微信退款日志
        /// </summary>
        /// <param name="message"></param>
        public void WechantRefundLog(string message)
        {
            Task task = new Task(() =>
            {
                writeMessage("WechantRefundLog", message);
            });
            task.Start();
        }

        /// <summary>
        /// 测试日志
        /// </summary>
        /// <param name="message"></param>
        public void Test(string message)
        {
            //return;
            //writeMessage("Debug", message);
            Task task = new Task(() =>
            {
                writeMessage("Test", message);
            });
            task.Start();
        }

        /// <summary>
        /// 重要日志
        /// </summary>
        /// <param name="message"></param>
        public void Important(string message)
        {
            //writeMessage("Debug", message);
            Task task = new Task(() =>
            {
                writeMessage("Important", message);
            });
            task.Start();
        }

        /// <summary>
        /// 重要日志
        /// </summary>
        /// <param name="message"></param>
        public void SendToAccountNewVersion(string message)
        {
            //writeMessage("Debug", message);
            Task task = new Task(() =>
            {
                writeMessage("SendToAccountNewVersion", message);
            });
            task.Start();
        }

        /// <summary>
        /// 重要日志
        /// </summary>
        /// <param name="message"></param>
        public void MQProcesserLog(string message)
        {
            //writeMessage("Debug", message);
            Task task = new Task(() =>
            {
                writeMessage("MQProcesserLog", message);
            });
            task.Start();
        }
        /// <summary>
        /// 重要日志
        /// </summary>
        /// <param name="message"></param>
        public void DuobaoLog(string message)
        {
            //writeMessage("Debug", message);
            Task task = new Task(() =>
            {
                writeMessage("DuobaoLog", message);
            });
            task.Start();
        }

        /// <summary>
        /// CreateNKey
        /// </summary>
        /// <param name="message"></param>
        public void CreateNKey(string message)
        {
            Task task = new Task(() =>
            {
                writeMessage("CreateNKey", message);
            });
            task.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        private static object obj = new object();

        /// <summary>
        /// 添加日志
        /// </summary>
        private void writeMessage(string type, string message)
        {
            lock (obj)
            {
                try
                {
                    string basePath = AppDomain.CurrentDomain.BaseDirectory;
                    string path = string.Format("{0}/AppLog/{1}", basePath.Trim('/'), type);

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (StreamWriter sw = File.AppendText(string.Format(@"{0}/{1:yyyy_MM_dd}.log", path, DateTime.Now)))
                    {
                        sw.Write("日志记录时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
                        sw.Write(message);
                        sw.Write("\r\n------------------------------------------------------------------------\r\n");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// 获取异常信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public string GetExceptionMessage(Exception ex)
        {
            if (ex == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            if (ex.InnerException != null)
            {
                sb.AppendLine(GetExceptionMessage(ex.InnerException));
            }

            sb.AppendLine("    错误信息:" + ex.Message);
            sb.AppendLine("    堆栈信息:" + ex.StackTrace);

            return sb.ToString();
        }




        /// <summary>
        /// 自定义日志
        /// </summary>
        /// <param name="message"></param>
        public void Message(string name,string message)
        {
            Task task = new Task(() =>
            {
                writeMessage(name, message);
            });
            task.Start();
        }

        /// <summary>
        /// 公众号红包相关
        /// </summary>
        /// <param name="message"></param>
        public void OfficialRedpack(string message)
        {
            Task task = new Task(() =>
            {
                writeMessage("OfficialRedpack", message);
            });
            task.Start();
        }
    }
}
