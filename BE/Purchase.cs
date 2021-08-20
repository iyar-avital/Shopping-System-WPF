using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Purchase
    {
        [Key]
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
            date = new DateTime(_date.Year, _date.Month, _date.Day);
        }

        public Purchase()
        { }
    }
}
