using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class BlIMP : IBL
    {
        #region costumer
        public void addCostumer(Costumer costumer)
        {
            try
            {
                IDAL dal = new DalIMP();
                List<Costumer> costumers = dal.getCostumers(c => c.cid == costumer.cid);
                if (costumers.Count() != 0)
                    throw new Exception("לקוח זה כבר רשום במערכת");
                dal.addCostumer(costumer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCostumer(Costumer costumer)
        {
            try
            {
                IDAL dal = new DalIMP();
                List<Costumer> costumers = dal.getCostumers(c => c.cid == costumer.cid);
                if (costumers.Count() == 0)
                    throw new Exception("לקוח זה לא מוכר במערכת, אנא הוסף אותו");
                dal.UpdateCostumer(costumer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Costumer getCostumer(string id)
        {
            IDAL dal = new DalIMP();
            return dal.getCostumer(id);
        }

        public List<Costumer> getCostumers(Func<Costumer, bool> predicate = null)
        {
            IDAL dal = new DalIMP();
            return dal.getCostumers(predicate);
        }
        #endregion

        #region store

        public void addStore(Store store)
        {
            try
            {
                IDAL dal = new DalIMP();
                List<Store> stores = dal.getStores(s => s.sid == store.sid);
                if (stores.Count() != 0)
                    throw new Exception("חנות זו כבר קיימת במערכת");
                dal.addStore(store);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Store getStore(int id)
        {
            IDAL dal = new DalIMP();
            return dal.getStore(id);
        }

        public List<Store> getStores(Func<Store, bool> predicate = null)
        {
            IDAL dal = new DalIMP();
            return dal.getStores(predicate);
        }
        #endregion

        #region product

        public void addProduct(Product product)
        {
            try
            {
                IDAL dal = new DalIMP();
                List<Product> products = new List<Product>();
                try
                {
                    products = dal.getProducts(p => p.pid == product.pid);
                }
                catch (Exception)
                {
                    if (products.Count() != 0)
                        throw new Exception("מוצר זה כבר קיים במערכת");
                }      
                dal.addProduct(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product getProduct(int id)
        {
            IDAL dal = new DalIMP();
            return dal.getProduct(id);
        }

        public List<Product> getProducts(Func<Product, bool> predicate = null)
        {
            IDAL dal = new DalIMP();
            return dal.getProducts(predicate);
        }
        #endregion

        #region QRcode

        public void addQRcode(QRcode qRcode)
        {
            try
            {
                IDAL dal = new DalIMP();
                List<QRcode> qRcodes = dal.getQRcodes(q => q.qrCode == qRcode.qrCode);
                if (qRcodes.Count() != 0)
                    throw new Exception("בר קוד זה כבר קיים במערכת");
                dal.addQRcode(qRcode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public QRcode getQRcode(string code)
        {
            IDAL dal = new DalIMP();
            return dal.getQRcode(code);
        }

        public List<QRcode> getQRcodes(Func<QRcode, bool> predicate = null)
        {
            IDAL dal = new DalIMP();
            return dal.getQRcodes(predicate);
        }
        #endregion

        #region purchase

        public void addPurchase(Purchase purchase)
        {
            try
            {
                IDAL dal = new DalIMP();
                List<Purchase> purchases = dal.getPurchases(p => p.prid == purchase.prid);
                if (purchases.Count() != 0)
                    throw new Exception("קניה זו כבר קיימת במערכת");
                dal.addPurchase(purchase);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool deletePurchaseFromUserFile(int p)
        {
            IDAL dal = new DalIMP();
            return dal.deletePurchaseFromUserFile(p);
        }

        public Purchase getPurchase(int prid)
        {
            IDAL dal = new DalIMP();
            return dal.getPurchase(prid);
        }

        public List<Purchase> getPurchaseForCostumer(string cid)
        {
            IDAL dal = new DalIMP();
            return dal.getPurchases(p => p.cid == cid);
        }

        public List<Purchase> getPurchases(Func<Purchase, bool> predicate = null)
        {
            IDAL dal = new DalIMP();
            return dal.getPurchases(predicate);
        }

        #endregion

        #region apriori 

        public List<List<Product>> getListProductByID()
        {
            IDAL dal = new DalIMP();
            List<Costumer> costumers = dal.getCostumers();
            List<Purchase> purchases = new List<Purchase>();
            List<Product> products;
            List<List<Product>> listProducts = new List<List<Product>>();
            foreach (var costumer in costumers)
            {
                purchases = dal.getPurchaseForCostumer(costumer.cid);
                products = new List<Product>();
                for (int i = 0; i < purchases.Count; i++)
                {
                    products.Add(dal.getProduct(purchases[i].prid));
                    products = products.Distinct().ToList();
                }
                listProducts.Add(products);
            }
            return listProducts;
        }

        public List<AssociationRule> GetAssociationRules()
        {
            IBL bl = new BlIMP();
            List<List<Product>> listProducts = getListProductByID();
            Apriori a = new Apriori(0.3, listProducts);//Treshold = 0.3 
            List<AssociationRule> associationRules = a.getRules();
            return associationRules;
        }
        #endregion

        #region account
        public void SignIn(string mail, string pass)
        {
            try
            {
                IDAL dal = new DalIMP();
                Costumer costumer = dal.getCostumers(c => c.mail == mail).FirstOrDefault();
                if (costumer == null)
                    throw new Exception("כתובת המייל לא זוהתה במערכת. אנא בדוק אותה או בצע הרשמה");
                else if (pass != costumer.password)
                    throw new Exception("סיסמה שגויה, נסה שנית");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SignUp(Costumer _costumer)
        {
            IDAL dal = new DalIMP();
            Costumer costumer = dal.getCostumers(c => c.cid == _costumer.cid).FirstOrDefault();
            if (costumer != null && costumer.password == null)
            {
                costumer.password = _costumer.password;
                dal.UpdateCostumer(costumer);
                //SendMail(doctor.email, "ההרשמה עברה בהצלחה", doctor.privateName + " " + doctor.familyName, "ברוכים הבאים לאתר שלנו, שמחים שהצטרפת." + "<br/>"
                //         + "נשמח לעמוד לעזרתך בכל פניה ובקשה ומקווים שתהיה לך חוויה נעימה." + "<br/>" + "תודה, צוות אח לאח");
            }
            else if (costumer == null)
            {
                //SendMail(doctorSign.email, "ההרשמה נכשלה", "", "לצערנו, נסיון ההרשמה שלך לאתרנו נכשל." + "<br/>"
                //         + "אנא נסה שוב בעוד חצי שנה ונשמח לעמוד לעזרתך." + "<br/>" + "תודה, צוות אח לאח");
                throw new Exception("ניסיון הרשמתך לאתרנו נכשל, אנא בדוק את תיבת המייל שלך עבור פרטים נוספים.");
            }
            else
            {
                throw new Exception("הנך רשום למערכת, אנא בצע התחברות. אם שכחת סיסמא לחץ על 'שכחת סיסמה?'");
            }
        }
        public void ForgotPassword(string mail)
        {
            try
            {
                IDAL dal = new DalIMP();
                Costumer costumer = dal.getCostumers(c => c.mail == mail).FirstOrDefault();
                if (costumer != null)
                {
                    Random random = new Random();
                    int newPassword = random.Next(10000, 1000000000);
                    //SendMail(doctor.email, "איפוס סיסמה", doctor.privateName + " " + doctor.familyName, "הסיסמה שלך אופסה, הסיסמה החדשה היא:" + "<br/>" + newPassword + "<br/>" + "אנא שנה סיסמה בהקדם האפשרי");

                    //Edit Password
                    costumer.password = newPassword.ToString();
                    UpdateCostumer(costumer);
                }
                //else
                //throw new Exception("המייל שהוזן שגוי. בדוק אם הינך רשום למערכת (איך?! תפעיל את הזיכרון בבקשה.)");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region send mail
        public void SendMail(string mailAdress, string subject, string receiverName, string message)
        {
            MailMessage mail;
            SmtpClient smtp;
            mail = new MailMessage();
            mail.To.Add(mailAdress);
            mail.From = new MailAddress("MyProject4Ever@gmail.com");
            mail.Subject = subject;
            mail.Body =
               "<b> <p style = 'font-size:25px'>" + "שלום " + receiverName + "</p> </b>" +
               "<b> <p style = 'font-size:20px'>" + message + "</p> </b>";
            mail.IsBodyHtml = true;
            smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("MyProject4Ever@gmail.com", "bla/*123*/bla");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }


        #endregion

        #region fireBaseStorage 
        public string[] GetQRDetails(string QrUML)
        {
            IDAL dal = new DalIMP();
            return dal.GetQRDetails(QrUML);
        }
        public void uploadToFB(string imgUML, Product product, string nameToStorage)
        {
            IDAL dal = new DalIMP();
            dal.uploadToFB(imgUML, product, nameToStorage);
        }

        #endregion

        public void createPDF(List<object[]> items) { }
    }
}
