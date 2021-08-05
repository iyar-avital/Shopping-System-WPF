using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Shopping_system.Command
{
    public class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public event Action<string, string> logIn;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            object[] parameters = (object[])parameter;
            TextBox textBox = parameters[0] as TextBox;
            PasswordBox passwordBox = parameters[1] as PasswordBox;
            if (logIn != null)
                MessageBox.Show("כן זה עובד" + passwordBox.Password + " " + textBox.Text);
            logIn(textBox.Text, passwordBox.Password);
        }
    }
}
