using BE;
using Shopping_system.Tools;
using Shopping_system.View_Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Shopping_system
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Currents currents { get; set;}

        public App()
        {
            currents = new Currents();
        }
    }
}
