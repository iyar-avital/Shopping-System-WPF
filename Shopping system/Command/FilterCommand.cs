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
    public class FilterCommand : ICommand
    {
        public event Action<string, string, string> filter;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            object[] parameters = (object[])parameter;
            ComboBox productCB = parameters[0] as ComboBox;
            ComboBox storeCB = parameters[1] as ComboBox;
            ComboBox dateCB = parameters[2] as ComboBox;
            string product = (string)productCB.SelectedItem;
            string store = (string)storeCB.SelectedItem;
            string date = (string)dateCB.SelectedItem;

            try
            { 
                if (filter != null)
                   filter(product, store, date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
