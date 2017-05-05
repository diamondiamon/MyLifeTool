using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.LifeTool.Service.ServiceModel
{
    /// <summary>
    /// fynas网站返回数据模型
    /// </summary>
    public class FynasResultModel<T>
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public T data { get; set; }
    }
    
    public class FynasResultData
    {
        /// <summary>
        /// 工作日
        /// </summary>
        public int workday { get; set; }

        /// <summary>
        /// 自然日
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 周末数
        /// </summary>
        public int weekend { get; set; }

        /// <summary>
        /// 假期
        /// </summary>
        public int holiday { get; set; }

        /// <summary>
        /// 调休
        /// </summary>
        public int extra { get; set; }

        public WorkdayForDate ToWorkdayForDate()
        {
            WorkdayForDate model = new WorkdayForDate()
            {
                Extraday = extra,
                Holiday = holiday,
                Naturalday = total,
                Weekend = weekend,
                Workday = workday
            };

            return model;
        }
    }
    
}
