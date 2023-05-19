//********************************************************************************************
//
// 文件名(File Name):                    AppLog
//
// 作者(Author):                            LEGION
//
// 日期(Create Date):                     2023/4/14 15:52:53
//
// 功能(Function):                         
//
// 修改记录(Revision History):
//         R1:
//********************************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public partial class LogHelper
    {
        /// <summary>
        /// 根目录
        /// </summary>
        private static string strRootPath = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 写调试日志
        /// </summary>
        /// <param name="strContent">内容</param>
        public static void WriteDebugLog(string strContent)
        {
            string strLogContent = "[调试]" + strContent;
            WriteSysLog("Debug", strLogContent);
        }

        /// <summary>
        /// 写数据交互日志
        /// </summary>
        /// <param name="strContent">内容</param>
        public static void WriteDataConLog(string strContent)
        {
            string strLogContent = "[数据]" + strContent;
            WriteSysLog("DataInteraction", strLogContent);
        }

        /// <summary>
        /// 写通讯日志
        /// </summary>
        /// <param name="strContent">内容</param>
        public static void WriteCommunicateLog(string strContent)
        {
            string strLogContent = "[通讯]" + strContent;
            WriteSysLog("Communicate", strLogContent);
        }

        /// <summary>
        /// 写通用日志
        /// </summary>
        /// <param name="strContent">内容</param>
        public static void WriteCommonLog(string strContent)
        {
            string strLogContent = "[通用]" + strContent;
            WriteSysLog("WriteCommonLog", strLogContent);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="strLogType">日志类型</param>
        /// <param name="strLogContent">日志内容</param>
        private static void WriteSysLog(string strLogType, string strLogContent)
        {
            try
            {
                //获取当前日期
                string strGetData = DateTime.Now.ToString("yyyyMMdd");
                //组装日志文件路径
                string strPath = strRootPath + "\\Logs\\" + strLogType + "\\" + strGetData + ".log";

                ///如果目录不存在则创建目录
                if (!Directory.Exists(strRootPath + "\\" + strLogType + "\\"))
                    Directory.CreateDirectory(strRootPath + "\\" + strLogType + "\\");

                ///处理内容
                strLogContent = "\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")
                    + "  ===========================================\r\n" + strLogContent;

                ///文件是否存在
                ///如果文件大小超过10MB则备份
                if (File.Exists(strPath))
                {
                    FileInfo fileInfo = new FileInfo(strPath);
                    long lngMaxLength = 10 * 1024 * 1024;
                    if (fileInfo.Length >= lngMaxLength)
                    {
                        for (int iCount = 0; iCount < 100; iCount++)
                        {
                            if (!File.Exists(strPath.Replace(strGetData + ".log", strGetData + "[" + iCount + "]" + ".log")))
                            {
                                FileMove(strPath, strPath.Replace(strGetData + ".log", strGetData + "[" + iCount + "]" + ".log"));
                                break;
                            }
                        }
                    }
                }

                ///如果文件存在则追加
                if (File.Exists(strPath))
                {
                    FileAdd(strPath, strLogContent);
                }
                else
                {
                    WriteFile(strPath, strLogContent);
                }
            }
            catch { }
        }
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="strPath">路径</param>
        /// <param name="strContent">内容</param>
        /// <param name="strCharset">字符集，默认为 Encoding.Default</param>
        private static void WriteFile(string strPath, string strContent, string strCharset = null)
        {
            Encoding encoding = Encoding.UTF8;

            try
            {
                if (!string.IsNullOrEmpty(strCharset))
                    encoding = Encoding.GetEncoding(strCharset);
            }
            catch { encoding = Encoding.Default; }

            //无目录则创建目录
            if (!Directory.Exists(Path.GetDirectoryName(strPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(strPath));
            }
            //无文件则创建文件
            if (!File.Exists(strPath))
            {
                FileStream fileStream = File.Create(strPath);
                fileStream.Close();
            }
            //向文件中写入内容
            StreamWriter streamWriter = new StreamWriter(strPath, false, encoding);
            streamWriter.Write(strContent);

            streamWriter.Close();
            streamWriter.Dispose();
        }
        /// <summary>
        /// 追加文件
        /// </summary>
        /// <param name="strPath">路径</param>
        /// <param name="strContent">内容</param>
        private static void FileAdd(string strPath, string strContent)
        {
            if (!Directory.Exists(Path.GetDirectoryName(strPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(strPath));
            }

            StreamWriter streamWriter = new StreamWriter(strPath, true, Encoding.UTF8);
            streamWriter.Write(strContent);
            streamWriter.Flush();
            streamWriter.Close();
        }
        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="strOrignFile">原始路径</param>
        /// <param name="strNewFile">新路径</param>
        private static void FileMove(string strOrignFile, string strNewFile)
        {
            if (!File.Exists(strOrignFile)) return;

            File.Move(strOrignFile, strNewFile);
        }
    }
}
