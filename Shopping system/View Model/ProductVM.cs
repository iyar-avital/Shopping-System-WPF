using BE;
using Shopping_system.Command;
using Shopping_system.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shopping_system.View_Model
{
    public class ProductVM : BaseVM
    {
        public ProductModel productModel { get; set; }
        public ObservableCollection<Product> ProductVMs { get; set; }

        public ProductVM(string type)
        {
            productModel = new ProductModel(type);
            
            ProductVMs = new ObservableCollection<Product>(productModel.products);
        }

        public ICommand CreatePdf
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    List<object[]> items = new List<object[]>();
                    foreach (Product item in ProductVMs)
                    {
                        items.Add(new object[] { item.pid, item.productName, item.description });
                    }
                    productModel.CreatePDF(items);
                });
            }
        }
    }
}
