using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plecak
{
    internal class Result
    {
        public List<int> mochillas_items;
        public int all_values;
        public int all_weights;

        public Result()
        {
            mochillas_items = new List<int>();
            all_values = 0;
            all_weights = 0;
        }
        public override string ToString()
        {
            string r="";
            r = "items: ";
            foreach (int i in mochillas_items)
            {
                r += i.ToString();
                r += " ";
            }
            r += Environment.NewLine;
            r += "total value: ";
            r += all_values.ToString();
            r+= Environment.NewLine;
            r += "total weight: ";
            r += all_weights.ToString();

            return r;
        }
    }
}
