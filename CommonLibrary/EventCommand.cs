//********************************************************************************************
//
// 文件名(File Name):                    EventCommand
//
// 作者(Author):                            LEGION
//
// 日期(Create Date):                     2023/4/10 13:24:22
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
using System.Windows.Input;
using System.Windows.Interactivity;

namespace CommonLibrary
{
    public class EventCommand : TriggerAction<DependencyObject>
    {
        /// <summary>
        /// 事件命令
        /// </summary>
        /// <param name="parameter"></param>
        protected override void Invoke(object parameter)
        {
            if (CommandParameter != null)
            {
                parameter = CommandParameter;
            }
            if (Command != null)
            {
                Command.Execute(parameter);
            }
        }

        /// <summary>
        /// 事件
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(EventCommand), new PropertyMetadata(null));

        /// <summary>
        /// 事件参数，如果为空，将自动传入事件的真实数据
        /// </summary>
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(EventCommand), new PropertyMetadata(null));
    }
}
