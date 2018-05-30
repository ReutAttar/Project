using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother : Person
    {
        public String TelHome { get; set; }
        public Address GoalAddress { get; set; }
        public Dictionary<DayOfWeek, KeyValuePair<int, int>> HoursNeed { get; set; }
        public BankAccount MotherAccount { get; set; }
        public override string ToString()
        {
            string result = base.ToString();
            result += "Tel at home: " + TelHome + "\n";
            result += "I need nanny in this area: " + GoalAddress.ToString() + "\n";
            result += "I Need nanny for: \n";
            foreach (var item in HoursNeed)
            {
                result += "day: " + item.Key + "\t";
                result += "hours: " + item.Value.Key / 100 + ":" + (item.Value.Key % 100 == 0 ? "00" : (item.Value.Key % 100).ToString()) + " - " + item.Value.Value / 100 + ":" + (item.Value.Value % 100 == 0 ? "00" : (item.Value.Value % 100).ToString()) + "\n";
            }
            //result += MotherAccount.ToString() + "\n";
            return result;
        }
    }
}
