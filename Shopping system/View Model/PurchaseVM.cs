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

namespace Shopping_system.View_Model
{
    public class PurchaseVM : INotifyPropertyChanged
    {
        Purchase purchase;
        Product product;
        QRcode qRcode;
        Store store;

        public event PropertyChangedEventHandler PropertyChanged;

        public PurchaseVM(Purchase p)
        {
            IBL bl = new BlIMP();
            purchase = p;
            qRcode = bl.getQRcode(p.qrCode);
            product = bl.getProduct(qRcode.pid);
            store = bl.getStore(qRcode.sid);
        }

        public PurchaseVM()
        {
            purchase = new Purchase();
        }

        public int prid
        {
            get { return purchase.prid; }
            set { purchase.prid = value;
                  PropertyChanged(this, new PropertyChangedEventArgs("prid")); }
        }

        public string cid
        {
            get { return purchase.cid; }
            set { purchase.cid = value; 
                  PropertyChanged(this, new PropertyChangedEventArgs("cid")); }
        }

        public string qrCode
        {
            get { return purchase.qrCode; }
            set
            {
                purchase.qrCode = value;
                PropertyChanged(this, new PropertyChangedEventArgs("qrCode"));
            }
        }

        public int quantity
        {
            get { return purchase.quantity; }
            set
            {
                purchase.quantity = value;
                PropertyChanged(this, new PropertyChangedEventArgs("quantity"));
            }
        }

        public DateTime date
        {
            get { return purchase.date; }
            set
            {
                purchase.date = value;
                PropertyChanged(this, new PropertyChangedEventArgs("date"));
            }
        }

        public string dateStr
        {
            get { return purchase.date.ToString("dd/MM/yyy"); }
            set { }
        }

        public int pid
        {
            get { return product.pid; }
            set
            {
                product.pid = value;
                PropertyChanged(this, new PropertyChangedEventArgs("pid"));
            }
        }

        public string productName
        {
            get { return product.productName; }
            set
            {
                product.productName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("productName"));
            }
        }

        public string imagePath
        {
            get { return product.imagePath; }
            set
            {
                product.imagePath = value;
                PropertyChanged(this, new PropertyChangedEventArgs("imagePath"));
            }
        }

        public string StoreNmae
        { 
            get { return store.storeName; }
            set { store.storeName =value;
                  PropertyChanged(this, new PropertyChangedEventArgs("storeName")); }
        }

        public string city
        {
            get { return store.city; }
            set
            {
                store.city = value;
                PropertyChanged(this, new PropertyChangedEventArgs("city"));
            }
        }
    }
}
