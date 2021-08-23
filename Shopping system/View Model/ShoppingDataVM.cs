using BE;
using BL;
using Shopping_system.Command;
using Shopping_system.Model;
using Shopping_system.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Shopping_system.View_Model
{
    public class ShoppingDataVM : BaseVM, INotifyPropertyChanged
    {
        public PurchaseModel currentModel { get; set; }
        public ObservableCollection<PurchaseVM> PurchaseVMs { get; set; }
        public AddCommand addPurchaseCommand { get; set; }
        public RemoveCommand removePurchaseCommand { get; set; }
        public BrowseCommand BrowseCommand { get; set; }
        public FilterCommand FilterCommand { get; set; }
        public RestoreCommand RestoreCommand { get; set; }
        public PurchaseBasicVM PurchaseBasic { get; set; }

        public ShoppingDataVM()
        {
            PurchaseBasic = new PurchaseBasicVM();

            currentModel = new PurchaseModel();
            addPurchaseCommand = new AddCommand(execute, canExecute);
            removePurchaseCommand = new RemoveCommand(executeRemove, canExecute);
            BrowseCommand = new BrowseCommand();
            BrowseCommand.browse += browse;
            FilterCommand = new FilterCommand();
            FilterCommand.filter += filterData;
            RestoreCommand = new RestoreCommand();
            RestoreCommand.restore += restoreData;

            PurchaseVMs = currentModel.purchases.GetPurchaseVM();
            PurchaseVMs.CollectionChanged += Purchases_CollectionChanged;

            CityStoreNames = ExtendForAdd.GetCityStoreNames();
            ProductNames = PurchaseVMs.GetDistinctProducts();
            StoreNames = PurchaseVMs.GetDistinctStores();
            Dates = PurchaseVMs.GetDistinctDates();
        }

        #region Command
        public void browse(object parameter)
        {
            execute(parameter);
        }

     
        bool canExecute(object o)
        {
            return true;
        }

        void  executeRemove(object o)
        {
            if (o == null)
                throw new Exception("The system was busy. try again later");
            int purchaseID = Convert.ToInt32(o);
            currentModel.Remove(purchaseID);
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
                List<PurchaseVM> vM = new List<PurchaseVM>();
                foreach (var item in PurchaseVMs)
                {
                    if (!ProductNames.Contains(item.productName))
                        vM.Add(item);
                }

                foreach (var item in vM)
                {
                    string _new = item.city + "-" + item.StoreNmae;
                    CityStoreNames.Add(_new);

                    _new = item.productName;
                    ProductNames.Add(_new);

                    _new = item.StoreNmae;
                    StoreNames.Add(_new);

                    _new = item.dateStr;
                    Dates.Add(_new);
                }
            }

            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                
            }
        }

        void execute(object o)
        {
            try
            {
                IBL bl = new BlIMP();

                if (PurchaseBasic.fillAllFields() != true)
                    throw new Exception("Please fill all fields.");

                if (PurchaseBasic.fillByDetails())
                {
                    string[] tokens = PurchaseBasic.Location.Split('-');
                    string city = tokens[0];
                    string store = tokens[1];

                    Product product;
                    Purchase p;
                    product = ExtendForAdd.getProductByDetails(PurchaseBasic.Product);
                    QRcode qr = ExtendForAdd.getQRByDetails(product.pid, city, store, Convert.ToDouble(PurchaseBasic.Price));
                    p = new Purchase(idGenerator.getPurchaseID(), App.currents.CurrentUser.cid, qr.qrCode, Convert.ToInt32(PurchaseBasic.Quantity), PurchaseBasic.Date);
                    PurchaseVMs.Add(new PurchaseVM(p));
                    bl.addPurchase(p);

                    string currentPrice = PurchaseBasic.Price;
                    PurchaseBasic.clear();

                    if (qr.price.ToString() != currentPrice)
                    {
                        throw new Exception("The product price has been changed");
                    }
                }

                else
                {
                    Purchase p = FireBaseHandler.chechQR(PurchaseBasic.ImagePath, Convert.ToInt32(PurchaseBasic.Quantity), Convert.ToDouble(PurchaseBasic.Price), PurchaseBasic.Date, App.currents.CurrentUser.cid);
                    PurchaseVMs.Add(new PurchaseVM(p));
                    bl.addPurchase(p);
                    string currentPrice = PurchaseBasic.Price;
                    PurchaseBasic.clear();
                    if (bl.getQRcode(p.qrCode).price.ToString() != currentPrice)
                    {
                        throw new Exception("The product price has been changed");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        #endregion

        #region add purchase Lists
        public ObservableCollection<string> CityStoreNames { get; set; }
        #endregion

        public ObservableCollection<string> ProductNames { get; set; }
        public ObservableCollection<string> StoreNames { get; set; }
        public ObservableCollection<string> Dates { get; set; }
        public ObservableCollection<PurchaseVM> allPurchaseVMs { get; set; }

    }
}
