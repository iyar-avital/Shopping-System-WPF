using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.Model
{
    public class LoginModel
    {
        IBL bL;
        public string mail { get; set; }

        public string password { get; set; }

        public LoginModel()
        {
            bL = new BlIMP();
        }

        public void login(string mail, string pass)
        {

            //if (!Validation.IsPassword(pass) || !Validation.IsEmail(mail))
            //    throw new Exception("not valid email or password");
            try
            {
                bL.SignIn(mail, pass);
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }

        public Costumer getCostumer(string _mail)
        {
            IBL bl = new BlIMP();
            Costumer costumer = bl.getCostumers(i => i.mail == _mail).FirstOrDefault();
            return costumer;
        }
    }
}
