using Shopping_system.Command;
using Shopping_system.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.View_Model
{
    public class LoginVM : INotifyPropertyChanged
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

        }
    }
}
