//********************************************************************************************
//
// 文件名(File Name):                    WindowManager
//
// 作者(Author):                            LEGION
//
// 日期(Create Date):                     2023/4/10 14:02:59
//
// 功能(Function):                         注册页面
//
// 修改记录(Revision History):
//         R1:
//********************************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CommonLibrary
{
    public class WindowManager
    {
        private static Hashtable _RegisterWindow = new Hashtable();
        /// <summary>
        /// 注册页面
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        public static void Register<T>(string key)
        {
            if (!_RegisterWindow.Contains(key))
                _RegisterWindow.Add(key, typeof(T));
        }
        /// <summary>
        /// 注册页面
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="t"></param>
        public static void Register<T>(string key, Type t)
        {
            if (!_RegisterWindow.Contains(key))
                _RegisterWindow.Add(key, t);
        }

        /// <summary>
        /// 移除页面
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            if (_RegisterWindow.Contains(key))
                _RegisterWindow.Remove(key);
        }

        /// <summary>
        /// 显示页面
        /// </summary>
        /// <param name="key"></param>
        /// <param name="VM"></param>
        public static void Show(string key, object VM)
        {
            if (_RegisterWindow.Contains(key))
            {
                var win = (Window)Activator.CreateInstance((Type)_RegisterWindow[key]);
                win.DataContext = VM;
                win.Show();
            }
        }
    }
}
