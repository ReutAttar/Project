using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny : Person
    {
        public DateTime Birthday { get; set; }
        public int Floor { get; set; }
        public bool Elevator { get; set; }
        public int Experience { get; set; }
        public int MaxChildrens { get; set; }
        public float MinChildrensAge { get; set; }
        public float MaxChildrensAge { get; set; }
        public float RateForHour { get; set; }
        public float SalaryForMonth { get; set; }
        public Dictionary<DayOfWeek, KeyValuePair<int, int>> WorkHours { get; set; }
        public bool VacationDays { get; set; } //if tamat->true
        public string MyRecommendations { get; set; }
        public BankAccount MyBankAccount { get; set; }
        public string range { get; set; }
        public float averageRate { get; set; }
        public override string ToString()
        {
            string result = base.ToString();
            result += "Birthday: " + Birthday.ToString("dd/MM/yyyy") + "\n";
            result += "Work Hours:\n";
            foreach (var item in WorkHours)
            {
                result += "day: " + item.Key + "\t";
                result += "hours: " + item.Value.Key / 100 + ":" + (item.Value.Key % 100 == 0 ? "00" : (item.Value.Key % 100).ToString()) + " - " + item.Value.Value / 100 + ":" + (item.Value.Value % 100 == 0 ? "00" : (item.Value.Value % 100).ToString()) + "\n";
            }
            result += "Maximum Childrens: " + MaxChildrens + "\n";
            result += "Minimum Childrens Age: " + MinChildrensAge + "\n";
            result += "Maximum Childrens Age: " + MaxChildrensAge + "\n";
            result += "Rate For Hour: " + RateForHour + "\n";
            result += "Salary For Month: " + SalaryForMonth + "\n";
            result += "Experience: " + Experience + " Years" + "\n";
            result += "Average Rate: " + averageRate + "\n";
            return result;
        }
    }
}
