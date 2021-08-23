using LiveCharts;
using LiveCharts.Wpf;
using Shopping_system.Model;
using Shopping_system.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.View_Model
{
    public class ChartVM : BaseVM
    {
        public ChartModel currentModel { get; set; }
        public string productName { get; set; }

        public SeriesCollection PieChartSeriesCollection { get; set; }

        public ChartVM(Dictionary<string, int> d, string p)
        {
            currentModel = new ChartModel(d);
            productName = p;
            PieChartSeriesCollection = currentModel.monthValueDictionary.ConvertToSeriesCollection();
        }
    }
}
