using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.MachineLearning.Rules;

namespace BL.AprioriIMP
{
    public class AprioriModel
    {
        public List<AssociationRule<int>> associationRules { get; set; }

        public AprioriModel()
        {
            AprioriAlgorithm apriori = new AprioriAlgorithm();
            AssociationRule<int>[] result =  apriori.AprioriAlgo();
            List<AssociationRule<int>> list = new List<AssociationRule<int>>();
            foreach (var item in result)
            {
                if(item.Confidence >= 0.5)
                    list.Add(item);
            }
            associationRules = list;
        }

    }
}
