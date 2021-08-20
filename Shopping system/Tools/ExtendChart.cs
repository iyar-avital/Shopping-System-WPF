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
    public static class ExtendChart
    {
        public static SeriesCollection ConvertToSeriesCollection(this Dictionary<string, int> collection)
        {
            SeriesCollection PieChartSeriesCollection = new SeriesCollection();
            foreach (var pair in collection)
            {
                PieChartSeriesCollection.Add(new PieSeries { Title = $"{pair.Value} ({pair.Key})", Values = new ChartValues<int> { pair.Value }, DataLabels = true, Fill = (System.Windows.Media.Brush)new BrushConverter().ConvertFrom(idGenerator.getColorID()) });
            }
            return PieChartSeriesCollection;
        }

        public static void filterDatabyParameter(this ObservableCollection<PurchaseVM> purchases, string p, string s, string d)
        {
            bool toDelete;
            for (int i = 0; i < purchases.Count; i++)
            {
                toDelete = false;
                if (p != null && p != purchases[i].productName)
                    toDelete = true;
                if (s != null && s != purchases[i].StoreNmae)
                    toDelete = true;
                if (d != null && d != purchases[i].dateStr)
                    toDelete = true;

                if (toDelete)
                {
                    purchases.RemoveAt(i);
                    i--;
                }
            }
        }

        public static void filterDatabyProductParameter(this ObservableCollection<BuyVM> buys, string p, int? d, Month? m)
        {
            bool toDelete;
            bool productExsist;
            for (int i = 0; i < buys.Count; i++)
            {
                toDelete = false;
                productExsist = false;
                if (p != null && buys[i].shopping.Count > 0)
                {
                    for (int j = 0; j < buys[i].shopping.Count; j++)
                    {
                        IBL bl = new BlIMP();
                        QRcode qRcode = bl.getQRcode((buys[i].shopping)[j].qrCode);
                        Product product = bl.getProduct(qRcode.pid);
                        if (p != null && product.productName == p)
                        {
                            productExsist = true;
                            break;
                        }
                    }
                    toDelete = productExsist ? false : true;
                }

                if (d != null && d != Convert.ToInt32(buys[i].date.ToString("dd")))
                    toDelete = true;
                if (m != null && (int)m != Convert.ToInt32(buys[i].date.ToString("MM")))
                    toDelete = true;

                if (toDelete)
                {
                    buys.RemoveAt(i);
                    i--;
                }
            }
        }

        public static void filterDatabyStoreParameter(this ObservableCollection<BuyVM> buys, string s, int? d, Month? m)
        {
            bool toDelete;
            for (int i = 0; i < buys.Count; i++)
            {
                toDelete = false;
                if (s != null && s != buys[i].storeName)
                    toDelete = true;
                if (d != null && d != Convert.ToInt32(buys[i].date.ToString("dd")))
                    toDelete = true;
                if (m != null && (int)m != Convert.ToInt32(buys[i].date.ToString("MM")))
                    toDelete = true;

                if (toDelete)
                {
                    buys.RemoveAt(i);
                    i--;
                }
            }
        }

        public static void filterDatabyPriceParameter(this ObservableCollection<BuyVM> buys, double s, double e, int? d, Month? m)
        {
            bool toDelete;
            for (int i = 0; i < buys.Count; i++)
            {
                toDelete = false;
                if (buys[i].price < s || buys[i].price > e)
                    toDelete = true;
                if (d != null && d != Convert.ToInt32(buys[i].date.ToString("dd")))
                    toDelete = true;
                if (m != null && (int)m != Convert.ToInt32(buys[i].date.ToString("MM")))
                    toDelete = true;

                if (toDelete)
                {
                    buys.RemoveAt(i);
                    i--;
                }
            }
        }

        public static List<string> color
        {
            get
            {
                return new List<string>() { "#FFC93C", "#07689F", "#40A8C4", "#A2D5F2", "#FFF47D", "#FAFCC2" };
            }
            set { }
        }
    }
}
