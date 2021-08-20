using Shopping_system.Tools;
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
    public class ProductFilterCommand : ICommand
    {
        public event Action<string, int?, Month?> filter;

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
            ComboBox dayCB = parameters[1] as ComboBox;
            ComboBox monthCB = parameters[2] as ComboBox;
            string product = (string)productCB.SelectedItem;
            int? day = (int?)dayCB.SelectedItem;
            Month? month = (Month?)monthCB.SelectedItem;

            try
            {
                if (filter != null)
                    filter(product, day, month);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
