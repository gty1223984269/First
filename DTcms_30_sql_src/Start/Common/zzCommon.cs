using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace zzLib
{
    public class zzCommon
    {
        public static HttpResponseMessage GetObj2Json(object obj)
        {
            //JavaScriptSerializer类在System.Web.Extensions.dll中，注意添加这个引用  
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //JSON序列化  
            string result = serializer.Serialize(obj);
            //格式化Json引号""  
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }
        public static HttpResponseMessage datatabletojson(DataTable  dt)
        {
        string result=Newtonsoft.Json.JsonConvert.SerializeObject(dt);       
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// 格式化Json去掉斜杠
        public static HttpResponseMessage FormJsonStr(string jsonStr)
        {
            return new HttpResponseMessage { Content = new StringContent(jsonStr, System.Text.Encoding.UTF8, "application/json") };
        }

        public static string GetJsonFromObj(object obj)
        {
            //JavaScriptSerializer类在System.Web.Extensions.dll中，注意添加这个引用  
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //JSON序列化  
            return serializer.Serialize(obj);
        }

        //获取唯一id
        public static string GetGUID()
        {
            Guid tempCartId = Guid.NewGuid();
            return tempCartId.ToString();
        }

        /// post
        public static string HttpPost(string Url, string postDataStr)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] postData = encoding.GetBytes(postDataStr);

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = postData.Length;

            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                return reader.ReadToEnd();
                //反序列化upfileMmsMsg.Text
                //实现自己的逻辑
            }
            else
            {
                //访问失败
                return "error";
            }
        }

        public   static HttpResponseMessage returnO(string jsonStr)
        {
           

            return new HttpResponseMessage { Content = new StringContent(jsonStr,Encoding.UTF8) };
        }
     
        public static ArrayList DataTableToList(DataTable dt)
        {
            ArrayList arrayList = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();  //实例化一个参数集合
                foreach (DataColumn dataColumn in dt.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName].ToString());
                }
                arrayList.Add(dictionary); //ArrayList集合中添加键值
            }

            return arrayList;  //返回一个json字符串
        }
        /// <summary>
        /// 生成随机字母字符串(数字字母混和)
        /// </summary>
        /// <param name="codeCount">待生成的位数</param>
        public static string GetCheckCode(int codeCount)
        {
            string str = string.Empty;
            int rep = 0;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codeCount; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }
        /// <summary>
        /// 生成指定位数的随机数字
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRandomNumString(int length)
        {
            string aa = "0123456789";
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int number = random.Next(aa.Length);
                sb.Append(number);
            }
            return sb.ToString();
        }

        public static void zzLog(string str)
        {
            System.Diagnostics.Debug.WriteLine("【" + DateTime.Now.ToString() + "】" + str);
        }
       
        public static void WriteLogFile(string logFile, string logStr, string funcName)
        {
            if (File.Exists(logFile) == false)//如果不存在就创建file文件夹
            {
                File.Create(logFile).Close();
            }
            StreamWriter sw = File.AppendText(logFile);
            sw.WriteLine(DateTime.Now.ToString() + "-" + logStr + "【" + funcName + "】");
            sw.Flush();
            sw.Close();
        }

        #region 发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="email"></param>
        /// <param name="title">消息标题("来自***的邮件")</param>
        /// <param name="content">消息内容</param>
        /// <param name="filePath">附件路径 没有的可以不传值</param>
        /// <returns></returns>
        public static bool SendMail(string title, string email, object[] objContent, string filePath = "")
        {
            try
            {
                int emailSwitch = 0;//大于0表示开关打开
                string strEmailSwitch = PubConstant.GetConfig("email.switch");
                emailSwitch = Int32.Parse(strEmailSwitch);
                if (emailSwitch <= 0)
                {
                    return false;
                }
                MailMessage message = new MailMessage();
                string connectionString = PubConstant.GetConfig("emailFrom");
                message.From = new MailAddress(connectionString);
                message.To.Add(new MailAddress(email));
                message.Subject = title;
                message.SubjectEncoding = Encoding.UTF8;
                message.Body = string.Concat(objContent);
                if (!("".Equals(filePath)))
                {
                    message.Attachments.Add(new Attachment(filePath));
                }
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = false;
                message.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                string str2 = PubConstant.GetConfig("emailHost");
                client.Host = str2;
                client.Port = 0x19;
                string password = PubConstant.GetConfig("emailPwd");
                client.Credentials = new NetworkCredential(connectionString, password);
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region 获取用户默认头像
        /// <summary>
        /// 获取用户默认头像
        /// </summary>
        /// <param name=""></param>
        /// <returns>头像路径</returns>
        public static string getUserPhoto()
        {
            string localphoto = "/userPhotos/";
            string photo = "";
            System.Random random = new Random();
            int num = random.Next(9);
            photo = localphoto + num + ".jpg";
            return photo;
        }
        #endregion
        #region 保存64位字符流图像
        /// <summary>
        /// 保存64位字符流图像
        /// </summary>
        /// <param name="base64Stream"></param>
        /// <param name="rootPath">存放跟目录</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fileEndName">文件后缀</param>
        /// <returns>头像路径</returns>
        public static string DownLoadBase64File(string base64Stream, string rootPath, string fileName, string fileEndName)
        {
            //string rootPath = System.Web.HttpContext.Current.Server.MapPath("~");
            //string path = rootPath + filePath;
            string path = "";
            byte[] bytes = Convert.FromBase64String(base64Stream);           
            if (Directory.Exists(rootPath) == false)
            {
                Directory.CreateDirectory(rootPath);
            }
            string fileFullName = fileName + "." + fileEndName;
            path = rootPath + fileFullName;
            FileStream byteStream = File.OpenWrite(path);//获取字节流对象
            byteStream.Write(bytes, 0, bytes.Length);//将bts内的字节数据写入字节流，注意在这个过程中，数据已经写入文件D:\1.txt。
            byteStream.Close();//关闭字节流并且释放资源
            //string urlFileName = path + fileName;
            string urlFileName = path;
            return urlFileName;
        }
        #endregion

        #region 清除HTML标记
        public static string DropHTML(string Htmlstring)
        {
            if (string.IsNullOrEmpty(Htmlstring)) return "";
            //删除脚本  
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML  
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }
        #endregion

        #region 截取字符长度
        /// <summary>
        /// 截取字符长度
        /// </summary>
        /// <param name="inputString">字符</param>
        /// <param name="len">长度</param>
        /// <returns></returns>
        public static string CutString(string inputString, int len)
        {
            if (string.IsNullOrEmpty(inputString))
                return "";
            inputString = DropHTML(inputString);
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                try
                {
                    tempString += inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }
            //如果截过则加上半个省略号 
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
            if (mybyte.Length > len)
                tempString += "…";
            return tempString;
        }
        #endregion

        #region 清除HTML标记且返回相应的长度
        public static string DropHTML(string Htmlstring, int strLen)
        {
            return CutString(DropHTML(Htmlstring), strLen);
        }
        #endregion
        
    }
}