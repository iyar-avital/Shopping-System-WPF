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
using System.Windows.Shapes;

namespace Shopping_system.View
{
    /// <summary>
    /// Interaction logic for MessageBoxCustom.xaml
    /// </summary>
    public partial class MessageBoxCustom : Window
    {
        public MessageBoxVM messageBox { get; set; }
        public MessageBoxCustom(string Message, MessageType Type)
        {
            InitializeComponent();
            messageBox = new MessageBoxVM(Message, Type);

            this.DataContext = messageBox;
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
