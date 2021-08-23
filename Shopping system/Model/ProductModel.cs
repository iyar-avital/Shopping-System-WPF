using Accord.MachineLearning.Rules;
using BE;
using BL;
using BL.AprioriIMP;
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

        public ProductModel(string type)
        {
            switch (type)
            {
                case "family": products = familyProduct(); break;
                case "healthy": products = healthyProduct(); break;
                case "you": products = forYouProduct(); break;
                default:
                    break;
            }
        }

        public void Update(int id, string TheName)
        {
        }

        public void Add(string TheName, string TheImageUrl)
        {
            Product product = new Product();
            products.Add(product);
            bl.addProduct(product);
        }

        public void CreatePDF(List<object[]> items)
        {
            IBL BL = new BlIMP();
            BL.createPDF(items);
        }

        public List<Product> familyProduct()
        {
            List<string> names = new List<string>() { "bread", "Milk", "Oil", "Eggs", "Flour", 
                "Coffee", "Hummus", "Sugar", "Delicacy", "Chease", "Ketchup", "Tuna", "Cornflakes" };
            return bl.getProducts(item => names.Contains(item.productName));          
        }

        public List<Product> healthyProduct()
        {
            List<string> names = new List<string>() { "Oil", "Eggs", "Tuna", "Palms", 
                "Yogurt", "Broccoli", "Beans", "Crisps", "Almonds", "Carrot" };
            return bl.getProducts(item => names.Contains(item.productName));
        }

        public List<Product> forYouProduct()
        {
            List<AssociationRule<int>> associationRules;
            AprioriAlgorithm apriori = new AprioriAlgorithm();
            AssociationRule<int>[] result = apriori.AprioriAlgo();
            List<AssociationRule<int>> list = new List<AssociationRule<int>>();
            foreach (var item in result)
            {
                if (item.Confidence >= 0.5)
                    list.Add(item);
            }
            associationRules = list;

            List<Product> Allproducts = AddProductByAssociationRules(associationRules);
            return Allproducts;
        }

        public List<Product> pupularProductCostumer()
        {
            List<Product> Result = new List<Product>();
            List<Purchase> purchases = bl.getPurchaseForCostumer(App.currents.CurrentUser.cid);
            var products = purchases
                .GroupBy(x => bl.getQRcode(x.qrCode).pid, (pid, purc) => new { productID = pid, Sum = purc.Sum(i => i.quantity) });

            foreach (var item in products)
            {
                if (item.Sum > 2)
                    Result.Add(bl.getProduct(item.productID));
            }
            return Result;
        }
 
        public List<Product> AddProductByAssociationRules(List<AssociationRule<int>>  assos)
        {
            List<Product> products = pupularProductCostumer();
            foreach (var item in assos)
            {
                if(item.X.All(i => products.Contains(bl.getProduct(i))) == true)
                {
                    foreach (var i in item.Y)
                    {
                        products.Add(bl.getProduct(i));
                    }
                }              
            }
            return products;
        }
    }
}
