using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Shopping_system.View_Model;

namespace Shopping_system.View
{
    /// <summary>
    /// Interaction logic for HistoryByPriceUC.xaml
    /// </summary>
    public partial class HistoryByPriceUC : UserControl
    {
        public HistoryByPriceVM CurrentVm { get; set; }

        public HistoryByPriceUC()
        {
            InitializeComponent();
            CurrentVm = new HistoryByPriceVM();

            this.DataContext = CurrentVm;
        }
    }
}
