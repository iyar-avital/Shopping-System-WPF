using Accord.MachineLearning.Rules;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AprioriIMP
{
    public class AprioriRulesVM
    {
        AssociationRule<int> associationRule;

        public AprioriRulesVM(AssociationRule<int> ar)
        {
            associationRule = ar;
        }
            
        public List<Product> leftSide
        {
            get { return AprioriHelp.convertXside(associationRule.X); }
            set { }
        }

        public List<Product> rightSide
        {
            get { return AprioriHelp.convertYside(associationRule.Y); }
            set { }
        }

        public double confidence
        {
            get { return associationRule.Confidence; }
            set { }
        }

    }
}

