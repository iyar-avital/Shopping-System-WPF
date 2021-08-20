using BE;
using Shopping_system.View_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Shopping_system.Tools
{
    public class Currents : INotifyPropertyChanged
    {
        public static Stack<FrameworkElement> GoBack;
        public Currents()
        {
            GoBack = new Stack<FrameworkElement>();
        }

        private Costumer currentUser;
        public Costumer CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                OnPropertyRaised("currentUser");
            }
        }

        private FrameworkElement currentView;
        public FrameworkElement CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropertyRaised("currentView");
            }
        }

        private FrameworkElement subCurrentView;
        public FrameworkElement SubCurrentView
        {
            get { return subCurrentView; }
            set
            {
                subCurrentView = value;
                OnPropertyRaised("subCurrentView");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyRaised(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public static bool isCostumer()
        {
            return App.currents.CurrentUser != null;
        }

        public static void chanseView(FrameworkElement view)
        {
            GoBack.Push(App.currents.CurrentView);
            App.currents.CurrentView = view;
        }

        public static void chanseSubView(FrameworkElement view)
        {
            App.currents.SubCurrentView = view;
        }

        public static void goBack()
        {
            App.currents.CurrentView = GoBack.Pop();
        }
    }
}
