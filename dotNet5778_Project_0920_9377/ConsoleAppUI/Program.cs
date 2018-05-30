using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BL.IBL mybl = BL.FactoryBL.GetInstance;

            Dictionary<DayOfWeek, KeyValuePair<int, int>> Need = new Dictionary<DayOfWeek, KeyValuePair<int, int>>();
            DateTime d = new DateTime(1994, 4, 21);
            DateTime d2 = new DateTime(2016, 4, 21);
            BankAccount bank = new BankAccount { AccountNumber = 1, BankName = BankName.Discont, BranchNumber = 10, BankAdress = new Address { Number = 12, Street = "Hadekel", City = "Eilat", Country = "Israel" } };
            Address A = new Address { Street = "beit hadfus", Number = 7, City = "JERUSALEM", Country = "ISRAEL" };
            Address B = new Address { Street = "beit hadfus", Number = 11, City = "JERUSALEM", Country = "ISRAEL" };
            Address C = new Address { Street = "beit hadfus", Number = 21, City = "JERUSALEM", Country = "ISRAEL" };

            List<string> s = new List<string>();
            Mother m = new Mother { ID = "333", PersonAddress = A, FirstName = "asa", Lastname = "faf", GoalAddress = B, HoursNeed = Need, MotherAccount = bank, Tel = "30484", TelHome = "39853" };
            Mother m1 = new Mother { ID = "888", PersonAddress = B, FirstName = "asa", Lastname = "faf", GoalAddress = B, HoursNeed = Need, MotherAccount = bank, Tel = "30484", TelHome = "39853" };
            Mother m2 = new Mother { ID = "777", PersonAddress = C, FirstName = "asa", Lastname = "faf", GoalAddress = B, HoursNeed = Need, MotherAccount = bank, Tel = "30484", TelHome = "39853" };
            mybl.AddMother(m);
            mybl.AddMother(m1);
            mybl.AddMother(m2);

            Nanny n = new Nanny { ID = "355", PersonAddress = C, VacationDays = true, Birthday = d, Elevator = false, Experience = 4, FirstName = "nana", Floor = 2, SalaryForMonth = 300, Lastname = "poly", MaxChildrens = 12, MaxChildrensAge = 12, MinChildrensAge = 2, MyBankAccount = bank, MyRecommendations = "very good", range = "2-12", RateForHour = 34, Tel = "24769786", WorkHours = Need };
            Nanny n2 = new Nanny { ID = "385", PersonAddress = A, VacationDays = true, Birthday = d, Elevator = false, Experience = 5, FirstName = "nana", Floor = 2, SalaryForMonth = 300, Lastname = "poly", MaxChildrens = 12, MaxChildrensAge = 12, MinChildrensAge = 2, MyBankAccount = bank, MyRecommendations = "very good", range = "2-12", RateForHour = 34, Tel = "24769786", WorkHours = Need };
            Nanny n3 = new Nanny { ID = "395", PersonAddress = B, VacationDays = true, Birthday = d, Elevator = false, Experience = 3, FirstName = "nana", Floor = 2, SalaryForMonth = 300, Lastname = "poly", MaxChildrens = 12, MaxChildrensAge = 18, MinChildrensAge = 5, MyBankAccount = bank, MyRecommendations = "very good", range = "5-18", RateForHour = 34, Tel = "24769786", WorkHours = Need };
            mybl.AddNanny(n);
            mybl.AddNanny(n2);
            mybl.AddNanny(n3);

            Child CH = new Child { ID = "555", Allergy = false, Birthday = d2, SpecialNeeds = false, MyMotherID = "333", FirstName = "BABY", Needs = "s", MyAllergy="nuts", MyNutrition="materna" };
            Child CH1 = new Child { ID = "790", Allergy = false, Birthday = d2, SpecialNeeds = false, MyMotherID = "333", FirstName = "BABY", Needs = "s" };
            Child CH2 = new Child { ID = "476", Allergy = false, Birthday = d2, SpecialNeeds = false, MyMotherID = "333", FirstName = "BABY", Needs ="s" };
            mybl.AddChild(CH);
            mybl.AddChild(CH1);
            mybl.AddChild(CH2);

            Contract C1 = new Contract { NannyID = "355", ChildID = "555", MotherID = "333", EmploymentHours = Need, Payment = true };
            Contract C2 = new Contract { NannyID = "385", ChildID = "790", MotherID = "888", EmploymentHours = Need, Payment = true };
            Contract C3 = new Contract { NannyID = "395", ChildID = "476", MotherID = "777", EmploymentHours = Need, Payment = true };

            mybl.AddContract(C1);
            mybl.AddContract(C2);
            mybl.AddContract(C3);

            List<Nanny> nannys = mybl.SelectedNannys(22, Need, 400, 4, 14, 5);
            // List<Contract> list = mybl.SelectedContracts(c => c.ChildID == "555");
            // int num = mybl.NumOfSelectedContracts(c => c.ChildID == "555");
            //IEnumerable<IGrouping<string, Nanny>> range = mybl.GroupNannyByChildAge(false);
            //IEnumerable<IGrouping<int, Contract>> cont = mybl.GroupContractByDistanceBetweenNannyAndChild(true);
            //mybl.SelectedNanniesByAddress(A,10,false,19, Need,400,30,2,12,10);
            //bool dis=mybl.Distance(A, B,10) ; 
        }
    }
}
