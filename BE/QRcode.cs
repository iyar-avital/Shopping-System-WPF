using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class QRcode
    {
        [Key]
        public string qrCode { get; set; }

        public int pid { get; set; }

        public int sid { get; set; }

        public int amount { get; set; }

        public double price { get; set; }

        public QRcode(string _qrCode, int _pid, int _sid, int _amount, double _price)
        {
            this.qrCode = _qrCode;
            this.pid = _pid;
            this.sid = _sid;
            this.amount = _amount;
            this.price = _price;
        }

        public QRcode()
        { }
    }
}
