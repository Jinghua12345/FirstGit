//********************************************************************************************
//
// 文件名(File Name):                    MainWindowViewModel
//
// 作者(Author):                            LEGION
//
// 日期(Create Date):                     2023/4/14 9:14:39
//
// 功能(Function):                         
//
// 修改记录(Revision History):
//         R1:
//********************************************************************************************

using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ViewModels.ViewModel
{
    public class MainWindowViewModel : NotiticationObject
    {
        public MainWindowViewModel()
        {

        }
        private void ExecuteTestCommand()
        {
            MessageBox.Show("测试");
        }
    }
}
