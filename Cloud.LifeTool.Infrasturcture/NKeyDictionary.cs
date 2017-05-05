using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.LifeTool.Infrasturcture
{

    public class NKeyDictionary : Dictionary<string, string>
    {
        public NKeyDictionary()
            : base(StringComparer.OrdinalIgnoreCase)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public new string this[string key]
        {
            get
            {
                if (!this.ContainsKey(key))
                    return string.Empty;

                string value = string.Empty;

                TryGetValue(key, out value);

                return value ?? "";
            }
            set
            {
                this[key] = value;
            }
        }


        #region GetDataTypeValue

        public string GetStringValue(string key)
        {
            try
            {
                return this[key];
            }
            catch (Exception ex)
            {
                //参数不正确
                //Do it
                return string.Empty;
            }
        }

        public int? GetIntValue(string key)
        {
            try
            {
                return int.Parse(this[key]);
            }
            catch (Exception ex)
            {
                //参数不正确
                //Do it
                return null;
            }
        }

        public decimal? GetDecimalValue(string key)
        {
            try
            {
                return decimal.Parse(this[key]);
            }
            catch (Exception ex)
            {
                //参数不正确
                //Do it
                return null;
            }
        }

        public DateTime? GetDateTimeValue(string key)
        {
            try
            {
                return DateTime.Parse(this[key]);
            }
            catch (Exception ex)
            {
                //参数不正确
                //Do it
                return null;
            }
        }

        public bool? GetBoolValue(string key)
        {
            try
            {
                return bool.Parse(this[key]);
            }
            catch (Exception ex)
            {
                //参数不正确
                //Do it
                return null;
            }
        }

        #endregion

    }
}
