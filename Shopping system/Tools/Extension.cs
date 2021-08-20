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
    public static class Extension
    {
        public static PurchaseVM ConvertToVM(this Purchase purchase)
        {
            return new PurchaseVM(purchase);
        }

        public static void createDB(this IBL bl)
        {
            Costumer c1 = new Costumer("Iyar", "Avital", "323075499", "iyaravital@gmail.com", "blabla5");
            bl.addCostumer(c1);
            bl.addProduct(new Product(123, "milk", "Fresh milk, 5% and lactose deficient", "/images/milk.jpg"));
            bl.addProduct(new Product(124, "bread", "Bread five grains", " /images/bread.png"));
            bl.addStore(new Store(5644, "Rami levy", "Jerusalem"));
            bl.addStore(new Store(5651, "Rami levy", "Nazareth"));
            bl.addQRcode(new QRcode("8885", 123, 5644, 52, 5));
            bl.addQRcode(new QRcode("8886", 124, 5644, 20, 7.5));
            bl.addQRcode(new QRcode("8887", 124, 5651, 32, 7));
            bl.addPurchase(new Purchase(4556, "323075499", "8885", 3, DateTime.Now));
            bl.addPurchase(new Purchase(4517, "323075499", "8886", 4, DateTime.Now));
            bl.addPurchase(new Purchase(4589, "323075499", "8887", 1, DateTime.Now));
        }

    }
}
