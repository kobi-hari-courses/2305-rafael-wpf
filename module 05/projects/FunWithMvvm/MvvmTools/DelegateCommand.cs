using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmTools
{
    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> _action;
        private readonly Predicate<T>? _canExecute;

        public DelegateCommand(Action<T> action, Predicate<T>? canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }


        public event EventHandler? CanExecuteChanged;

        public void TriggerCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute((T)parameter!);
            }

            return true;
        }

        public void Execute(object? parameter)
        {
            _action.Invoke((T)parameter!);
        }
    }
}
