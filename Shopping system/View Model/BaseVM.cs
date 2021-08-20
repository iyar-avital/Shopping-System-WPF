using Shopping_system.Command;
using Shopping_system.Tools;
using Shopping_system.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shopping_system.View_Model
{
    public abstract class BaseVM : INotifyPropertyChanged
    {

        public BaseVM() { }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyRaised(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #region commands
        public ICommand DisplayLoginView
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    Currents.chanseView(new LoginUC());
                    App.currents.CurrentUser = null;
                    Currents.GoBack.Clear();
                });
            }
        }

        public ICommand DisplaySignUpView
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    Currents.chanseView(new SignupUC());
                });
            }
        }

        public ICommand DisplaySelection
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    Currents.chanseView(new SelectionUC());
                });
            }
        }

        public ICommand DisplayAllPurchase
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    Currents.chanseView(new ShoppingDataUC());
                    Currents.chanseSubView(new HistoryByProductUC());                   
                });
            }
        }

        public ICommand DisplayAssociationRules
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    Currents.chanseView(new AssocRulesUC());
                });
            }
        }

        public ICommand DisplayFilterSelection
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    Currents.chanseView(new SelectionUC());
                });
            }
        }

        public ICommand DisplayHistoryByProduct
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    Currents.chanseSubView(new HistoryByProductUC());
                });
            }
        }

        public ICommand DisplayHistoryByStore
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    Currents.chanseSubView(new HistoryByStoreUC());
                });
            }
        }

        public ICommand DisplayHistoryByPrice
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    Currents.chanseSubView(new HistoryByPriceUC());
                });
            }
        }

        public ICommand GoBack
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    if (Currents.GoBack.Count != 0)
                        Currents.goBack();
                });                
            }
        }

        //public ICommand Logout
        //{
        //    get
        //    {
        //        return new BaseCommand(delegate ()
        //        {
        //            App.currents.CurrentView = new LoginUC();
        //            App.currents.GoBack.Clear();
        //            App.currents.CurrentUser = null;
        //        });
        //    }
        //}

        //public ICommand LastPurchase
        //{
        //    get
        //    {
        //        return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new LastPurchaseVM(); });
        //    }
        //}

        //public ICommand HistoryByShop
        //{
        //    get
        //    {
        //        return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new HistoryByShopVM(); });
        //    }
        //}
        //public ICommand HistoryByItem
        //{
        //    get
        //    {
        //        return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new HistoryByItemVM(); });
        //    }
        //}

        //public ICommand HistoryBySCart
        //{
        //    get
        //    {
        //        return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new HistoryBySCartVM(); });
        //    }
        //}

        //public ICommand PriceComparison
        //{
        //    get
        //    {
        //        return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new PriceComparisonVM(); });
        //    }
        //}

        //public ICommand CreateCart
        //{
        //    get
        //    {
        //        return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new CreateCartVM(); });
        //    }
        //}
        #endregion

    }
}
