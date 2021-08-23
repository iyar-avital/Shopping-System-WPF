using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.View_Model
{
    public class PurchaseBasicVM : INotifyPropertyChanged
    {     
        string location;
        string product;
        int quantity;
        double price;
        DateTime date;
        string imagePath;

        public PurchaseBasicVM()
        {
            date = DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                PropertyChanged(this, new PropertyChangedEventArgs("location"));
            }
        }

        public string Product
        {
            get { return product; }
            set
            {
                product = value;
                PropertyChanged(this, new PropertyChangedEventArgs("product"));
            }
        }

        public string Quantity
        {
            get { return quantity.ToString(); }
            set
            {
                if (value == "")
                    quantity = 0;
                else
                    quantity = Convert.ToInt32(value);
                PropertyChanged(this, new PropertyChangedEventArgs("quantity"));
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                PropertyChanged(this, new PropertyChangedEventArgs("date"));
            }
        }

        public string Price
        {
            get { return price.ToString(); }
            set
            {
                if (value == "")
                    price = 0;
                else
                    price = Convert.ToDouble(value);
                PropertyChanged(this, new PropertyChangedEventArgs("price"));
            }
        }

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                PropertyChanged(this, new PropertyChangedEventArgs("imagePath"));
            }
        }

        public void clear()
        {
            Price = "0";
            Quantity = "0";
            Location = "";
            Product = "";
            Date = DateTime.Now;
        }

        public bool fillAllFields()
        {
            bool flag = true;
            if (Quantity == "0" || Quantity == "" || Price == "0" || Price == "")
                flag = false;
            if ((Location == "" || Location == null || Product == "" || Product == null) && (ImagePath == "" || ImagePath == null))
                flag = false;
            return flag;
        }

        public bool fillByDetails()
        {
            return ((Location != "" && Product != "") && (Location != null && Product != null));
        }
    }
}
