using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [Table("Costumers")]
    public class Costumer
    {
        [Key]
        public string cid { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string mail { get; set; }

        public string password { get; set; }

        public Costumer(string _cid, string _firstName, string _lastName, string _mail, string _password)
        {
            this.firstName = _firstName;
            this.lastName = _lastName;
            this.cid = _cid;
            this.mail = _mail;
            this.password = _password;
        }

        public Costumer()
        { }
    }

}
