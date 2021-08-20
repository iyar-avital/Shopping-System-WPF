using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Store
    {
        [Key]
        public int sid { get; set; }

        public string storeName { get; set; }

        public string city { get; set; }

        public Store(int _sid, string _storename, string _city)
        {
            sid = _sid;
            storeName = _storename;
            city = _city;
        }

        public Store()
        { }
    }
}
