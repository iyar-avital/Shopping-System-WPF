using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalIMP : IDAL
    {
        #region costumer
        public void addCostumer(Costumer costumer)
        {
            try
            {
                using (var ctx = new ShoppingDB())
                {
                    ctx.Costumers.Add(costumer);
                    ctx.SaveChanges();
                }
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
                using (var ctx = new ShoppingDB())
                {
                    ctx.Entry(costumer).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Costumer getCostumer(string id)
        {
            using (var ctx = new ShoppingDB())
            {
                return ctx.Costumers.Find(id);
            }
        }

        public List<Costumer> getCostumers(Func<Costumer, bool> predicate = null)
        {
            using (var ctx = new ShoppingDB())
            {
                if (predicate == null)
                    return ctx.Costumers.ToList();

                var costumers = ctx.Costumers.Where(predicate).ToList();
                return costumers;
            }
        }
        #endregion

        #region store
        public void addStore(Store store)
        {
            try
            {
                using (var ctx = new ShoppingDB())
                {
                    ctx.Stores.Add(store);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Store getStore(int id)
        {
            using (var ctx = new ShoppingDB())
            {
                return ctx.Stores.Find(id);
            }
        }

        public List<Store> getStores(Func<Store, bool> predicate = null)
        {
            using (var ctx = new ShoppingDB())
            {
                if (predicate == null)
                    return ctx.Stores.ToList();

                var stores = ctx.Stores.Where(predicate).ToList();
                return stores;
            }
        }
        #endregion

        #region product
        public void addProduct(Product product)
        {
            try
            {
                using (var ctx = new ShoppingDB())
                {
                    ctx.Products.Add(product);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void UpdateProduct(Product product)
        {
            try
            {
                List<Product> products = getProducts(p => p.pid == product.pid);
                if (products.Count() == 0)
                    throw new Exception("מוצר זה לא מוכר במערכת, אנא הוסף אותו");
                using (var ctx = new ShoppingDB())
                {
                    ctx.Entry(product).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Product getProduct(int id)
        {
            using (var ctx = new ShoppingDB())
            {
                return ctx.Products.Find(id);
            }
        }
        public List<Product> getProducts(Func<Product, bool> predicate = null)
        {
            using (var ctx = new ShoppingDB())
            {
                if (predicate == null)
                    return ctx.Products.ToList();

                var products = ctx.Products.Where(predicate).ToList();
                return products;
            }
        }
        #endregion

        #region QRcode
        public void addQRcode(QRcode qRcode)
        {
            try
            {
                using (var ctx = new ShoppingDB())
                {
                    ctx.QRcodes.Add(qRcode);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public QRcode getQRcode(string code)
        {
            using (var ctx = new ShoppingDB())
            {
                return ctx.QRcodes.Find(code);
            }
        }
        public List<QRcode> getQRcodes(Func<QRcode, bool> predicate = null)
        {
            using (var ctx = new ShoppingDB())
            {
                if (predicate == null)
                    return ctx.QRcodes.ToList();

                var qRcodes = ctx.QRcodes.Where(predicate).ToList();
                return qRcodes;
            }
        }
        #endregion

        #region purchase
        public void addPurchase(Purchase purchases)
        {
            try
            {
                using (var ctx = new ShoppingDB())
                {
                    ctx.Purchases.Add(purchases);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deletePurchaseFromUserFile(int prid)
        {
            bool Result = true;
            try
            {
                Purchase purchase = getPurchase(prid);
                if (purchase == null)
                    return false;
                using (var ctx = new ShoppingDB())
                {
                    ctx.Configuration.ValidateOnSaveEnabled = false;
                    ctx.Purchases.Attach(purchase);
                    ctx.Entry(prid).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                Result = false;
            }

            return Result;
        }

        public Purchase getPurchase(int prid)
        {
            using (var ctx = new ShoppingDB())
            {
                return ctx.Purchases.Find(prid);
            }
        }
        public List<Purchase> getPurchaseForCostumer(string cid)
        {
            Costumer costumer = getCostumer(cid);
            if (costumer == null)
                return null;
            return getPurchases(p => p.cid == cid);
        }

        public List<Purchase> getPurchases(Func<Purchase, bool> predicate = null)
        {
            using (var ctx = new ShoppingDB())
            {
                if (predicate == null)
                    return ctx.Purchases.ToList();

                var purchases = ctx.Purchases.Where(predicate).ToList();
                return purchases;
            }
        }
        #endregion

        #region fireBaseStorage 
        public string[] GetQRDetails(string QrUML)
        {
            return FireBaseStorage.GetQRDetails(QrUML);
        }

        public void uploadToFB(string imgUML, Product product, string nameToStorage)
        {
            FireBaseStorage.UploadToFB(imgUML, product, nameToStorage);
        }

        #endregion

        public void createPDF(List<object[]> items) { }

    }
}
