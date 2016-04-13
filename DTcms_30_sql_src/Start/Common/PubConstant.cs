using System;
using System.Configuration;

namespace zzLib
{
    /// <summary>
    /// 公共连接类
    /// </summary>
    public class PubConstant
    {        
        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[configName].ConnectionString;
        }

        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["mysqlConnection"].ConnectionString;
        }

        public static string GetConfig(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
    }
}
