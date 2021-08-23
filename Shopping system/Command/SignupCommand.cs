using Shopping_system.Tools;
using Shopping_system.View;
using Shopping_system.View_Model;
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
            try
            {
                if (signUp != null)
                    signUp(cid.Text, firstname.Text, lastname.Text, mail.Text, passwordBox.Password);
                new MessageBoxCustom("You have successfully logged in to the system", MessageType.Success).ShowDialog();
                Currents.chanseView(new Menu());               
            }
            catch (Exception ex)
            {
                new MessageBoxCustom(ex.Message, MessageType.Error).ShowDialog();              
            }
        }
    }
}
