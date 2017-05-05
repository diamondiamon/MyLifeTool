using Cloud.LifeTool.Infrasturcture;
using Cloud.LifeTool.Service.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.LifeTool.Service
{
    public class WorkdayService: BaseService
    {
        /// <summary>
        /// 按日期计算工作日天数
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public JsonResultModel CalByDate(DateTime startDate,DateTime endDate)
        {
            try
            {
                var dic = new Dictionary<string, object>();
                dic.Add("start_date", startDate.ToString("yyyy-MM-dd"));
                dic.Add("end_date", endDate.ToString("yyyy-MM-dd"));

                string url = string.Format("http://www.fynas.com/workday/count");
                var response = API_Response.PostSync(url, dic);
                
                var responseModel = JsonHelper.JsonDeserialize<FynasResultModel<FynasResultData>>(response);
                if (responseModel == null)
                    return new JsonResultModel() { ResultState = ResultStateEnum.Fail, Code = 500, Message = "系统返回数据为空" };
                
                if (responseModel.status > 0)
                {
                    return new JsonResultModel() { ResultState = ResultStateEnum.Fail, Code = responseModel.status, Message = responseModel.message };
                }
                else
                {
                    WorkdayForDate data = responseModel.data.ToWorkdayForDate();
                    return new JsonResultModel() { ResultState = ResultStateEnum.Success, ReturnValue = data };
                }
            }
            catch (Exception ex)
            {
                LogHelper.Instance.Error(ex);
                return new JsonResultModel() { ResultState = ResultStateEnum.Fail, Message = ex.Message, Code = -101 };
            }
        }

        /// <summary>
        /// 按工作日天数计算日期
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public JsonResultModel CalByDay(DateTime startDate, int days)
        {
            try
            {
                var dic = new Dictionary<string, object>();
                dic.Add("start_date", startDate.ToString("yyyy-MM-dd"));
                dic.Add("days", days);

                string url = string.Format("http://www.fynas.com/workday/end");
                var response = API_Response.PostSync(url, dic);

                var responseModel = JsonHelper.JsonDeserialize<FynasResultModel<string>>(response);
                if (responseModel == null)
                    return new JsonResultModel() { ResultState = ResultStateEnum.Fail, Code = 500, Message = "系统返回数据为空" };

                if (responseModel.status > 0)
                {
                    return new JsonResultModel() { ResultState = ResultStateEnum.Fail, Code = responseModel.status, Message = responseModel.message };
                }
                else
                {
                    return new JsonResultModel() { ResultState = ResultStateEnum.Success, ReturnValue = responseModel.data };
                }
            }
            catch (Exception ex)
            {
                LogHelper.Instance.Error(ex);
                return new JsonResultModel() { ResultState = ResultStateEnum.Fail, Message = ex.Message, Code = -101 };
            }
        }

    }
}
