using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal static class BE_Extensions
    {
        internal static Child ChildDeepClone(this Child source)
        {
            return new Child
            {
                ID = source.ID,
                MyMotherID = source.MyMotherID,
                FirstName = source.FirstName,
                Birthday = source.Birthday,
                SpecialNeeds = source.SpecialNeeds,
                Needs = source.Needs,
                Allergy = source.Allergy,
                MyAllergy = source.MyAllergy,
                MyNutrition = source.MyNutrition
            };
        }
        internal static Mother MotherDeepClone(this Mother source)
        {
            return new Mother
            {
                ID = source.ID,
                FirstName = source.FirstName,
                Lastname = source.Lastname,
                Tel = source.Tel,
                PersonAddress = source.PersonAddress,
                TelHome = source.TelHome,
                GoalAddress = source.GoalAddress,
                HoursNeed = new Dictionary<DayOfWeek, KeyValuePair<int, int>>(source.HoursNeed)
            };
        }
        internal static Nanny NannyDeepClone(this Nanny source)
        {
            return new Nanny
            {
                ID = source.ID,
                FirstName = source.FirstName,
                Lastname = source.Lastname,
                Tel = source.Tel,
                range = source.range,
                PersonAddress = source.PersonAddress,
                Birthday = source.Birthday,
                Floor = source.Floor,
                Elevator = source.Elevator,
                Experience = source.Experience,
                MaxChildrens = source.MaxChildrens,
                MinChildrensAge = source.MinChildrensAge,
                MaxChildrensAge = source.MaxChildrensAge,
                RateForHour = source.RateForHour,
                SalaryForMonth = source.SalaryForMonth,
                WorkHours = new Dictionary<DayOfWeek, KeyValuePair<int, int>>(source.WorkHours),
                VacationDays = source.VacationDays,
                MyRecommendations = source.MyRecommendations,
                MyBankAccount = source.MyBankAccount,
                averageRate=source.averageRate  
            };
        }
        internal static Contract ContractDeepClone(this Contract source)
        {
            return new Contract
            {
                ContractNumber = source.ContractNumber,
                NannyID = source.NannyID,
                ChildID = source.ChildID,
                MotherID=source.MotherID,
                Interview = source.Interview,
                ContractSigned = source.ContractSigned,
                Payment = source.Payment,
                TotalPay = source.TotalPay,
                AnotherChild = source.AnotherChild,
                EmploymentHours = source.EmploymentHours,
                StartEmployment = source.StartEmployment,
                EndEmployment = source.EndEmployment,
                TotalHours = source.TotalHours
            };

        }
    }
}
