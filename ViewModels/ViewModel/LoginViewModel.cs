//********************************************************************************************
//
// 文件名(File Name):                    LoginViewModel
//
// 作者(Author):                            LEGION
//
// 日期(Create Date):                     2023/4/10 13:12:49
//
// 功能(Function):                         
//
// 修改记录(Revision History):
//         R1:
//********************************************************************************************

using CommonLibrary;
using DataBaseLibrary.DataBase;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Application = System.Windows.Application;

namespace ViewModels.ViewModel
{
    public class LoginViewModel : NotiticationObject
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString
            (string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString
            (string section, string key, string def, StringBuilder retVal, int size, string filePath);
        private UserInfoBll userInfoBll = new UserInfoBll();
        private UserInfo userInfoobj = new UserInfo();
        public LoginViewModel(Window window)
        {
            userInfoobj.UserName = "abc";
            userInfoobj.PassWord = "123";


            //string dateString = "20220218";//设置时间段
            //DateTime dt = DateTime.ParseExact(dateString, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);//将string转为datetime
            //if (DateTime.Now > dt)
            //{
            //    MessageBox.Show("使用时间到期！请与开发者协商", "提示");
            //    window.Close();
            //}

        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            get { return userInfoobj.UserName; }
            set
            {
                userInfoobj.UserName = value;
                this.RaisePropertyChanged("UserName");
            }
        }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string PassWord
        {
            get { return userInfoobj.PassWord; }
            set
            {
                userInfoobj.PassWord = value;
                this.RaisePropertyChanged("PassWord");
            }
        }

        /// <summary>
        /// 命令绑定
        /// </summary>
        private BaseCommand clickLoginCommand;
        /// <summary>
        /// 登录点击事件
        /// </summary>
        public BaseCommand ClickLoginCommand
        {
            get
            {
                if (clickLoginCommand == null)
                {
                    clickLoginCommand = new BaseCommand(new Action<object>(o =>
                    {
                        //执行登录逻辑
                        MessageBox.Show("这是一个按钮点击的事件--命令绑定");
                    }));
                }
                return clickLoginCommand;
            }
        }

        /// <summary>
        /// 事件绑定
        /// </summary>
        private BaseCommand loginClick;
        public BaseCommand LoginClick
        {
            get
            {

                if (loginClick == null)
                {
                    loginClick = new BaseCommand(new Action<object>(o =>
                    {

                        Task.Run(() =>
                        {
                            var i = userInfoBll.GetUser(UserName, PassWord);
                            if (i > 0)
                            {
                                while (ProgerssValue < 100)
                                {
                                    ProgerssValue += 1;
                                    Thread.Sleep(10);
                                }
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    test();
                                    for (int num = 0; num < 100; num++)
                                        LogHelper.WriteDebugLog( "我再调试");
                                    WindowManager.Show("MainWindow", null);
                                    ToClose = true;
                                });
                            }
                            else
                            {
                                MessageBox.Show("用户名或密码错误");
                            }
                        });
                    }));
                }
                return loginClick;
            }
        }

        private void test()
        {
            string PLC = GetIniKV("text", "PLC", null);
            string MES = GetIniKV("text", "MES", null);
        }

        internal static string GetIniKV(string group, string k, string v)
        {
            string sFileName = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "\\text.ini";

            if (v == null)
            {
                StringBuilder Temp = new StringBuilder(255);
                int Num;
                Num = GetPrivateProfileString(group, k, "无法读取对应数值", Temp, 255, sFileName);

                if ("无法读取对应数值" == Temp.ToString())
                {
                    WritePrivateProfileString(group, k, "", sFileName);
                }
                else
                {
                    v = Temp.ToString();
                }
                return v;
            }
            else
            {
                WritePrivateProfileString(group, k, v, sFileName);
                return v;
            }
        }



        private bool toClose = false;
        public bool ToClose
        {
            get { return toClose; }
            set
            {
                toClose = value;
                if (toClose)
                {
                    this.RaisePropertyChanged("ToClose");
                }
            }
        }

        private int progerssValue;
        public int ProgerssValue
        {
            get => progerssValue;
            set
            {
                progerssValue = value;
                this.RaisePropertyChanged("progerssValue");
            }
        }




    }
}
