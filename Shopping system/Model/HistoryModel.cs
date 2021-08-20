using BE;
using BL;
using Shopping_system.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.Model
{
    public class HistoryModel
    {
        public List<Purchase> purchases { get; set; }

        public HistoryModel()
        {
            IBL bl = new BlIMP();
            if (Currents.isCostumer())
                purchases = bl.getPurchaseForCostumer(App.currents.CurrentUser.cid);
            else
                purchases = new List<Purchase>();
        }
    }
}
