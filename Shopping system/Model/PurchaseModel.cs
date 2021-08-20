using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.Model
{
    public class PurchaseModel
    {
        IBL bl = new BlIMP();
        public List<Purchase> purchases { get; set; }

        public PurchaseModel()
        {
            purchases = bl.getPurchaseForCostumer(App.currents.CurrentUser.cid);
        }

        public void Update(int id, string TheName)
        {
            //var flower = (from f in Flowers
            //              where f.Id == id
            //              select f).First<Flower>();

            //flower.Name = TheName;
        }

        public void Add(string TheName, string TheImageUrl)
        {
            Purchase purchase = new Purchase();
            purchases.Add(purchase);
            bl.addPurchase(purchase);
        }

        public void Remove(int id)
        {
            //var flower = (from f in Flowers
            //              where f.Id == id
            //              select f).First<Flower>();

            //Flowers.Remove(flower);
        }
    }
}
