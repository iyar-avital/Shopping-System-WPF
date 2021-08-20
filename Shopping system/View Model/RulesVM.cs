using Shopping_system.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Shopping_system;
using BL;
using BE;

namespace Shopping_system.View_Model
{
    public class RulesVM
    {
         AssociationRule associationRule;
    
         public RulesVM(AssociationRule ar)
         {
            associationRule = ar;
         }

        public List<Product> leftSide
        {
            get { return AprioriHelper.convertXside(associationRule.xSide); }
            set { }   
        }

        public List<Product> rightSide
        {
            get { return AprioriHelper.convertYside(associationRule.ySide); }
            set { }
        }

        public double confidence
        {
            get { return associationRule.Confidance; }
            set { }
        }
    }
}

