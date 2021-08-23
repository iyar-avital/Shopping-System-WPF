using Shopping_system.View;
using Shopping_system.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shopping_system.Command
{
    public class RemoveCommand : ICommand
    {
        private Predicate<object> _canExecute;
        private Action<object> _method;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RemoveCommand(Action<object> method, Predicate<object> canExecute)
        {
            _method = method;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            try
            {
                _method.Invoke(parameter);
                new MessageBoxCustom("The purchase successfuly deleted", MessageType.Success).ShowDialog();
            }
            catch (Exception ex)
            {
                new MessageBoxCustom(ex.Message, MessageType.Error).ShowDialog();
            }
        }
    }
}
