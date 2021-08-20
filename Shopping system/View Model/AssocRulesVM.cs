using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Shopping_system.Command;
using Shopping_system.Model;
using System.Collections.ObjectModel;
using BE;
using BL;

namespace Shopping_system.View_Model
{
    public class AssocRulesVM : BaseVM
    {      
        public AssocRulesModel currentModel { get; set; }
        public ObservableCollection<RulesVM> rulesVMs { get; set; }

        public AssocRulesVM()
        {
            currentModel = new AssocRulesModel();
            rulesVMs = currentModel.associationRules.GetRuleVM();  
        }

       // public event PropertyChangedEventHandler PropertyChanged;   

    }
}
