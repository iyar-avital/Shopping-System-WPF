using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.Model
{
    public class SignupModel
    {
        IBL bl;
        public SignupModel()
        {
            bl = new BlIMP();
        }

        public string cid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string mail { get; set; }
        public string password { get; set; }

        public void signUp(string cid, string fname, string lname, string mail, string pswd)
        {
            Costumer c;
            try
            {
                if (Validation.IsId(cid) && Validation.IsName(fname) && Validation.IsName(lname)
                   && Validation.IsEmail(mail) && Validation.IsPassword(pswd))
                {
                    c = new Costumer(cid, fname, lname, mail, pswd);
                    bl.addCostumer(c);
                }
                else
                    throw new Exception("One or more of the fields were filled with incorrect values");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
