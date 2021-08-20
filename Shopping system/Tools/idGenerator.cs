using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.Tools
{
    public class idGenerator
    {
        private static int purchaseID { get; set; }
        private static int qrID { get; set; }
        private static int storeID { get; set; }
        private static int colorID { get; set; }

        public idGenerator()
        {
            IBL bL = new BlIMP();
            purchaseID = bL.getPurchases().Max(item => item.prid)+1;
            qrID = bL.getQRcodes().Max(item => Convert.ToInt32(item.qrCode)) + 1;
            storeID = bL.getStores().Max(item => item.sid) + 1;
            colorID = 0;
        }

        public static int getPurchaseID()
        {
            return purchaseID++;
        }

        public static int getqrID()
        {
            return qrID++;
        }

        public static int getStoreID()
        {
            return storeID++;
        }

        public static string getColorID()
        {
            if (ExtendChart.color.Count > colorID)
                return ExtendChart.color[colorID++];
            else
                return ExtendChart.color[(colorID = 0)];
        }

    

    }
}
