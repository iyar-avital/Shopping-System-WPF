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
    /// Interaction logic for FamilyList.xaml
    /// </summary>
    public partial class FamilyListUC : UserControl
    {
        public ProductVM productVM { get; set; }
        public FamilyListUC()
        {
            InitializeComponent();
            productVM = new ProductVM("family");
            this.DataContext = productVM;
        }
    }
}
