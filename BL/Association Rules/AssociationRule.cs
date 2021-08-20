using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public class AssociationRule
    {
        public AssociationRule(List<int> x, List<int> y, double c)
        {
            this.xSide = x;
            this.ySide = y;
            this.Confidance = c;
        }
        public AssociationRule() 
        {
            this.xSide = new List<int>(); ;
            this.ySide = new List<int>();
            this.Confidance = 0;
        }

        public List<int> xSide { get; set; }
        public List<int> ySide { get; set; }
        public double Confidance { get; set; }
        public double Support { get; set; }
    }
}
