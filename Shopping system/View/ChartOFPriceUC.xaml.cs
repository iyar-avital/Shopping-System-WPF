using LiveCharts;
using LiveCharts.Wpf;
using Shopping_system.View_Model;
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

namespace Shopping_system.View
{
    /// <summary>
    /// Interaction logic for ChartOFPriceUC.xaml
    /// </summary>
    public partial class ChartOFPriceUC : UserControl
    {
        public ChartPriceVM currentVM { get; set; }
        public ChartOFPriceUC(Dictionary<string, int> d, double p1, double p2)
        {
            InitializeComponent();
            currentVM = new ChartPriceVM(d, p1, p2);
          
            this.DataContext = currentVM;
        }
    }
}
