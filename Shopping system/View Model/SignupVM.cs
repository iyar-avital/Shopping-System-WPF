using Shopping_system.Command;
using Shopping_system.Model;
using Shopping_system.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_system.View_Model
{
    public class SignupVM : BaseVM, INotifyPropertyChanged
    {
        SignupModel currentModel { get; set; }

        public SignupCommand currentCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public string cid
        {
            get { return currentModel.cid; }
            set
            {
                currentModel.cid = value;
                PropertyChanged(this, new PropertyChangedEventArgs("cid"));
            }
        }

        public string firstname
        {
            get { return currentModel.firstname; }
            set
            {
                currentModel.firstname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("firstname"));
            }
        }
        public string lastname
        {
            get { return currentModel.lastname; }
            set
            {
                currentModel.lastname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("lastname"));
            }
        }
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

        public SignupVM()
        {
            currentModel = new SignupModel();
            currentCommand = new SignupCommand();
            currentCommand.signUp += signUp;
        }

        private void signUp(string cid, string fname, string lname, string mail, string pswd)
        {
            try
            {
                if (cid != "" && fname != "" && lname != "" && mail != "" && pswd != "")
                    currentModel.signUp(cid, fname, lname, mail, pswd);
            }
            catch (Exception)
            {
                throw new Exception("invalid values");
            }
        }
    }
}

