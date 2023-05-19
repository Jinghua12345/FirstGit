using CommonLibrary;
using DataBaseLibrary.DataBase;
using Microsoft.VisualStudio.PlatformUI;
using Newtonsoft.Json.Linq;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModels.ViewModel;

namespace TestWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBaseDbContext userInfo = new DataBaseDbContext();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }




        private void ExecuteTestCommand(object obj)
        {
            MessageBox.Show("123");
        }

        private void ExecuteTestCommand(string value)
        {
            MessageBox.Show(value);
        }



        public UserInfo GetUserInfoes(UserInfo userInfoess)
        {
            var userInfoes = from l in userInfo.UserInfo
                             where l.UserName == userInfoess.UserName && l.PassWord == userInfoess.PassWord
                             select l;
            return userInfoes.FirstOrDefault();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FileEncryption.Main();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string str = FileDecryption.Main();
            MessageBox.Show(str);
        }

        //private void test_OnCylinderBack()
        //{

        //}
    }
}
