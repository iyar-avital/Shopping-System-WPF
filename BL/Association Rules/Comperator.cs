using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace BL
{
    //public class Comperator
    //{
    //    public static bool Equals(ItemSet x, ItemSet y)
    //    {
    //        List<int> firstNotSecond = x.items.Except(y.items).ToList();
    //        List<int> SecondNotfirst = y.items.Except(x.items).ToList();
    //        if (firstNotSecond.Count == 0 && SecondNotfirst.Count == 0 && x.k == y.k)//iset!= allItemSets[i]
    //            return true;
    //        return false;
    //    }

    //    public static bool EqualsRules(AssociationRule x, AssociationRule y)
    //    {
    //        bool leftSide = false;
    //        bool rightSide = false;
    //        List<int> firstNotSecond1 = x.xSide.Except(y.xSide).ToList();
    //        List<int> SecondNotfirst1 = y.xSide.Except(x.xSide).ToList();
    //        if (firstNotSecond1.Count == 0 && SecondNotfirst1.Count == 0 && x.xSide.Count == y.xSide.Count)
    //            leftSide = true;

    //        List<int> firstNotSecond2 = x.ySide.Except(y.ySide).ToList();
    //        List<int> SecondNotfirst2 = y.ySide.Except(x.ySide).ToList();
    //        if (firstNotSecond2.Count == 0 && SecondNotfirst2.Count == 0 && x.ySide.Count == y.ySide.Count)//equals
    //            rightSide = true;

    //        if (leftSide && rightSide)
    //            return true;
    //        return false;
    //    }

    //    public static List<AssociationRule> containRules(List<AssociationRule> associationRules)
    //    {
    //        List<int> firstNotSecond1;
    //        List<int> SecondNotfirst1;
    //        AssociationRule rule;
    //        List<int> leftSide;
    //        List<int> rightSide = new List<int>();
    //        List<AssociationRule> result = new List<AssociationRule>();
    //        bool flag = false;
    //        for (int i = 0; i < associationRules.Count; i++)
    //        {
    //            rightSide = new List<int>();
    //            for (int j = 0; j < associationRules.Count; j++)
    //            {
    //                firstNotSecond1 = associationRules[i].xSide.Except(associationRules[j].xSide).ToList();
    //                SecondNotfirst1 = associationRules[j].xSide.Except(associationRules[i].xSide).ToList();
    //                if (firstNotSecond1.Count == 0 && SecondNotfirst1.Count == 0 && associationRules[i].xSide.Count == associationRules[j].xSide.Count)
    //                {
    //                    flag = true;
    //                    rightSide.AddRange(associationRules[j].ySide);
    //                }
    //            }
    //            leftSide = associationRules[i].xSide;
    //            rightSide.AddRange(associationRules[i].ySide);
    //            rightSide = rightSide.Distinct().ToList();

    //            rule = new AssociationRule();
    //            rule.xSide = leftSide;
    //            rule.ySide = rightSide;
    //            rule.Support = associationRules[i].Support;
    //            rule.Confidance = associationRules[i].Confidance;
    //            result.Add(rule);
    //        }
    //        if (flag == false)
    //            return associationRules;
    //        return result;
    //    }
    //}
}
