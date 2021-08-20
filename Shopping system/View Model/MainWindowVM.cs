using Shopping_system.Tools;
using Shopping_system.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Shopping_system.View_Model
{
    public class MainWindowVM : BaseVM
    {
        public MainWindowVM()
        {
            Currents.chanseView(new LoginUC());
        }
    }
}
