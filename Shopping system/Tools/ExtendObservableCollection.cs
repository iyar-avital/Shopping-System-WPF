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
    public static class ExtendObservableCollection
    {

        public static ObservableCollection<string> GetDistinctProducts(this ObservableCollection<PurchaseVM> purchases)
        {
            List<string> Result = new List<string>();
            foreach (var item in purchases)
            {
                Result.Add(item.productName);
            }
            return new ObservableCollection<string>(Result.Distinct());
        }

        public static ObservableCollection<string> GetDistinctProducts(this ObservableCollection<BuyVM> shoppings)
        {
            List<string> Result = new List<string>();
            foreach (var item in shoppings)
            {
                for (int i = 0; i < item.shopping.Count; i++)
                {
                    IBL bl = new BlIMP();
                    QRcode qRcode = bl.getQRcode(item.shopping[i].qrCode);
                    Product product = bl.getProduct(qRcode.pid);
                    Result.Add(product.productName);
                }
            }
            return new ObservableCollection<string>(Result.Distinct());
        }

        public static ObservableCollection<string> GetDistinctStores(this ObservableCollection<PurchaseVM> purchases)
        {
            List<string> Result = new List<string>();
            foreach (var item in purchases)
            {
                Result.Add(item.StoreNmae);
            }
            return new ObservableCollection<string>(Result.Distinct());
        }

        public static ObservableCollection<string> GetDistinctStores(this ObservableCollection<BuyVM> shopping)
        {
            List<string> Result = new List<string>();
            foreach (var item in shopping)
            {
                Result.Add(item.storeName);
            }
            return new ObservableCollection<string>(Result.Distinct());
        }


        public static ObservableCollection<string> GetDistinctDates(this ObservableCollection<BuyVM> shopping)
        {
            List<string> Result = new List<string>();
            foreach (var item in shopping)
            {
                Result.Add(item.date.ToString("dd/MM/yyyy"));
            }
            return new ObservableCollection<string>(Result.Distinct());
        }

        public static ObservableCollection<string> GetDistinctDates(this ObservableCollection<PurchaseVM> purchases)
        {
            List<string> Result = new List<string>();
            foreach (var item in purchases)
            {
                Result.Add(item.dateStr);
            }
            return new ObservableCollection<string>(Result.Distinct());
        }

        public static void AddAll<T>(this ObservableCollection<T> purchases, ObservableCollection<T> toCoptPurchases)
        {
            purchases.Clear();
            foreach (var item in toCoptPurchases)
            {
                purchases.Add(item);
            }
        }

        public static Dictionary<string, int> ConvertToDictionary(this ObservableCollection<BuyVM> shopping, string p)
        {
            Dictionary<string, int> Result = new Dictionary<string, int>();

            Dictionary<int, int> numProduct = new Dictionary<int, int>();
            foreach (var item in shopping)
            {
                int count = 0;
                for (int i = 0; i < item.shopping.Count; i++)
                {
                    IBL bl = new BlIMP();
                    QRcode qRcode = bl.getQRcode(item.shopping[i].qrCode);
                    Product product = bl.getProduct(qRcode.pid);
                    if (product.productName == p)
                        count += item.shopping[i].quantity;
                }

                if (numProduct.ContainsKey(item.date.Month))
                    numProduct[item.date.Month] += count;
                else
                    numProduct.Add(item.date.Month, count);
            }


            Result = numProduct.ToDictionary(item => ((Month)item.Key).ToString(), item => item.Value); 
            return Result;
        }

        public static Dictionary<string, int> ConvertStoreToDictionary(this ObservableCollection<BuyVM> shopping, string s)
        {
            Dictionary<string, int> Result = new Dictionary<string, int>();

            Dictionary<int, int> numProduct = new Dictionary<int, int>();
            foreach (var item in shopping)
            {
                int count = 0;
                for (int i = 0; i < item.shopping.Count; i++)
                {
                    IBL bl = new BlIMP();
                    QRcode qRcode = bl.getQRcode(item.shopping[i].qrCode);
                    Store store = bl.getStore(qRcode.sid);
                    if (store.storeName == s)
                        count += item.shopping[i].quantity;
                }

                if (numProduct.ContainsKey(item.date.Month))
                    numProduct[item.date.Month] += count;
                else
                    numProduct.Add(item.date.Month, count);
            }


            Result = numProduct.ToDictionary(item => ((Month)item.Key).ToString(), item => item.Value);
            return Result;
        }

        public static Dictionary<string, int> ConvertPriceToDictionary(this ObservableCollection<BuyVM> shopping, double p1, double p2)
        {
            Dictionary<string, int> Result = new Dictionary<string, int>();

            Dictionary<int, int> numProduct = new Dictionary<int, int>();
            foreach (var item in shopping)
            {
                if (item.price > p1 && item.price < p2)
                {
                    if (numProduct.ContainsKey(item.date.Month))
                        numProduct[item.date.Month] += 1;
                    else
                        numProduct.Add(item.date.Month, 1);
                }     
            }

            Result = numProduct.ToDictionary(item => ((Month)item.Key).ToString(), item => item.Value);
            return Result;
        }

    }
}
