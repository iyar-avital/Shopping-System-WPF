using BE;
using BL;
using Shopping_system.Command;
using Shopping_system.Model;
using Shopping_system.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Shopping_system.View_Model
{
    public class ShoppingDataVM : BaseVM
    {
        public PurchaseModel currentModel { get; set; }
        public ObservableCollection<PurchaseVM> PurchaseVMs { get; set; }
        public AddCommand addPurchaseCommand { get; set; }
        public BrowseCommand BrowseCommand { get; set; }
        public FilterCommand FilterCommand { get; set; }
        public RestoreCommand RestoreCommand { get; set; }
        public string ImagePath { get; set; }

        public ShoppingDataVM()
        {
            currentModel = new PurchaseModel();
            addPurchaseCommand = new AddCommand(execute, canExecute);
            BrowseCommand = new BrowseCommand();
            BrowseCommand.browse += browse;
            FilterCommand = new FilterCommand();
            FilterCommand.filter += filterData;
            RestoreCommand = new RestoreCommand();
            RestoreCommand.restore += restoreData;

            PurchaseVMs = currentModel.purchases.GetPurchaseVM();
            PurchaseVMs.CollectionChanged += Purchases_CollectionChanged;
        }

        #region Command
        public void browse(object parameter)
        {
            execute(parameter);
        }

        void execute(object o)
        {
            object[] parameters = (object[])o;
            ComboBox locationCB = parameters[0] as ComboBox;
            ComboBox productCB = parameters[1] as ComboBox;
            TextBox quantityTB = parameters[2] as TextBox;
            TextBox priceTB = parameters[3] as TextBox;
            DatePicker dateDP = parameters[4] as DatePicker;

            if (locationCB.SelectedItem != null && productCB.SelectedItem != null)
            {
                string location = (string)locationCB.SelectedItem;
                string productName = (string)productCB.SelectedItem;
                int quantity = Convert.ToInt32(quantityTB.Text);
                double price = Convert.ToDouble(priceTB.Text);
                DateTime date = (DateTime)dateDP.SelectedDate;
                string[] tokens = location.Split('-');
                string city = tokens[0];
                string store = tokens[1];

                IBL bl = new BlIMP();
                Product product;
                Purchase p;
                try
                {
                    product = ExtendForAdd.getProductByDetails(productName);
                    QRcode qr = ExtendForAdd.getQRByDetails(product.pid, city, store, price);
                    if (qr.price !=price)
                    {
                        MessageBox.Show("The product price has been change");
                    }
                    p = new Purchase(idGenerator.getPurchaseID(), App.currents.CurrentUser.cid, qr.qrCode, Convert.ToInt32(quantity), date);
                    PurchaseVMs.Add(new PurchaseVM(p));
                    bl.addPurchase(p);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else
            {
                int quantity = Convert.ToInt32(quantityTB.Text);
                double price = Convert.ToDouble(quantityTB.Text);
                DateTime date = (DateTime)dateDP.SelectedDate;
                FireBaseHandler.chechQR(ImagePath, quantity, price, date, App.currents.CurrentUser.cid);
            }
        }

        bool canExecute(object o)
        {
            return true;
        }
        #endregion

        #region filter
        private void filterData(string product, string store, string date)
        {
            restoreData();
            allPurchaseVMs = new ObservableCollection<PurchaseVM>(PurchaseVMs);
            PurchaseVMs.filterDatabyParameter(product, store, date);
        }

        private void restoreData()
        {
            if (allPurchaseVMs == null)
                return;
            PurchaseVMs.AddAll(allPurchaseVMs);
        }
        #endregion

        #region hide
        private void Purchases_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                //currentModel.purchases.Add(new Purchase());
            }

            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                
            }
        }

        #endregion

        #region add purchase 
        public ObservableCollection<string> AllprodctNames
        {
            get { return ExtendForAdd.GetProductNames(); }
            set { }
        }
        public ObservableCollection<string> CityStoreNames
        {
            get { return ExtendForAdd.GetCityStoreNames(); }
            set { }
        }
        #endregion

        public ObservableCollection<string> ProductNames
        { 
            get { return PurchaseVMs.GetDistinctProducts(); }
            set { }
        }
        public ObservableCollection<string> StoreNames
        {
            get { return PurchaseVMs.GetDistinctStores(); }
            set { }
        }
        public ObservableCollection<string> Dates
        {
            get { return PurchaseVMs.GetDistinctDates(); }
            set { }
        }

        public ObservableCollection<PurchaseVM> allPurchaseVMs { get; set; }

        public string productLabel { get; set; }
    }
}
