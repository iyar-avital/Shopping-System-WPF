using BE;
using BL;
using LiveCharts;
using LiveCharts.Wpf;
using Shopping_system.View_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
namespace Shopping_system.Tools
{
    public static class ExtendForAdd
    {
        #region addPurchase 

        public static ObservableCollection<string> GetProductNames()
        {
            ObservableCollection<string> Result = new ObservableCollection<string>();
            IBL bl = new BlIMP();
            List<Product> products = bl.getProducts();
            foreach (var pr in products)
            {
                Result.Add(pr.productName);
            }
            return new ObservableCollection<string>(Result.Distinct());
        }

        public static ObservableCollection<string> GetCityStoreNames()
        {
            ObservableCollection<string> Result = new ObservableCollection<string>();
            IBL bl = new BlIMP();
            List<Store> stores = bl.getStores();
            foreach (var item in stores)
                Result.Add(item.city + "-" + item.storeName);
            return new ObservableCollection<string>(Result.Distinct());
        }
        public static Product getProductByDetails(string productname)
        {
            IBL bl = new BlIMP();
            return bl.getProducts(p => p.productName == productname).FirstOrDefault();
        }
        public static QRcode getQRByDetails(int productID, string city, string storeName)
        {
            IBL bl = new BlIMP();
            Store store = bl.getStores(s => s.city == city && s.storeName == storeName).FirstOrDefault();
            QRcode qr = bl.getQRcodes(q => q.pid == productID && q.sid == store.sid).FirstOrDefault();
            return qr;
        }

        public static QRcode getQRByDetails(int productID, string city, string storeName, double price)
        {
            IBL bl = new BlIMP();
            Store store = bl.getStores(s => s.city == city && s.storeName == storeName).FirstOrDefault();
            List<QRcode> qrS = bl.getQRcodes(q => q.pid == productID && q.sid == store.sid);
            if (qrS.Count == 1)
                return qrS[0];
            int id = idGenerator.getqrID();
            QRcode qr = new QRcode(id.ToString(), productID, store.sid, 50, price);
            if (qrS.Count == 0)//this product doesnt have qrCode for this store yet 
            {
                bl.addQRcode(qr);
            }
            return qr;
        }
        #endregion
    }
}
