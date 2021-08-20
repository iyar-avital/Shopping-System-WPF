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
    public class ChartPriceCommand : ICommand
    {
        public event Action<double, double> graphical;

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

            double startPrice = Convert.ToDouble(startPriceTB.Text);
            double endPrice = Convert.ToDouble(endPriceTB.Text);

            try
            {
                if (graphical != null)
                    graphical(startPrice, endPrice);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
