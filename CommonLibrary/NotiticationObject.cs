//********************************************************************************************
//
// 文件名(File Name):                    NotiticationObject
//
// 作者(Author):                            LEGION
//
// 日期(Create Date):                     2023/4/10 13:13:27
//
// 功能(Function):                         
//
// 修改记录(Revision History):
//         R1:
//********************************************************************************************

using CommonLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommonLibrary
{
    public class NotiticationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 发起通知
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

       
    }
}
