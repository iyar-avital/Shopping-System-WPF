using Accord.MachineLearning.Rules;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AprioriIMP
{
    public class AprioriAlgorithm
    {
        IBL bl = new BlIMP();
        public SortedSet<int>[] dataset;

        public AprioriAlgorithm()
        {
            var Result = bl.getPurchases().
                GroupBy(item => new { item.date, bl.getQRcode(item.qrCode).sid }).
                Select(item => record(item.Key.date, item.Key.sid)).ToArray();
            dataset = Result;
        }

        public SortedSet<int> record(DateTime date, int store)
        {
            SortedSet<int> Result = new SortedSet<int>();
            foreach (var item in bl.getPurchases())
            {
                if (item.date == date)
                {
                    QRcode qr = bl.getQRcode(item.qrCode);
                    if (qr.sid == store)
                        Result.Add(qr.pid);
                }
            }
            return Result;
        }      

        public AssociationRule<int>[] AprioriAlgo()
        {
            Apriori apriori = new Apriori(threshold: 1, confidence: 0);

            AssociationRuleMatcher<int> classifier = apriori.Learn(dataset);
            AssociationRule<int>[] rules = classifier.Rules;
            return rules;  
        }
    }
}
