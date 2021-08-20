using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace BL
{
    public class Apriori
    {
        public static int sizeK = 1;
        double treshold;
        List<List<int>> inputIntSets;
        Dictionary<ItemSet, double> frequentSets;
        Dictionary<ItemSet, double> allSets = new Dictionary<ItemSet, double>();

        public Apriori(double t, List<List<Product>> input)
        {
            treshold = t;
            frequentSets = new Dictionary<ItemSet, double>();
            inputIntSets = convertToInt(input);//getting it from a function in bl
        }

        public List<AssociationRule> getRules()
        {
            calculateFrequentSets();
            List<AssociationRule> associationRules = GetAssociationRules(frequentSets);
            return associationRules;
        }

        public void calculateFrequentSets()
        {
            Dictionary<ItemSet, double> frequenceOnly;
            Dictionary<ItemSet, double> allItemSets = get1Item();
            frequenceOnly = getFrequenceOnly(allItemSets);
            frequentSets = frequentSets.Union(frequenceOnly).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            allSets = allSets.Union(frequenceOnly).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            bool notFinish = true;
            while (notFinish)
            {
                allItemSets = getKPlus1ItemSets(allItemSets);
                if (allItemSets.Count == 0)
                {
                    notFinish = false;
                    break;
                }
                frequenceOnly  = getFrequenceOnly(allItemSets);
                frequentSets = frequentSets.Union(frequenceOnly).ToDictionary(dArgumant => dArgumant.Key, dArgumant => dArgumant.Value);
                allSets = allSets.Union(frequenceOnly).ToDictionary(dArgumant => dArgumant.Key, dArgumant => dArgumant.Value);
                sizeK++;
            }
        }

        private Dictionary<ItemSet, double> get1Item()
        {
            List<List<int>> inputsetsInt = this.inputIntSets;
            int pid;
            ItemSet iset;
            List<ItemSet> listSets = new List<ItemSet>();
            foreach (var listOfInt in inputIntSets)
            {
                for (int i = 0; i < listOfInt.Count; i++)//sets size 1 of int value
                {
                    pid = listOfInt[i];
                    iset = new ItemSet(pid);
                    listSets.Add(iset);
                }
            }
            listSets = listSets.Distinct().ToList();

            Dictionary<ItemSet, double> d = new Dictionary<ItemSet, double>();
            double frequence = 0;
            foreach (var set in listSets)
            {
                frequence = calculateFrequence(set);
                d.Add(set, frequence);
            }
            return d;
        }

        private Dictionary<ItemSet, double> getKPlus1ItemSets(Dictionary<ItemSet, double> allItemSets)
        {
            ItemSet currerntInLoop;
            List<int> firstNotSecond;
            List<int> SecondNotfirst;
            List<ItemSet> sets = new List<ItemSet>();
            foreach (ItemSet iset in allItemSets.Keys)//moving on the list in nested for and connect every pair
            {
                for (int i = 0; i < allItemSets.Count; i++)
                {
                    currerntInLoop = allItemSets.ElementAt(i).Key;
                    if (currerntInLoop.k == sizeK && iset.k == sizeK)
                    {
                        firstNotSecond = iset.items.Except(currerntInLoop.items).ToList();
                        SecondNotfirst = currerntInLoop.items.Except(iset.items).ToList();
                        if (!(firstNotSecond.Count == 0 && SecondNotfirst.Count == 0))//iset!= allItemSets[i]
                            sets.Add(iset.MakeKPlus1Set(iset, allItemSets.ElementAt(i).Key));
                    }
                }
            }

            List<ItemSet> unique = new List<ItemSet>();//sets.Distinct();
            bool flag1 = false;
            for (int i = 0; i < sets.Count; i++)
            {
                flag1 = false;
                if (sets[i] == null)
                    continue;
                if (unique.Count == 0)
                {
                    unique.Add(sets[i]);
                    continue;
                }
                for (int j = 0; j < unique.Count; j++)
                {
                    if (Comperator.Equals(unique[j], sets[i]))
                    {
                        flag1 = true;
                        break;
                    }
                }

                if (flag1 == false)
                {
                    unique.Add(sets[i]);
                }

            }
            sets = unique;//get K+1

            IEnumerable<int> Set;//List<int>
            List<List<int>> subIntsets;
            List<ItemSet> subSets;
            bool flag = true;//rather its a canidade or not
            Dictionary<ItemSet, double> d = this.allSets;
            ItemSet subItem;
            //ItemSet currerntSet;
            double frequence = 0;
            List<ItemSet> subItemSets = new List<ItemSet>();
            List<ItemSet> canidades = new List<ItemSet>();
            for (int i = 0; i < sets.Count; i++)
            {
                Set = sets[i].items;
                subIntsets = GetSubSets<int>(Set);//get subsets
                subSets = convertToSet(subIntsets);
                for (int j = 0; j < subSets.Count && flag; j++)//check subsets
                {
                    subItem = subSets[j];
                    if (subItem.items.Count == 0)
                        continue;
                    frequence = getFrequence(subItem);
                    if (frequence < treshold)
                    {
                        flag = false;
                        subSets.Remove(subItem);//remove it so in the end only the canidades will left
                    }
                }

                if (flag)//all subsets are frequent, so the new itemset i a canidade
                    canidades.Add(sets[i]);
            }

            Dictionary<ItemSet, double> result = new Dictionary<ItemSet, double>();
            double freq = 0;
            foreach (var canidade in canidades) //calculate the frequence in the DB
            {
                freq = calculateFrequence(canidade);
                result.Add(canidade, frequence);
            }
            return result;
        }

        public List<List<int>> convertToInt(List<List<Product>> input)
        {
            List<List<Product>> setsOfProducts = input;
            Product p;
            int pid;
            List<int> listOfPID;
            List<List<int>> convertResult = new List<List<int>>();
            foreach (var listOfProducts in setsOfProducts)
            {
                listOfPID = new List<int>();
                for (int i = 0; i < listOfProducts.Count; i++)
                {
                    p = listOfProducts[i];
                    pid = p.pid;
                    listOfPID.Add(pid);
                }
                convertResult.Add(listOfPID);
            }
            return convertResult;
        }

        public List<ItemSet> convertToSet(List<List<int>> listsOfInt)
        {
            List<int> lstInt;
            ItemSet iset;
            List<ItemSet> convertResult = new List<ItemSet>();
            foreach (var list in listsOfInt)
            {
                list.Distinct();
                lstInt = list;
                iset = new ItemSet();
                iset.items = lstInt;
                iset.k = lstInt.Count;
                convertResult.Add(iset);
            }
            return convertResult;
        }

        public double calculateFrequence(ItemSet iset)
        {
            List<ItemSet> inputSets = convertToSet(this.inputIntSets);
            double counter = 0;
            for (int i = 0; i < inputSets.Count; i++)
            {
                if (iset.items.All(inputSets[i].items.Contains))
                    counter++;
            }

            return (counter / inputSets.Count);
        }

        private Dictionary<ItemSet, double> getFrequenceOnly(Dictionary<ItemSet, double> itemSets)
        {
            Dictionary<ItemSet, double> frequenceOnly = (Dictionary<ItemSet, double>)itemSets.Where(set => set.Value > treshold);
            return frequenceOnly;
        }

        public double getFrequence(ItemSet itemset)
        {
            Dictionary<ItemSet, double> d = this.allSets;
            ItemSet currerntSet;
            List<int> firstNotSecond;
            List<int> SecondNotfirst;
            double currentVal;
            for (int k = 0; k < allSets.Count; k++)
            {
                currerntSet = allSets.ElementAt(k).Key;
                currentVal = this.allSets.ElementAt(k).Value;
                firstNotSecond = itemset.items.Except(currerntSet.items).ToList();
                SecondNotfirst = currerntSet.items.Except(itemset.items).ToList();
                if (firstNotSecond.Count == 0 && SecondNotfirst.Count == 0)//iset == allItemSets[i], the specific one
                    return currentVal;
            }
            return 0;
        }

        public List<List<int>> GetSubSets<T>(IEnumerable<int> Set)
        {
            var set = Set.ToList<int>();
            List<List<int>> subsets = new List<List<int>>();
            List<List<int>> newSubsets;

            subsets.Add(new List<int>()); // add the empty set

            // Loop over individual elements
            for (int i = 1; i < set.Count; i++)
            {
                subsets.Add(new List<int>() { set[i - 1] });

                newSubsets = new List<List<int>>();

                // Loop over existing subsets
                for (int j = 1; j < subsets.Count; j++)
                {
                    var newSubset = new List<int>();
                    foreach (var temp in subsets[j])
                        newSubset.Add(temp);
                    newSubset.Add(set[i]);
                    newSubsets.Add(newSubset);
                }
                subsets.AddRange(newSubsets);
            }

            // Add in the last element
            subsets.Add(new List<int>() { set[set.Count - 1] });
            //subsets.Sort();
            ItemSet iset = new ItemSet();
            List<ItemSet> itemSubSets = new List<ItemSet>();
            foreach (var subset in subsets)
            {
                iset = new ItemSet();
                iset.items = subset;
                iset.k = iset.items.Count;
                itemSubSets.Add(iset);
            }
            return subsets;
        }

        public List<AssociationRule> GetAssociationRules(Dictionary<ItemSet, double> freqItemSets)
        {
            List<AssociationRule> associationRules = new List<AssociationRule>();
            List<AssociationRule> result = new List<AssociationRule>();
            foreach (var itemset in freqItemSets)
            {
                result.AddRange(calculateRules(itemset.Key));
            }

            if (result.Count == 0)
                return result;

            associationRules = Comperator.containRules(result);//contains

            List<AssociationRule> unique = new List<AssociationRule>();
            bool flag1 = false;
            for (int i = 0; i < associationRules.Count; i++)//equals
            {
                flag1 = false;
                if (unique.Count == 0)
                {
                    unique.Add(associationRules[i]);
                    continue;
                }

                for (int j = 0; j < unique.Count; j++)
                {
                    if (Comperator.EqualsRules(unique[j], associationRules[i]))
                    {
                        flag1 = true;
                        break;
                    }
                }

                if (flag1 == false)
                {
                    unique.Add(associationRules[i]);
                }
            }

            associationRules = unique;
            return associationRules.OrderByDescending(a => a.Confidance).ToList();

        }

        public List<AssociationRule> calculateRules(ItemSet iset)
        {
            List<AssociationRule> associationRules = new List<AssociationRule>();
            List<List<int>> subsets = GetSubSets<int>(iset.items);
            AssociationRule rule;
            List<int> xside = new List<int>();
            List<int> yside;
            List<int> union = new List<int>();
            ItemSet tempISet, ruleISet;
            double support, unionSupport, confidence;

            foreach (var sub in subsets)
            {
                if (sub.Count == 0 || sub.Count == iset.items.Count)
                    continue;
                else
                    xside = sub;
                yside = iset.items.Except(xside).ToList();
                tempISet = new ItemSet();
                tempISet.items = xside;
                tempISet.k = xside.Count;
                support = Math.Round(calculateFrequence(tempISet) * 100, 2);
                ruleISet = new ItemSet();
                union = new List<int>();
                union.AddRange(xside);
                union.AddRange(yside);
                union = union.Distinct().ToList();
                ruleISet.items = union;
                ruleISet.k = union.Count;
                unionSupport = Math.Round(calculateFrequence(ruleISet) * 100, 2);
                confidence = Math.Round((unionSupport / support) * 100, 2);

                rule = new AssociationRule();
                rule.xSide = xside;
                rule.ySide = yside;
                rule.Support = unionSupport;
                rule.Confidance = confidence;
                associationRules.Add(rule);
            }

            return associationRules;
        }

        public List<string> getFormatRules(List<AssociationRule> rules)
        {
            List<string> rulesFormat = new List<string>();
            foreach (var rule in rules)
            {
                rulesFormat.Add(getFormatRule(rule));
            }
            return rulesFormat;
        }

        public string getFormatRule(AssociationRule rule)
        {
            string s = Helper.ToDisplay(rule);
            return s;
        }
    }
}

