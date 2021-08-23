using Shopping_system.Command;
using Shopping_system.Model;
using Shopping_system.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shopping_system.View_Model
{
    public class LoginVM : BaseVM, INotifyPropertyChanged
    {
        LoginModel currentModel { get; set; }

        public LoginCommand currentCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public string mail
        {
            get { return currentModel.mail; }
            set
            {
                currentModel.mail = value;
                PropertyChanged(this, new PropertyChangedEventArgs("mail"));
            }
        }

        public string password
        {
            get { return currentModel.password; }
            set
            {
                currentModel.password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("password"));
            }
        }

        public LoginVM()
        {
            currentModel = new LoginModel();

            currentCommand = new LoginCommand();
            currentCommand.logIn += login;
        }

        private void login(string m, string p)
        {
            try
            {
                if (m != "" && p != "")
                {
                    currentModel.login(m, p);
                    App.currents.CurrentUser = currentModel.getCostumer(m);
                }
                else
                    throw new Exception("Please fill in the details then try to connect. \nImproper play in the software will lead you to an immediate block.");
            }
            catch (Exception ex)
            {
                throw ex;
            }       
        }
    }
}
