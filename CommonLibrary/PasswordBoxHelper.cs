//********************************************************************************************
//
// 文件名(File Name):                    PasswordBoxHelper
//
// 作者(Author):                            LEGION
//
// 日期(Create Date):                     2023/4/10 11:48:42
//
// 功能(Function):                         
//
// 修改记录(Revision History):
//         R1:
//********************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace CommonLibrary
{
    /// <summary>
    /// 增加PasswordBox扩展属性
    /// </summary>
    public static class PasswordBoxHelper
    {
        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject obj, string value)
       {
            obj.SetValue(PasswordProperty, value);
        }

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordBoxHelper), new PropertyMetadata("", OnPasswordPropertyChanged));

        private static void OnPasswordPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox box = sender as PasswordBox;
            string password = (string)e.NewValue;
            if (box != null && box.Password != password)
            {
                box.Password = password;
            }
        }
    }

    /// <summary>
    /// 接收PasswordBox的密码修改事件
    /// </summary>
    public class PasswordBoxBehavior : Behavior<PasswordBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PasswordChanged += OmPasswordChanged;
        }

        private void OmPasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            string password = PasswordBoxHelper.GetPassword(passwordBox);
            if (passwordBox != null && passwordBox.Password != password)
                PasswordBoxHelper.SetPassword(passwordBox, passwordBox.Password);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PasswordChanged -= OmPasswordChanged;
        }
    }
}
