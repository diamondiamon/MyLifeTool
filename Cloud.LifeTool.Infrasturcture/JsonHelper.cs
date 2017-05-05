using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Cloud.LifeTool.Infrasturcture
{
    public class JsonHelper
    {
        /// <summary>
        /// JSON转结构体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Json">JSON</param>
        /// <returns>结构体</returns>
        public static T JsonDeserialize<T>(string Json)
        {
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                jss.RegisterConverters(new[] { new DateTimeConverter() });
                T t = jss.Deserialize<T>(Json);
                return t;
            }
            catch(Exception ex)
            {
                return default(T);
            }
        }
        /// <summary>
        /// 结构体转JOSN
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns>JOSN</returns>
        public static string JsonSerializer<T>(T t)
        {
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                jss.RegisterConverters(new[] { new DateTimeConverter() });
                string json = jss.Serialize(t);
                return json;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }

    public class DateTimeConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new List<Type>() { typeof(DateTime), typeof(DateTime?) }; }
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (obj == null) return result;
            result["DateTime"] = ((DateTime)obj).ToString();
            return result;
        }

        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (dictionary.ContainsKey("DateTime"))
            {
                //return new DateTime(long.Parse(dictionary["DateTime"].ToString()), DateTimeKind.Unspecified);
                return DateTime.Parse(dictionary["DateTime"].ToString());
            }
            return null;
        }

    }
}
