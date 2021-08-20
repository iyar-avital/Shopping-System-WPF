using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Product
    {
        [Key]
        public int pid { get; set; }

        public string productName { get; set; }

        public string description { get; set; }

        public string imagePath { get; set; }

        public Product(int _pid, string _productName, string _description, string _imagePath)
        {
            this.pid = _pid;
            this.productName = _productName;
            this.description = _description;
            this.imagePath = _imagePath;
        }

        public Product()
        { }
    }
}