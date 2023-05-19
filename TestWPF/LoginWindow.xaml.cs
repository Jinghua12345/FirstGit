using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestWPF
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string UserName;
        public string UserPassword;
        public int border = 1;
        public static Hashtable userall_harsh;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void MoveWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Login_Button(object sender, RoutedEventArgs e)
        {
            
        }


        //“注册账户”TextBlock触发事件
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //RegisterWindow register1 = new RegisterWindow();  //Login为窗口名，把要跳转的新窗口实例化
            this.Close();  //关闭当前窗口
            //register1.ShowDialog();   //打开新窗口          
        }
    }
}
