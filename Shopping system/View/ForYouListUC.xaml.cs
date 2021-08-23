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
    /// Interaction logic for ForYouListUC.xaml
    /// </summary>
    public partial class ForYouListUC : UserControl
    {
        public ProductVM productVM { get; set; }
        public ForYouListUC()
        {
            InitializeComponent();
            productVM = new ProductVM("you");

            this.DataContext = productVM;
        }
    }
}
