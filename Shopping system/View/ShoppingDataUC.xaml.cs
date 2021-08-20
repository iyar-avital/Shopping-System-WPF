using BL;
using Shopping_system.Tools;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace Shopping_system.View
{
    /// <summary>
    /// Interaction logic for PurchaseUC.xaml
    /// </summary>
    public partial class ShoppingDataUC : UserControl
    {

        private ShoppingDataVM CurrentVm;
        public static string qrUML { get; set; }

        public ShoppingDataUC()
        {
            InitializeComponent();
            CurrentVm = new ShoppingDataVM();

            this.DataContext = CurrentVm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QRsp.Visibility = Visibility.Visible;
            Detailsp.Visibility = Visibility.Collapsed;
            Qrbutton.Opacity = 1;
            Detailsbutton.Opacity = 0.5;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            QRsp.Visibility = Visibility.Collapsed;
            Detailsp.Visibility = Visibility.Visible;
            Qrbutton.Opacity = 0.5;
            Detailsbutton.Opacity = 1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            addGrid.Visibility = Visibility.Visible;
            AddButton.Visibility = Visibility.Collapsed;
            closeAddButton.Visibility = Visibility.Visible;
        }

        private void closeAddButton_Click(object sender, RoutedEventArgs e)
        {
            addGrid.Visibility = Visibility.Collapsed;
            AddButton.Visibility = Visibility.Visible;
            closeAddButton.Visibility = Visibility.Collapsed;
        }

        private void Browse_ButtonClick(object sender, RoutedEventArgs e)
        {
            IBL bl = new BlIMP();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "C:\\Users\\iyar\\Desktop\\QrCodes";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedFileName = dlg.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                CurrentVm.ImagePath = selectedFileName;
                string[] result = selectedFileName.Split('\\');
                CurrentVm.productLabel = result[7];
            }
        }
    }
}
