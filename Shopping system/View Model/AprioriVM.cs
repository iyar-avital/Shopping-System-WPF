using Shopping_system.View_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AprioriIMP 
{
    public class AprioriVM : BaseVM
    {
        public AprioriModel currentModel { get; set; }

        public ObservableCollection<AprioriRulesVM> aRulesVMs { get; set; }

        public AprioriVM()
        {
            currentModel = new AprioriModel();
            aRulesVMs = currentModel.associationRules.GetAprioriRuleVM();
        }
    }
}
