using LiveCharts;
using Shopping_system.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.Model
{
    public class ChartModel
    {
        public Dictionary<string, int> monthValueDictionary { get; set; }

        public ChartModel(Dictionary<string, int> keyValuePairs)
        {
            monthValueDictionary = keyValuePairs;
        }
    }
}
