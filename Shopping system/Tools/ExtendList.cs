using BE;
using BL;
using Shopping_system.View_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.Tools
{
    public static class ExtendList
    {
        public static ObservableCollection<PurchaseVM> GetPurchaseVM(this List<Purchase> purchases)
        {
            ObservableCollection<PurchaseVM> Result = new ObservableCollection<PurchaseVM>();
            foreach (var item in purchases)
            {
                Result.Add(item.ConvertToVM());
            }

            return Result;
        }

        public static double getPrice(this List<Purchase> shopping)
        {
            IBL bl = new BlIMP();
            double Result = 0;
            QRcode qRcode;
            foreach (var item in shopping)
            {
                qRcode = bl.getQRcode(item.qrCode);
                Result += item.quantity * qRcode.price;
            }

            return Result;
        }

        public static ObservableCollection<BuyVM> GetBuyVM(this List<Purchase> purchases)
        {
            IBL bl = new BlIMP();
            var Result = purchases.GroupBy(item => new { item.date, bl.getQRcode(item.qrCode).sid }).
                Select(item => new BuyVM(item.Key.date, item.Key.sid)).ToList();

            return new ObservableCollection<BuyVM>(Result);
        }
    }
}
