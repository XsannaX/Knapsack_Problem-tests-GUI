using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
[assembly: InternalsVisibleTo("TestProject1")]
namespace Plecak
{
    internal class Mochila
    {

        private int _number { get; set; }
        private int _seed { get; set; }
        public List<int> values { get; set; }
        public List<int> weight { get; set; }
        public Mochila(int n, int seed)
        {
            _number = n;
            _seed = seed;
            values = new List<int>();
            weight = new List<int>();
            Random random = new Random(_seed);
            for (int i = 0; i < n; i++)
            {
                values.Add(random.Next(1,11));
            }
            for (int i = 0; i < n; i++)
            {
                weight.Add(random.Next(1,11));
            }

         
        }
        public Result Solve(int capacity)
        {
            Result result = new Result();

            List<Item> items = new List<Item>();
            for (int i = 0; i < weight.Count; i++)
            {
                items.Add(new Item(weight[i], values[i], i));
            }

            items.Sort((x, y) => y.ValWeightRatio.CompareTo(x.ValWeightRatio));


            foreach (Item item in items)
            {
                if (capacity >= item.Weight)
                {
                    result.mochillas_items.Add(item.Id);
                    result.all_values += item.Values;
                    result.all_weights += item.Weight;
                    capacity -= item.Weight;
                }
            }

            return result;
        }
        public override string ToString()
        {
            string r = "";
            for (int i = 0; i < _number;i++)
            {
                r += "n: ";
                r += i.ToString();
                r+= " v: ";
                r += values[i].ToString();
                r += " w: ";
                r += weight[i].ToString();
                r += Environment.NewLine;
            }
            return r;
        }


    }
    class Item
    {
        public int Weight { get; set; }
        public int Values { get; set; }
        public double ValWeightRatio { get; set; }
        public int Id { get; set; }

        public Item(int weight, int val, int id)
        {
            Weight = weight;
            Values = val;
            Id = id;
            ValWeightRatio = (float)val / weight;
        }
    }
}
