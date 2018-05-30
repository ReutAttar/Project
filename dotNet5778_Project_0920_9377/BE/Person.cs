using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Person
    {
        public String ID { get; set; }
        public String Lastname { get; set; }
        public String FirstName { get; set; }
        public String Tel { get; set; }
        public Address PersonAddress { get; set; }
        public override string ToString()
        {
            string result = "";
            result += "ID: " + ID + "\n";
            result += "Name: " + Lastname + " " + FirstName + "\n";
            result += "Phone number: " + Tel + "\n";
            result += "Person Address: " + PersonAddress.ToString();
            return result;
        }
    }
}
