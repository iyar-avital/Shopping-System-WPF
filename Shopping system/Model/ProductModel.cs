using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.Model
{
    public class ProductModel
    {
        IBL bl = new BlIMP();
        public List<Product> products { get; set; }

        public ProductModel()
        {
            //purchases = bl.getPurchaseForCostumer();
            products = new List<Product>
            {
                new Product { pid = 123, productName = "milk", description = "Fresh milk, 5% and lactose deficient", imagePath = "/images/milk.jpg" },
                new Product { pid = 124, productName = "bread", description = "Bread five grains", imagePath = "/images/bread.png" },
            };
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
            Product product = new Product();
            products.Add(product);
            bl.addProduct(product);
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
