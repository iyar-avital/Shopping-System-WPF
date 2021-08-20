using LiveCharts;
using Shopping_system.Model;
using Shopping_system.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.View_Model
{
    public class ChartPriceVM : BaseVM
    {
        public ChartModel currentModel { get; set; }
        public double startPrice { get; set; }
        public double endPrice { get; set; }
        public SeriesCollection PieChartSeriesCollection { get; set; }

        public ChartPriceVM(Dictionary<string, int> d, double p1, double p2)
        {
            currentModel = new ChartModel(d);
            startPrice = p1;
            endPrice = p2;
            PieChartSeriesCollection = currentModel.monthValueDictionary.ConvertToSeriesCollection();
        }
    }
}
