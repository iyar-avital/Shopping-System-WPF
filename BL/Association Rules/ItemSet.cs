using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ItemSet
    {
        public int k; // number of items
        public List<int> items;

        public ItemSet()
        {
            items = new List<int>();
        }

        public ItemSet(int pid)
        {
            k = 1;
            items = new List<int>();
            items.Add(pid);
        }

        public ItemSet MakeKPlus1Set(ItemSet i1, ItemSet i2)
        {
            if (i1.k != i2.k)
                return null;
            ItemSet Result = new ItemSet();
            List<int> firstNotSecond = i1.items.Except(i2.items).ToList();
            if (firstNotSecond.Count == 1)
            {
                Result.k = i1.k + 1;
                Result.items.AddRange(i2.items);
                Result.items.AddRange(firstNotSecond);
                Result.items.Sort();
            }
            return Result;
        }
    }
}
