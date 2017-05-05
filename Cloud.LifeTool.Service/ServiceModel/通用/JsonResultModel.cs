using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.LifeTool.Service.ServiceModel
{
    public enum ResultStateEnum
    {
        /// <summary>
        /// 失败
        /// </summary>
        Fail = 0,
        /// <summary>
        /// 成功
        /// </summary>
        Success = 1
    }

    public class JsonResultModel : JsonResultModel<object>
    {
    }

    /// <summary>
    /// 客户端返回给使用端的结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonResultModel<T>
    {
        /// <summary>
        /// 是否成功,0:失败，1：成功
        /// </summary>
        public ResultStateEnum ResultState { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        public int Code { get; set; }

        ///// <summary>
        ///// 返回值
        ///// </summary>
        //public string ReturnValue { get; set; }

        /// <summary>
        /// 返回值
        /// </summary>
        public T ReturnValue { get; set; }
    }

    /// <summary>
    /// 客户端返回给使用端的结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class API_JsonResultModel<T>
    {
        /// <summary>
        /// 是否成功,0:失败，1：成功
        /// </summary>
        public ResultStateEnum ResultState { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        public int Code { get; set; }

        ///// <summary>
        ///// 返回值
        ///// </summary>
        //public string ReturnValue { get; set; }

        /// <summary>
        /// 返回值
        /// </summary>
        public T ResultData { get; set; }
    }
}
