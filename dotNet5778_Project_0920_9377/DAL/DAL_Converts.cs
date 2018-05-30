using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public static class DAL_Converts
    {
        // convert each entiti to a XML 

        #region  Mother 
        public static XElement MotherToXml(Mother mother)
        {
            return new XElement("mother",
                new XElement("ID", mother.ID),
                new XElement("FirstName", mother.FirstName),
                new XElement("Lastname", mother.Lastname),
                new XElement("Tel", mother.Tel),
                new XElement("PersonAddress", new XElement("City", mother.PersonAddress.City), new XElement("Country", mother.PersonAddress.Country), new XElement("Street", mother.PersonAddress.Street), new XElement("Number", mother.PersonAddress.Number)),
                new XElement("TelHome", mother.TelHome),
                new XElement("GoalAddress", new XElement("City", mother.GoalAddress.City), new XElement("Country", mother.GoalAddress.Country), new XElement("Street", mother.GoalAddress.Street), new XElement("Number", mother.GoalAddress.Number)),
                new XElement("HoursNeed",
                    (from d in mother.HoursNeed
                     select new XElement("Day",
                 new XAttribute("Day", d.Key.ToString()),
                 new XElement("Start", d.Value.Key.ToString()),
                 new XElement("End", d.Value.Value.ToString())
                 ))),
                new XElement("MotherAccount", new XElement("AccountNumber", mother.MotherAccount.AccountNumber), new XElement("BankName", mother.MotherAccount.BankName), new XElement("BankAdress", mother.MotherAccount.BankAdress), new XElement("BranchNumber", mother.MotherAccount.BranchNumber), new XElement("Balance", mother.MotherAccount.Balance))
               );
        }

        public static Mother XmlToMother(this XElement motherXml)
        {
            Mother result = null;
            if (motherXml == null)
            {
                return result;
            }
            else
            {
                result = new Mother
                {
                    ID = motherXml.Element("ID").Value,
                    FirstName = motherXml.Element("FirstName").Value,
                    Lastname = motherXml.Element("Lastname").Value,
                    Tel = motherXml.Element("Tel").Value,
                    PersonAddress = new Address()
                    {
                        City = motherXml.Element("PersonAddress").Element("City").Value,
                        Country = motherXml.Element("PersonAddress").Element("Country").Value,
                        Street = motherXml.Element("PersonAddress").Element("Street").Value,
                        Number = Int32.Parse(motherXml.Element("PersonAddress").Element("Number").Value)
                    },
                    TelHome = motherXml.Element("TelHome").Value,
                    GoalAddress = new Address()
                    {
                        City = motherXml.Element("GoalAddress").Element("City").Value,
                        Country = motherXml.Element("GoalAddress").Element("Country").Value,
                        Street = motherXml.Element("GoalAddress").Element("Street").Value,
                        Number = Int32.Parse(motherXml.Element("GoalAddress").Element("Number").Value)
                    },
                    HoursNeed = XmlToMotherDictionary(motherXml),
                    //MotherAccount = new BankAccount
                    //{
                    //    Balance = double.Parse(motherXml.Element("MotherAccount").Element("Balance").Value),
                    //    AccountNumber = Int32.Parse(motherXml.Element("MotherAccount").Element("AccountNumber").Value),
                    //    BranchNumber = Int32.Parse(motherXml.Element("MotherAccount").Element("BranchNumber").Value),
                    //    BankName = (BankName)Enum.Parse(typeof(BankName), motherXml.Element("MotherAccount").Element("BranchNumber").Value),
                    //    BankAdress = (Address)Enum.Parse(typeof(Address), motherXml.Element("MotherAccount").Element("BankAdress").Value),
                    //}
                };
            }
            return result;
        }

        private static Dictionary<DayOfWeek, KeyValuePair<int, int>> XmlToMotherDictionary(this XElement motherXml)
        {
            Dictionary<DayOfWeek, KeyValuePair<int, int>> MyDictionary = new Dictionary<DayOfWeek, KeyValuePair<int, int>>();
            foreach (var e in motherXml.Element("HoursNeed").Elements("Day"))
            {
                MyDictionary.Add((DayOfWeek)Enum.Parse(typeof(DayOfWeek), (e.Attribute("Day").Value)), new KeyValuePair<int, int>(Convert.ToInt32(e.Element("Start").Value), Convert.ToInt32(e.Element("End").Value)));
            }
            return MyDictionary;
        }
        #endregion

        #region Nanny
        public static XElement NannyToXml(Nanny nanny)
        {
            return new XElement("nanny",
                new XElement("ID", nanny.ID),
                new XElement("FirstName", nanny.FirstName),
                new XElement("Lastname", nanny.Lastname),
                new XElement("Tel", nanny.Tel),
                new XElement("PersonAddress", new XElement("City", nanny.PersonAddress.City), new XElement("Country", nanny.PersonAddress.Country), new XElement("Street", nanny.PersonAddress.Street), new XElement("Number", nanny.PersonAddress.Number)),
                new XElement("Birthday", nanny.Birthday),
                new XElement("Floor", nanny.Floor),
                new XElement("Elevator", nanny.Elevator),
                new XElement("Experience", nanny.Experience),
                new XElement("MaxChildrens", nanny.MaxChildrens),
                new XElement("MaxChildrensAge", nanny.MaxChildrensAge),
                new XElement("MinChildrensAge", nanny.MinChildrensAge),
                new XElement("RateForHour", nanny.RateForHour),
                new XElement("SalaryForMonth", nanny.SalaryForMonth),
                new XElement("WorkHours",
                    (from d in nanny.WorkHours
                     select new XElement("Day",
                 new XAttribute("Day", d.Key.ToString()),
                 new XElement("Start", d.Value.Key.ToString()),
                 new XElement("End", d.Value.Value.ToString())
                 ))),
                new XElement("VacationDays", nanny.VacationDays),
                new XElement("MyRecommendations", nanny.MyRecommendations),
                new XElement("NannyAccount", new XElement("AccountNumber", nanny.MyBankAccount.AccountNumber), new XElement("BankName", nanny.MyBankAccount.BankName), new XElement("BankAdress", nanny.MyBankAccount.BankAdress), new XElement("BranchNumber", nanny.MyBankAccount.BranchNumber), new XElement("Balance", nanny.MyBankAccount.Balance)),
                new XElement("range", nanny.range)
                );
        }

        public static Nanny XmlToNanny(this XElement nannyXml)
        {
            Nanny result = null;
            if (nannyXml == null)
            {
                return result;
            }
            else
            {
                result = new Nanny
                {
                    ID = nannyXml.Element("ID").Value,
                    FirstName = nannyXml.Element("FirstName").Value,
                    Lastname = nannyXml.Element("Lastname").Value,
                    Tel = nannyXml.Element("Tel").Value,
                    PersonAddress = new Address()
                    {
                        City = nannyXml.Element("PersonAddress").Element("City").Value,
                        Country = nannyXml.Element("PersonAddress").Element("Country").Value,
                        Street = nannyXml.Element("PersonAddress").Element("Street").Value,
                        Number = Int32.Parse(nannyXml.Element("PersonAddress").Element("Number").Value)
                    },
                    Birthday = Convert.ToDateTime(nannyXml.Element("Birthday").Value),
                    Floor = Int32.Parse(nannyXml.Element("Floor").Value),
                    Elevator = Boolean.Parse(nannyXml.Element("Elevator").Value),
                    Experience = Int32.Parse(nannyXml.Element("Experience").Value),
                    MaxChildrens = Int32.Parse(nannyXml.Element("MaxChildrens").Value),
                    MaxChildrensAge = float.Parse(nannyXml.Element("MaxChildrensAge").Value),
                    MinChildrensAge = float.Parse(nannyXml.Element("MinChildrensAge").Value),
                    RateForHour = float.Parse(nannyXml.Element("RateForHour").Value),
                    SalaryForMonth = float.Parse(nannyXml.Element("SalaryForMonth").Value),
                    WorkHours = XmlToNannyDictionary(nannyXml),
                    VacationDays = Boolean.Parse(nannyXml.Element("VacationDays").Value),
                    MyRecommendations = nannyXml.Element("MyRecommendations").Value,

                    //MyBankAccount = new BankAccount
                    //{
                    //    Balance = double.Parse(nannyXml.Element("NannyAccount").Element("Balance").Value),
                    //    AccountNumber = Int32.Parse(nannyXml.Element("MotherAccount").Element("AccountNumber").Value),
                    //    BranchNumber = Int32.Parse(nannyXml.Element("MotherAccount").Element("BranchNumber").Value),
                    //    BankName = (BankName)Enum.Parse(typeof(BankName), nannyXml.Element("MotherAccount").Element("BranchNumber").Value),
                    //    BankAdress = (Address)Enum.Parse(typeof(Address), nannyXml.Element("MotherAccount").Element("BankAdress").Value),
                    //},
                    range = nannyXml.Element("range").Value
                };
            }
            return result;
        }


        private static Dictionary<DayOfWeek, KeyValuePair<int, int>> XmlToNannyDictionary(XElement nannyXml)
        {
            Dictionary<DayOfWeek, KeyValuePair<int, int>> MyDictionary = new Dictionary<DayOfWeek, KeyValuePair<int, int>>();
            foreach (var e in nannyXml.Element("WorkHours").Elements("Day"))
            {
                MyDictionary.Add((DayOfWeek)Enum.Parse(typeof(DayOfWeek), (e.Attribute("Day").Value)), new KeyValuePair<int, int>(Convert.ToInt32(e.Element("Start").Value), Convert.ToInt32(e.Element("End").Value)));
            }
            return MyDictionary;
        }
        #endregion

        #region Child
        public static XElement ChildToXml(Child child)
        {
            return new XElement("child",
                new XElement("ID", child.ID),
                new XElement("MyMotherID", child.MyMotherID),
                new XElement("FirstName", child.FirstName),
                new XElement("Birthday", child.Birthday),
                new XElement("SpecialNeeds", child.SpecialNeeds),
                new XElement("Needs", child.Needs),
                new XElement("Allergy", child.Allergy),
                new XElement("MyAllergy", child.MyAllergy),
                new XElement("MyNutrition", child.MyNutrition)
               );
        }

        public static Child XmlToChild(this XElement childXml)
        {
            Child result = null;
            if (childXml == null)
            {
                return result;
            }
            else
            {
                result = new Child
                {
                    ID = childXml.Element("ID").Value,
                    MyMotherID = childXml.Element("MyMotherID").Value,
                    FirstName = childXml.Element("FirstName").Value,
                    Birthday = Convert.ToDateTime(childXml.Element("Birthday").Value),
                    SpecialNeeds = Boolean.Parse(childXml.Element("SpecialNeeds").Value),
                    Needs = childXml.Element("Needs").Value,
                    Allergy = Boolean.Parse(childXml.Element("Allergy").Value),
                    MyAllergy = childXml.Element("MyAllergy").Value,
                    MyNutrition = childXml.Element("MyNutrition").Value
                };
            }
            return result;
        }
        #endregion

        #region Contract
        public static XElement ContractToXml(Contract contract)
        {
            return new XElement("contract",
                new XElement("ContractNumber", contract.ContractNumber),
                new XElement("NannyID", contract.NannyID),
                new XElement("ChildID", contract.ChildID),
                new XElement("MotherID", contract.MotherID),
                new XElement("Interview", contract.Interview),
                new XElement("ContractSigned", contract.ContractSigned),
                new XElement("Payment", contract.Payment),
                new XElement("TotalPay", contract.TotalPay),
                new XElement("AnotherChild", contract.AnotherChild),
                new XElement("EmploymentHours",
                    (from d in contract.EmploymentHours
                     select new XElement("Day",
                 new XAttribute("Day", d.Key.ToString()),
                 new XElement("Start", d.Value.Key.ToString()),
                 new XElement("End", d.Value.Value.ToString())
                 ))),
                new XElement("StartEmployment", contract.StartEmployment),
                new XElement("EndEmployment", contract.EndEmployment),
                new XElement("TotalHours", contract.TotalHours)
               );
        }

        public static Contract XmlToContract(this XElement contractXml)
        {
            Contract result = null;
            if (contractXml == null)
            {
                return result;
            }
            else
            {
                result = new Contract
                {
                    ContractNumber = Int32.Parse(contractXml.Element("ContractNumber").Value),
                    NannyID = contractXml.Element("NannyID").Value,
                    ChildID = contractXml.Element("ChildID").Value,
                    MotherID = contractXml.Element("MotherID").Value,
                    Interview = Boolean.Parse(contractXml.Element("Interview").Value),
                    ContractSigned = Boolean.Parse(contractXml.Element("ContractSigned").Value),
                    Payment = Boolean.Parse(contractXml.Element("Payment").Value),
                    TotalPay = float.Parse(contractXml.Element("TotalPay").Value),
                    AnotherChild = Boolean.Parse(contractXml.Element("AnotherChild").Value),
                    EmploymentHours = XmlToContractDictionary(contractXml),
                    StartEmployment = Convert.ToDateTime(contractXml.Element("StartEmployment").Value),
                    EndEmployment = Convert.ToDateTime(contractXml.Element("EndEmployment").Value),
                    TotalHours = float.Parse(contractXml.Element("TotalHours").Value)
                };
            }
            return result;
        }

        private static Dictionary<DayOfWeek, KeyValuePair<int, int>> XmlToContractDictionary(XElement contractXml)
        {
            Dictionary<DayOfWeek, KeyValuePair<int, int>> MyDictionary = new Dictionary<DayOfWeek, KeyValuePair<int, int>>();
            foreach (var e in contractXml.Element("EmploymentHours").Elements("Day"))
            {
                MyDictionary.Add((DayOfWeek)Enum.Parse(typeof(DayOfWeek), (e.Attribute("Day").Value)), new KeyValuePair<int, int>(Convert.ToInt32(e.Element("Start").Value), Convert.ToInt32(e.Element("End").Value)));
            }
            return MyDictionary;
        }
        #endregion

        #region BankAccount
        public static XElement BankAccountToXml(BankAccount bank)
        {
            return new XElement("bankaccount",
                new XElement("AccountNumber", bank.AccountNumber),
                new XElement("BankName", bank.BankName),
                new XElement("BranchNumber", bank.BranchNumber),
                new XElement("BankAdress", bank.BankAdress),
                new XElement("Balance", bank.Balance));
        }

        public static BankAccount XmlToBankAccount(this XElement bankXml)
        {
            BankAccount result;
            if (bankXml == null)
            {
                return (BankAccount)Enum.Parse(typeof(BankName), null);
            }
            else
            {
                result = new BankAccount
                {
                    AccountNumber = Int32.Parse(bankXml.Element("AccountNumber").Value),
                    BankName = (BankName)Enum.Parse(typeof(BankName), bankXml.Element("BankName").Value),
                    BranchNumber = Int32.Parse(bankXml.Element("BranchNumber").Value),
                    BankAdress = (Address)Enum.Parse(typeof(Address), bankXml.Element("MotherID").Value),
                    Balance = double.Parse(bankXml.Element("Balance").Value)
                };
            }
            return result;
        }
        #endregion
    }
}


