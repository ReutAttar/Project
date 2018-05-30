using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        public int ContractNumber { get; set; }
        public String NannyID { get; set; }
        public String ChildID { get; set; }
        public String MotherID { get; set; }
        public bool Interview { get; set; }
        public bool ContractSigned { get; set; }
        public bool Payment { get; set; }//mother choose how to pay, by month or by hours ,true=>by month false=>by hours
        public float TotalPay { get; set; } //how much mother need to pay
        public bool AnotherChild { get; set; }
        public Dictionary<DayOfWeek, KeyValuePair<int, int>> EmploymentHours { get; set; }
        public DateTime StartEmployment { get; set; }
        public DateTime EndEmployment { get; set; }
        public float TotalHours { get; set; }
        public override string ToString()
        {
            string result = "";
            result += "Contract number: " + ContractNumber + "\n";
            result += "Start employment: " + StartEmployment.ToString("dd/MM/yyyy") + "\t" + "End employment: " + EndEmployment.ToString("dd/MM/yyyy") + "\n";
            result += "Nanny ID: " + NannyID + "     " + "Child ID: " + ChildID + "     " + "Mother ID: " + MotherID + "\n";
            result += "Interview has been done: " + (Interview ? "YES" : "NO") + "\n";
            result += "Contract has been signed: " + (ContractSigned ? "YES" : "NO") + "\n";
            result += "Mother choose to pay by: " +(Payment ? "Month" : "Hours") + "\n";
            result += "TotalPay: " + TotalPay + "\n";
            result += "Another child: " + (AnotherChild ? "YES" : "NO") + "\n";
            result += "Schedule: " + "\n";
            foreach (var item in EmploymentHours)
            {
                result += "day: " + item.Key + "\t";
                result += "hours: " + item.Value.Key / 100 + ":" + (item.Value.Key % 100 == 0 ? "00" : (item.Value.Key % 100).ToString()) + " - " + item.Value.Value / 100 + ":" + (item.Value.Value % 100 == 0 ? "00" : (item.Value.Value % 100).ToString()) + "\n";
            }
            result += "Total hours for month: " + TotalHours + "\n";
            return result;
        }
    }
}
