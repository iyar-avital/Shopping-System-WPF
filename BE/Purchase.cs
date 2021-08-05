using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Purchase
    {
        public int prid { get; set; }
        public string cid { get; set; }

        public string qrCode { get; set; }

        public int quantity { get; set; }

        public DateTime date { get; set; }

        public Purchase(int _prid, string _cid, string _qrCode, int _quantity, DateTime _date)
        {
            prid = _prid;
            cid = _cid;
            qrCode = _qrCode;
            quantity = _quantity;
            date = _date;
        }

        public Purchase()
        { }
    }
}
