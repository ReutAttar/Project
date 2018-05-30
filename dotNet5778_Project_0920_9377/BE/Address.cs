using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public struct Address
    {
        public int Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            string result = "";
            result += Street + " ";
            result += Number + ", ";
            result += City + ", ";
            result += Country + "\n ";
            return result;
        }
    }
}
