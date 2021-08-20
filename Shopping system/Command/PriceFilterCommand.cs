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
    public class PriceFilterCommand : ICommand
    {
        public event Action<double, double, int?, Month?> filter;

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
            TextBox startPriceTB = parameters[0] as TextBox;
            TextBox endPriceTB = parameters[1] as TextBox;
            ComboBox dayCB = parameters[2] as ComboBox;
            ComboBox monthCB = parameters[3] as ComboBox;
            double startP = Convert.ToDouble(startPriceTB.Text);
            double endP = Convert.ToDouble(endPriceTB.Text);
            int? day = (int?)dayCB.SelectedItem;
            Month? month = (Month?)monthCB.SelectedItem;

            try
            {
                if (filter != null)
                    filter(startP, endP, day, month);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
