using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_library
{
    public class TupleTree
    {
        private readonly string item1;
        private readonly int item2;
        private readonly string item3;

        public string Item1 { get { return item1; } }
        public int Item2 { get { return item2; } }
        public string Item3 { get { return item3; } }

        public TupleTree(string first, int second, string third = "none")
        {
            item1 = first;
            item2 = second;
            item3 = third;
        }

        bool isNode()
        {
            if (item1 == "N")
                return true;
            return false;
        }
    }
}
