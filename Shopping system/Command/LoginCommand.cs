using Shopping_system.Tools;
using Shopping_system.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Menu = Shopping_system.View.Menu;

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
            try
            {
                if (logIn != null)
                {
                    logIn(textBox.Text, passwordBox.Password);
                    Currents.chanseView(new Menu());
                }          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
