using Shopping_system.Command;
using Shopping_system.Model;
using Shopping_system.Tools;
using Shopping_system.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.View_Model
{
    public class HistoryByPriceVM : BaseVM
    {
        public HistoryModel currentModel { get; set; }
        public ObservableCollection<BuyVM> shoppingVMs { get; set; }
        public PriceFilterCommand FilterCommand { get; set; }
        public ChartPriceCommand ChartCommand { get; set; }

        public HistoryByPriceVM()
        {
            currentModel = new HistoryModel();
            FilterCommand = new PriceFilterCommand();
            FilterCommand.filter += filterData;
            ChartCommand = new ChartPriceCommand();
             ChartCommand.graphical += convertToChart;
            shoppingVMs = currentModel.purchases.GetBuyVM();
        }

        #region filter
        private void filterData(double start, double end, int? day, Month? month)
        {
            restoreData();
            allShoppingVMs = new ObservableCollection<BuyVM>(shoppingVMs);
            shoppingVMs.filterDatabyPriceParameter(start, end, day, month);
        }

        private void restoreData()
        {
            if (allShoppingVMs == null)
                return;
            shoppingVMs.AddAll(allShoppingVMs);
        }
        #endregion

        #region chart
        public void convertToChart(double p1, double p2)
        {
            Currents.chanseSubView(new ChartOFPriceUC(shoppingVMs.ConvertPriceToDictionary(p1, p2), p1, p2));
        }
        #endregion

        public ObservableCollection<string> StoreNames
        {
            get { return shoppingVMs.GetDistinctStores(); }
            set { }
        }
        public List<Month> Months
        {
            get { return DatesDB.getMonth(); }
            set { }
        }

        public List<int> Days
        {
            get { return DatesDB.getDays(); }
            set { }
        }

        public ObservableCollection<BuyVM> allShoppingVMs { get; set; }
    }
}

