using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.Model
{
    public class AddPurchaseModel 
    {
        public string location;
        public string product;
        public int quantity;
        public double price;
        public DateTime date;

        public AddPurchaseModel(string loc = "", string prod = "", int quan = 0, double p = 0.0)
        {

            location = loc;
            product = prod;
            quantity = quan;
            price = p;
            date = DateTime.Now;
        }

        public void allFieldClear()
        {
            this.location = "";
            this.product = "";
            this.quantity = 1;
            this.price = 0;
            this.date = DateTime.Now;
        }
    }
}
