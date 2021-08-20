using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class Helper
    {
        public static string ToDisplay(AssociationRule rule)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ToDisplay(rule.xSide));
            sb.Append(" => ");
            sb.Append(ToDisplay(rule.ySide));
            sb.Append("  with confidence of: ");
            sb.Append(rule.Confidance.ToString());
            return sb.ToString();
        }

        public static string ToDisplay(this List<int> list, string separator = ", ")
        {
            if (list.Count == 0)
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");
            sb.Append(list[0]);
            for (int i = 1; i < list.Count; i++)
            {
                sb.Append(string.Format("{0}{1}", separator, list[i]));
            }
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
