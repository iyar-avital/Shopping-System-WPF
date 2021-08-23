using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.MachineLearning.Rules;
using System.Collections.ObjectModel;

namespace BL.AprioriIMP
{
    public static class AprioriHelp
    {
        public static List<Product> convertXside(SortedSet<int> leftSide)
        {
            IBL bl = new BlIMP();
            List<Product> result = new List<Product>();
            Product p;

            foreach (var item in leftSide)
            {
                p = bl.getProduct(item);
                result.Add(p);
            }
            return result;
        }

        public static List<Product> convertYside(SortedSet<int> rightSide)
        {
            IBL bl = new BlIMP();
            List<Product> result = new List<Product>();
            Product p;

            foreach (var item in rightSide)
            {
                p = bl.getProduct(item);
                result.Add(p);
            }
            return result;
        }

        public static AprioriRulesVM convertToAprioriRuleVM(this AssociationRule<int> ar)
        {
            return new AprioriRulesVM(ar);
        }

        public static ObservableCollection<AprioriRulesVM> GetAprioriRuleVM(this List<AssociationRule<int>> associationRules)
        {
            ObservableCollection<AprioriRulesVM> rulesVMs = new ObservableCollection<AprioriRulesVM>();
            foreach (var rule in associationRules)
            {
                rulesVMs.Add(rule.convertToAprioriRuleVM());
            }
            return rulesVMs;
        }
    }
}
