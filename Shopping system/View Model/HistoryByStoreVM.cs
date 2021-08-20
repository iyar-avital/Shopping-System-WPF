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
    public class HistoryByStoreVM : BaseVM
    {
        public HistoryModel currentModel { get; set; }
        public ObservableCollection<BuyVM> shoppingVMs { get; set; }
        public StoreFilterCommand FilterCommand { get; set; }
        public ChartCommand ChartCommand { get; set; }

        public HistoryByStoreVM()
        {
            currentModel = new HistoryModel();
            FilterCommand = new StoreFilterCommand();
            FilterCommand.filter += filterData;
            ChartCommand = new ChartCommand();
            ChartCommand.graphical += convertToChart;
            shoppingVMs = currentModel.purchases.GetBuyVM();
        }

        #region filter
        private void filterData(string store, int? day, Month? month)
        {
            restoreData();
            allShoppingVMs = new ObservableCollection<BuyVM>(shoppingVMs);
            shoppingVMs.filterDatabyStoreParameter(store, day, month);
        }

        private void restoreData()
        {
            if (allShoppingVMs == null)
                return;
            shoppingVMs.AddAll(allShoppingVMs);
        }
        #endregion

        #region chart
        public void convertToChart(string s)
        {
            Currents.chanseSubView(new ChartUC(shoppingVMs.ConvertStoreToDictionary(s), s));
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

