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
    public class SignupCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public event Action<string, string, string, string, string> signUp;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            object[] parameters = (object[])parameter;
            TextBox cid = parameters[0] as TextBox;
            TextBox firstname = parameters[1] as TextBox;
            TextBox lastname = parameters[2] as TextBox;
            TextBox mail = parameters[3] as TextBox;
            PasswordBox passwordBox = parameters[4] as PasswordBox;
            if (signUp != null)
                MessageBox.Show("כן זה עובד" + " " + cid.Text);
            signUp(cid.Text, firstname.Text, lastname.Text, mail.Text, passwordBox.Password);
        }
    }
}
