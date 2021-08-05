using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class QRcode
    {
        public string qrCode { get; set; }

        public int pid { get; set; }

        public string storeName { get; set; }

        public string amount { get; set; }

        public string price { get; set; }

        public QRcode(string _qrCode, int _pid, string _storeName, string _amount, string _price)
        {
            this.qrCode = _qrCode;
            this.pid = _pid;
            this.storeName = _storeName;
            this.amount = _amount;
            this.price = _price;
        }

        public QRcode()
        { }
    }
}
