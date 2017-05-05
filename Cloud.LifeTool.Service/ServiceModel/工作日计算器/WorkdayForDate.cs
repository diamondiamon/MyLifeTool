using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.LifeTool.Service.ServiceModel
{
    public class WorkdayForDate
    {
        /// <summary>
        /// 工作日
        /// </summary>
        public int Workday { get; set; }

        /// <summary>
        /// 自然日
        /// </summary>
        public int Naturalday { get; set; }

        /// <summary>
        /// 周末数
        /// </summary>
        public int Weekend { get; set; }

        /// <summary>
        /// 假期
        /// </summary>
        public int Holiday { get; set; }

        /// <summary>
        /// 调休
        /// </summary>
        public int Extraday { get; set; }
    }
}
