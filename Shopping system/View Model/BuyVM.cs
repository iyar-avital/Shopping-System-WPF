using BE;
using BL;
using Shopping_system.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.View_Model
{
    public class BuyVM
    {
        public List<Purchase> shopping { get; set; }

        public DateTime date { get; set; }

        public int numProducts 
        { 
            get { return shopping.Sum(item => item.quantity); }
            private set { }
        }

        public double price 
        { 
            get { return shopping.getPrice(); }
            private set { }
        }

        public string storeName { get; set; }

        public string city { get; set; }

        public BuyVM(DateTime _date, int store)
        {
            IBL bl = new BlIMP();
            date = _date;
            Store s = bl.getStore(store);
            storeName = s.storeName;
            city = s.city;
            shopping = bl.getPurchases(item => /*item.cid == id &&*/ item.date == _date && bl.getQRcode(item.qrCode).sid == store);
        }
    }
}
