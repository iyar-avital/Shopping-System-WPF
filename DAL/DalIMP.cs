using BE;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
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
                    ctx.Entry(purchase).State = EntityState.Deleted;
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

        public void createPDF(List<object[]> items)
        {
            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();
            //Add a page.
            PdfPage page = doc.Pages.Add();
            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            //Loads the image from disk
            string CSPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
            string ImagePath = Path.Combine(CSPath, @"DAL\ImagesPDF\Sicon.jpg");
            PdfImage image = PdfImage.FromFile(ImagePath);
            RectangleF bounds = new RectangleF(200, 20, 150, 150);
            //Draws the image to the PDF page
            page.Graphics.DrawImage(image, bounds);
            Font font = new Font("Ariel", 15);
            PdfFont pdfFont = new PdfTrueTypeFont(font, true);
            PdfStringFormat format = new PdfStringFormat();
            //Set right-to-left text direction for RTL text
            format.TextDirection = PdfTextDirection.LeftToRight;
            format.Alignment = PdfTextAlignment.Left;

            //Draw grid to the page of PDF document.
            PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(104, 185, 255));
            bounds = new RectangleF(0, bounds.Bottom + 90, page.Graphics.ClientSize.Width, 30);
            //Draws a rectangle to place the heading in that region.
            page.Graphics.DrawRectangle(solidBrush, bounds);
            //Creates a text element to add the invoice number
            PdfTextElement element = new PdfTextElement("", pdfFont);
            element.Brush = PdfBrushes.White;
            //Draws the heading on the page
            PdfLayoutResult result = element.Draw(page, new PointF(10, bounds.Top + 8));
            string currentDate = DateTime.Now.ToString("MM/dd/yyyy");
            //Measures the width of the text to place it in the correct location
            SizeF textSize = pdfFont.MeasureString(currentDate);
            PointF textPosition = new PointF(page.Graphics.ClientSize.Width - textSize.Width-200, result.Bounds.Y);
            //Draws the date by using DrawString method
            page.Graphics.DrawString(currentDate, pdfFont, element.Brush, textPosition, format);
            //Creates text elements to add the address and draw it to the page.
            element = new PdfTextElement("Your shopping list", pdfFont);
            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
            element.StringFormat = format;
            result = element.Draw(page, new PointF(page.Graphics.ClientSize.Width - textSize.Width-200, result.Bounds.Bottom + 25));
            PdfPen linePen = new PdfPen(new PdfColor(126, 151, 173), 0.70f);
            PointF startPoint = new PointF(0, result.Bounds.Bottom + 3);
            PointF endPoint = new PointF(page.Graphics.ClientSize.Width, result.Bounds.Bottom + 3);
            //Draws a line at the bottom of the address
            page.Graphics.DrawLine(linePen, startPoint, endPoint);



            //Create a DataTable.
            DataTable dataTable = new DataTable();
            //Add columns to the DataTable
            dataTable.Columns.Add("Catalog Number");
            dataTable.Columns.Add("Product");
            dataTable.Columns.Add("Description");
            //Add rows to the DataTable.
            foreach (var item in items)
            {
                dataTable.Rows.Add(item);
            }

            //Creates the datasource for the table
            DataTable Details = dataTable;
            //Creates a PDF grid
            PdfGrid grid = new PdfGrid();
            grid.Style.Font = pdfFont;

            //Adds the data source
            grid.DataSource = Details;
            //Creates the grid cell styles
            PdfGridCellStyle cellStyle = new PdfGridCellStyle();
            cellStyle.Borders.All = PdfPens.White;
            //PdfGridRow header = grid.Headers[0];
            //Creates the header style
            PdfGridCellStyle headerStyle = new PdfGridCellStyle();
            headerStyle.Borders.All = new PdfPen(new PdfColor(104, 185, 255));
            headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(104, 185, 255));
            headerStyle.TextBrush = PdfBrushes.White;
            headerStyle.Font = pdfFont;
            headerStyle.StringFormat = format;
            //Applies the header style
            grid.Headers[0].ApplyStyle(headerStyle);
            foreach (PdfGridColumn Column in grid.Columns)
            {
                Column.Format = format;
            }
            cellStyle.Borders.Bottom = new PdfPen(new PdfColor(217, 217, 217), 0.70f);
            cellStyle.Font = pdfFont;
            cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(102, 102, 102));
            cellStyle.StringFormat = format;


            //Creates the layout format for grid
            PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
            // Creates layout format settings to allow the table pagination
            layoutFormat.Layout = PdfLayoutType.Paginate;
            //Draws the grid to the PDF page.
            PdfGridLayoutResult gridResult = grid.Draw(page, new RectangleF(new PointF(0, result.Bounds.Bottom + 40), new SizeF(page.Graphics.ClientSize.Width, page.Graphics.ClientSize.Height - 100)), layoutFormat);

            pdfGrid.Draw(page, new PointF(10, 10));


            //Save the document.
            try
            {
                doc.Save("Output.pdf");
                System.Diagnostics.Process.Start("Output.pdf");
            }
            catch
            {

            }
            //close the document
            doc.Close(true);
        }

    }
}
