//********************************************************************************************
//
// 文件名(File Name):                    WindowBehavior
//
// 作者(Author):                            LEGION
//
// 日期(Create Date):                     2023/4/10 14:18:11
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
using System.Windows.Interactivity;

namespace CommonLibrary
{
    public class WindowBehavior : Behavior<Window>
    {
        public static readonly DependencyProperty CloseProperty =
            DependencyProperty.Register("Close", typeof(bool), typeof(WindowBehavior), new PropertyMetadata(false, OnCloseChanged));

        private static void OnCloseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = ((WindowBehavior)d).AssociatedObject;
            var newValue = (bool)e.NewValue;
            if (newValue)
            {
                window.Close();
            }
        }
        public bool Close
        {
            get { return (bool)GetValue(CloseProperty); }
            set { SetValue(CloseProperty, value); }
        }


    }
}
