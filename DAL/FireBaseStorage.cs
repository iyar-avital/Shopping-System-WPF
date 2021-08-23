using BE;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace DAL
{
    public static class FireBaseStorage
    {
        public static async Task UploadToFB(string imgUML, Product product, string nameToStorage)
        {
            string path = "C:\\Users\\iyar\\Desktop\\Images\\";
            string[] result = imgUML.Split('/');
            path = path + result[2];
            FileStream stream = File.Open(path, FileMode.Open);
            FirebaseStorageTask task = new FirebaseStorage("shopping-system-e9d5d.appspot.com")//my fireBase Storage
                                        .Child(nameToStorage)
                                        .PutAsync(stream);
            //task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");
            string theURL = await task;//asynchronic- so it waits until the upload complete

            IDAL dal = new DalIMP();//update the path, so we will take it from the FB
            product.imagePath = theURL;
            dal.UpdateProduct(product);
        }

        public static string[] GetQRDetails(string qrURL)
        {
            try
            {
                IDAL dal = new DalIMP();
                string imageUrl = qrURL;
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(imageUrl);

                if (stream == null) return null;
                Bitmap bitmap = new Bitmap(stream);
                IBarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode(bitmap);
                if (result == null)
                    throw new Exception("Unfortunatally, the QR not recognized");
                //QRCODE-PNAME-PCODE-PDESCRIPTION-PRICE-PIMGPATH
                string description = result.Text;
                string[] tokens = description.Split('-');
                string QrCode = tokens[0];
                string name = tokens[1];
                int id = Convert.ToInt32(tokens[2]);
                string pDescription = tokens[3];
                string price = tokens[4];
                string path = tokens[5];


                string[] location = extractLocation(qrURL);
                string city = location[0];
                string storeName = location[1];

                string[] QrDetails = new string[] { QrCode, name, id.ToString(), pDescription, price, path, storeName, city };
                return QrDetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public static string[] extractLocation(string URL)
        {
            //C:\Users\zizovirivka\Desktop\QrCodes\לוד\אושר עד
            int index = URL.IndexOf("QrCodes") + 8;
            char startIndex = Convert.ToChar(index);
            string str = URL.Substring(index);
            string[] result = str.Split('\\');
            return result;
        }
    }
}
