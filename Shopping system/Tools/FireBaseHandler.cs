using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Shopping_system.Tools
{
    public static class FireBaseHandler
    {
        public static Purchase chechQR(string selectedFileName, int quantity, double _price, DateTime date, string cid)
        {
            IBL bl = new BlIMP();
            string[] QRDetails = bl.GetQRDetails(selectedFileName);//qrcode, pname, productId, pDescription, path , storeName, city 
            string qrCode = QRDetails[0];
            string pname = QRDetails[1];
            int productId = Convert.ToInt32(QRDetails[2]);
            string pDescription = QRDetails[3];
            double price = Convert.ToDouble(QRDetails[4]);
            string path = QRDetails[5];
            string storeName = QRDetails[6];
            string city = QRDetails[7];

            QRcode umlQR = bl.getQRcode(qrCode);
            Product product;
            Store store;
            List<Product> products;

            if (umlQR != null)
            {
                return new Purchase(idGenerator.getPurchaseID(), cid, qrCode, Convert.ToInt32(quantity), date);
            }

            else
            {
                store = bl.getStores(s => s.city == city && s.storeName == storeName).FirstOrDefault();
                if (store == null)
                {
                    store = new Store(idGenerator.getStoreID(), storeName, city);
                    bl.addStore(store);
                }

                products = bl.getProducts(p => p.productName == pname);
                if (products.Count == 0)
                {
                    product = new Product(productId, pname, pDescription, path);
                    bl.addProduct(product);
                    string nameToStorage = pname + "-" + product.pid + ".jpg";
                    bl.uploadToFB(path, product, nameToStorage);
                    bl.addQRcode(new QRcode(qrCode, product.pid, store.sid, quantity, price));
                    return new Purchase(idGenerator.getPurchaseID(), cid, qrCode, Convert.ToInt32(quantity), date);
                }

                else //this produt already exists in the db, now it get another instance
                {                
                    bl.addQRcode(new QRcode(qrCode, products[0].pid, store.sid, quantity, price));
                    return new Purchase(idGenerator.getPurchaseID(), cid, qrCode, Convert.ToInt32(quantity), date);
                }
            }
        }
    }
}
