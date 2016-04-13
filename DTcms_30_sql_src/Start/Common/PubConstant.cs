using System;
using System.Configuration;

namespace zzLib
{
    /// <summary>
    /// ����������
    /// </summary>
    public class PubConstant
    {        
        /// <summary>
        /// �õ�web.config������������ݿ������ַ�����
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
