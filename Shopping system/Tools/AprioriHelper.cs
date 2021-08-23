using Shopping_system.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;
using System.Collections.ObjectModel;
using Shopping_system.View_Model;
using Accord.MachineLearning.Rules;
using BL.AprioriIMP;

namespace Shopping_system
{
    public static class AprioriHelper
    {

    //    public static List<Product> convertXside(List<int> leftSide)
    //    {
    //        IBL bl = new BlIMP();
    //        List<Product> result = new List<Product>();
    //        Product p;

    //        //Product p1 = new Product(1, "Oil", "11", "/Images/oil.jpg");
    //        //Product p2 = new Product(2, "Milk", "22", "/Images/milk.jpg");
    //        //Product p3 = new Product(3, "Bread", "33", "/Images/bread.png");


    //        foreach (var item in leftSide)
    //        {
    //            p = bl.getProduct(item);
    //            result.Add(p);

    //            //if (item == 1)
    //            //    result.Add(p1);
    //            //if (item == 2)
    //            //    result.Add(p2);
    //            //if (item == 3)
    //            //    result.Add(p3);
    //        }
    //        return result;
    //    }

    //    public static List<Product> convertYside(List<int> rightSide)
    //    {
    //        IBL bl = new BlIMP();
    //        List<Product> result = new List<Product>();
    //        Product p;


    //        //Product p1 = new Product(1, "Oil", "11", "/Images/oil.jpg");
    //        //Product p2 = new Product(2, "Milk", "22", "/Images/milk.jpg");
    //        //Product p3 = new Product(3, "Bread", "33", "/Images/bread.png");

    //        foreach (var item in rightSide)
    //        {
    //            p = bl.getProduct(item);
    //            result.Add(p);
    //            //if (item == 1)
    //            //    result.Add(p1);
    //            //if (item == 2)
    //            //    result.Add(p2);
    //            //if (item == 3)
    //            //    result.Add(p3);

    //        }
    //        return result;
    //    }

    //    public static AprioriRulesVM convertToAprioriRuleVm(this AssociationRule<string> ar)
    //    {
    //        return new AprioriRulesVM(ar);
    //    }

    //    public static ObservableCollection<AprioriRulesVM> GetRuleVM(this List<AssociationRule<string>> associationRules)
    //    {
    //        ObservableCollection<AprioriRulesVM> AprioriRulesVMs = new ObservableCollection<AprioriRulesVM>();
    //        foreach (var rule in associationRules)
    //        {
    //            AprioriRulesVMs.Add(rule.convertToAprioriRuleVm());
    //        }
    //        return AprioriRulesVMs;
    //    }
    }
}
