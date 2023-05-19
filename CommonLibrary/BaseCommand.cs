//********************************************************************************************
//
// 文件名(File Name):                    BaseCommand
//
// 作者(Author):                            LEGION
//
// 日期(Create Date):                     2023/4/10 13:14:55
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
using System.Windows.Input;

namespace CommonLibrary
{
    public class BaseCommand : ICommand
    {
        private Func<object, bool> _canExecute;
        private Action<object> _execute;
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        private void CommandManager_RequerySuggested(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (_execute != null && CanExecute(parameter))
            {
                _execute(parameter);
            }
        }

        public BaseCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public BaseCommand(Action<Object> execute) : this(execute, null) { }
    }
}
