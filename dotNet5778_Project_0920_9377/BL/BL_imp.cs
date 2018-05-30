using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using GoogleMapsApi;
using System.Text.RegularExpressions;
using System.Threading;
using System.ComponentModel;

namespace BL
{
    internal class BL_imp : IBL
    {
        static List<Nanny> DisNannys = new List<Nanny>();//list of nannies that exist in the distance that the mother need

        public void AddChild(Child c)
        {
            Idal mydal = FactoryDal.getDal();
            try
            {
                mydal.AddChild(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void calcPayment(Contract c)//function that calculate the total payment
        {
            Idal mydal = FactoryDal.getDal();
            float TotalMonthes = (c.EndEmployment.Year - c.StartEmployment.Year) * 12 + (c.EndEmployment.Month - c.StartEmployment.Month); //total months that the nanny works

            foreach (var item in c.EmploymentHours)//total hours for month that the nanny works
            {
                c.TotalHours += (item.Value.Value / 100 - item.Value.Key / 100) * 4;
            }

            if (c.Payment)   //true=>by month
                c.TotalPay = ((mydal.GetNannysList().ToList().Find(n => n.ID == c.NannyID)).SalaryForMonth) * TotalMonthes; //total pay by month, take tha nanny rate for month multiplied the total months
            else c.TotalPay = c.TotalHours * (mydal.GetNannysList().ToList().Find(n => n.ID == c.NannyID)).RateForHour * TotalMonthes; //else total pay by hour, take tha nanny rate for hour multiplied the total months and the total hours

            if (c.AnotherChild) //if the child have another brother/sister that have a contract with the same nanny the mother get rebate
                c.TotalPay -= (float)0.02 * c.TotalPay;
        }

        public void AddContract(Contract c)
        {
            Idal mydal = FactoryDal.getDal();
            if (!mydal.GetNannysList().ToList().Exists(n => n.ID == c.NannyID))//check if the nanny exist
                throw new Exception("Nanny dosn't exists");
            if (!mydal.GetMothersList().ToList().Exists(m => m.ID == c.MotherID))//check if the mother exist
                throw new Exception("Mother dosn't exists");
            if (!mydal.GetChildsList().ToList().Exists(ch => ch.ID == c.ChildID))//check if the child exist
                throw new Exception("Child dosn't exists");
            if ((DateTime.Now.Year - ((mydal.GetChildsList().ToList().Find(ch => ch.ID == c.ChildID)).Birthday.Year)) * 12 + (DateTime.Now.Month - ((mydal.GetChildsList().ToList().Find(ch => ch.ID == c.ChildID)).Birthday.Month)) <= 3)//if the child's age is less than 3 month
                throw new Exception("The child is too young!");
            int count = 0;
            foreach (var item in mydal.GetContractsList())//summarize the contracts for each nanny
            {
                if (item.NannyID == c.NannyID)
                    count++;
            }
            if (count == (mydal.GetNannysList().ToList().Find(n => n.ID == c.NannyID).MaxChildrens))//if the amount of contracts of the nanny equal to the maximum number of children that she can get
                throw new Exception("There is no place");

            calcPayment(c);//call function to calculate the total payment

            try
            {
                mydal.AddContract(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AddMother(Mother m)
        {
            Idal mydal = FactoryDal.getDal();
            try
            {
                mydal.AddMother(m);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AddNanny(Nanny n)
        {
            //logical actions
            if ((DateTime.Now.Year - n.Birthday.Year) < 18)//checks if the nanny not too young 
            {
                throw new Exception("The nanny is too young");
            }
            //call DAL for action
            Idal mydal = FactoryDal.getDal();
            try
            {
                mydal.AddNanny(n);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteChild(Child c)
        {
            Idal mydal = FactoryDal.getDal();
            try
            {
                mydal.DeleteChild(c, true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteContract(Contract c)
        {
            Idal mydal = FactoryDal.getDal();
            try
            {
                mydal.DeleteContract(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteMother(Mother m)
        {
            Idal mydal = FactoryDal.getDal();
            try
            {
                mydal.DeleteMother(m, true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteNanny(Nanny n)
        {
            Idal mydal = FactoryDal.getDal();
            try
            {
                mydal.DeleteNanny(n, true);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void UpdateChild(Child c)
        {
            Idal mydal = FactoryDal.getDal();
            try
            {
                mydal.UpdateChild(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateContract(Contract c)
        {
            calcPayment(c);//if the mother change her choice how to pay 
            Idal mydal = FactoryDal.getDal();
            try
            {
                mydal.UpdateContract(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateMother(Mother m)
        {
            Idal mydal = FactoryDal.getDal();
            try
            {
                mydal.UpdateMother(m);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateNanny(Nanny n)
        {
            Idal mydal = FactoryDal.getDal();
            try
            {
                mydal.UpdateNanny(n);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<BankAccount> GetBankAccountList()//returns list of all bankaccount
        {
            Idal mydal = FactoryDal.getDal();
            return mydal.GetBankAccountList().ToList();
        }

        public List<Child> GetChildsListByMother(Mother m)//returns list of all childs by mother
        {
            Idal mydal = FactoryDal.getDal();
            return mydal.GetChildsListByMother(m).ToList();
        }

        public List<Child> GetChildsList()//returns list of all childs
        {
            Idal mydal = FactoryDal.getDal();
            return mydal.GetChildsList().ToList();
        }

        public List<Contract> GetContractsList()//returns list of all contracts
        {
            Idal mydal = FactoryDal.getDal();
            return mydal.GetContractsList().ToList();
        }

        public List<Mother> GetMothersList()//returns list of all mothers
        {
            Idal mydal = FactoryDal.getDal();
            return mydal.GetMothersList().ToList();
        }

        public List<Nanny> GetNannysList()//returns list of all nannies
        {
            Idal mydal = FactoryDal.getDal();
            return mydal.GetNannysList().ToList();
        }

        public bool CheckHours(Nanny n, Dictionary<DayOfWeek, KeyValuePair<int, int>> HoursNeed)//checks the hours that the nanny can, compared to the hours that the mother needs
        {
            foreach (var Motheritem in HoursNeed)
            {
                foreach (var Nannyitem in n.WorkHours)
                    if (Motheritem.Key == Nannyitem.Key)
                        if (Motheritem.Value.Key < Nannyitem.Value.Key || Motheritem.Value.Value > Nannyitem.Value.Value)//if the start hours of the nanny is later than the mother's hours OR the end hours of the nanny is earlier than the mother's hours
                            return false; //the nanny's hours not fits
            }
            return true;
        }

        public bool check(Nanny nanny, int NannyAge, Dictionary<DayOfWeek, KeyValuePair<int, int>> HoursNeed, float MaxPayment, int experience, int MaxChilds, float ChildAge)//the function check the Requirements of the mother 
        {
            if ((DateTime.Now.Year - nanny.Birthday.Year) >= NannyAge && (nanny.RateForHour <= MaxPayment || nanny.SalaryForMonth <= MaxPayment) && nanny.Experience >= experience
                && nanny.MaxChildrens <= MaxChilds && (ChildAge <= nanny.MaxChildrensAge && ChildAge >= nanny.MinChildrensAge) && CheckHours(nanny, HoursNeed))
                return true;
            else return false;
        }

        public List<Nanny> SelectedNannys(int NannyAge, Dictionary<DayOfWeek, KeyValuePair<int, int>> HoursNeed, float MaxPayment, int experience, int MaxChilds, float ChildAge)//gets the mother's Requirements and return the nannies that match
        {
            var result = (from n in GetNannysList()
                          where check(n, NannyAge, HoursNeed, MaxPayment, experience, MaxChilds, ChildAge)//if the Requirements Accepted the nanny add to the list
                          select n).ToList();
            return result;
        }

        public double Distance(Address addressMother, Address addressNanny)//function of google maps that calculates distance
        {
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = addressMother.ToString(),
                Destination = addressNanny.ToString()
            };

            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            double f = ((double)leg.Distance.Value) / 1000;
            return f;
        }

        public List<Nanny> SelectedNannysByAddress(Address NearMe, int dis, int NannyAge, Dictionary<DayOfWeek, KeyValuePair<int, int>> HoursNeed, float MaxPayment, int experience, int MaxChilds, float ChildAge)//gets the mother's Requirements and returns the nannies that match(with considering to distance)
        {
            List<Nanny> selectedNannys = SelectedNannys(NannyAge, HoursNeed, MaxPayment, experience, MaxChilds, ChildAge);//call to the Previous function
            DisNannys.Clear();
            return DisNannys = (from nanny in selectedNannys
                                where (Distance(NearMe, nanny.PersonAddress) <= dis)//call to google maps function, if the distance smaller than the distance that the mother want(dis) we add the nanny
                                select nanny).ToList();
        }


        public List<Child> ChildWithoutNanny()//returns list of all child that don't have nanny
        {
            Idal mydal = FactoryDal.getDal();
            List<Child> ChildWithoutNanny = (from child in mydal.GetChildsList()
                                             where !(mydal.GetContractsList().ToList().Exists(co => co.ChildID == child.ID)) //all the childerns that dont have contract->dont have nanny
                                             select child).ToList();
            return ChildWithoutNanny;

        }

        public List<Nanny> Tamat()//returns list of all nannies that their vacation days are by the Tamt office
        {
            Idal mydal = FactoryDal.getDal();
            List<Nanny> NannysVacations = (from n in mydal.GetNannysList()
                                           where n.VacationDays //all the nannies that their vacation days are by the Tamt office
                                           select n).ToList();
            return NannysVacations;
        }

        public List<Contract> SelectedContracts(Predicate<Contract> cond)//Returns all contracts that fulfill the condition
        {
            Idal mydal = FactoryDal.getDal();
            List<Contract> SelectedContracts = (from contract in mydal.GetContractsList()
                                                where cond(contract) //all the contracts that fulfill the condition
                                                select contract).ToList();
            return SelectedContracts;
        }

        public int NumOfSelectedContracts(Predicate<Contract> cond)//using SelectedContracts function and return how many contracts are fulfill the condition
        {
            return SelectedContracts(cond).Count;
        }

        public IEnumerable<IGrouping<string, Nanny>> GroupNannyByChildAge(bool sort = false)//grouping the nannies by child age
        {
            Idal mydal = FactoryDal.getDal();
            IEnumerable<IGrouping<string, Nanny>> ChildAge;
            if (sort)
            {
                ChildAge = from n in mydal.GetNannysList()
                           orderby n.range //field in nanny that contain the range of the children's ages
                           group n by n.range;
            }
            else
            {
                ChildAge = from n in mydal.GetNannysList()
                           group n by n.range;
            }

            return ChildAge.ToList();
        }

        public IEnumerable<IGrouping<string, Nanny>> GroupNannyByAddress(bool sort = false)//grouping the nannies by their address
        {
            Idal mydal = FactoryDal.getDal();
            IEnumerable<IGrouping<string, Nanny>> city;
            if (sort)
            {
                city = from n in mydal.GetNannysList()
                       orderby n.PersonAddress.City
                       group n by n.PersonAddress.City;
            }
            else
            {
                city = from n in mydal.GetNannysList()
                       group n by n.PersonAddress.City;
            }
            return city.ToList();

        }

        public IEnumerable<IGrouping<float, Nanny>> GroupNannyByChildAgeMaxOrMin(bool max, bool sort = false)//grouping the nannies by maximum child age or minimum
        {
            Idal mydal = FactoryDal.getDal();
            IEnumerable<IGrouping<float, Nanny>> ChildAge;
            if (max)
            {
                if (sort)
                {
                    ChildAge = from n in mydal.GetNannysList()
                               orderby n.MaxChildrensAge
                               group n by n.MaxChildrensAge;
                }
                else
                {
                    ChildAge = from n in mydal.GetNannysList()
                               group n by n.MaxChildrensAge;
                }
            }

            else
            {
                if (sort)
                {
                    ChildAge = from n in mydal.GetNannysList()
                               orderby n.MinChildrensAge
                               group n by n.MinChildrensAge;
                }
                else
                {
                    ChildAge = from n in mydal.GetNannysList()
                               group n by n.MinChildrensAge;
                }
            }

            return ChildAge.ToList();
        }

        public IEnumerable<IGrouping<double, Contract>> GroupContractByDistanceBetweenNannyAndChild(bool sort = false)//grouping the contracts by distance between nanny to child
        {
            Idal mydal = FactoryDal.getDal();
            IEnumerable<IGrouping<double, Contract>> distance;
            if (sort)
            {
                distance = from c in mydal.GetContractsList()
                           let dis = Distance((mydal.GetNannysList().ToList().Find(n => n.ID == c.NannyID).PersonAddress), (mydal.GetMothersList().ToList().Find(m => m.ID == c.MotherID)).PersonAddress)//call to google maps function
                           orderby c.ContractNumber
                           group c by dis;
            }
            else
            {
                distance = from c in mydal.GetContractsList()
                           let dis = Distance((mydal.GetNannysList().ToList().Find(n => n.ID == c.NannyID).PersonAddress), (mydal.GetMothersList().ToList().Find(m => m.ID == c.MotherID)).PersonAddress)//call to google maps function
                           group c by dis;
            }
            return distance.ToList();
        }
        public void calcAvarege(Nanny n, int count, int rate)//The nanny has a field of average ratings that ranked her, so after anyone rating her she is updated
        {
            n.averageRate = (((count - 1) * n.averageRate) + rate) / count;
            Idal mydal = FactoryDal.getDal();
            mydal.UpdateNanny(n);
        }
        public List<Mother> SelectedMothers(String motherID)//returns list of mothers that close to specific mother
        {
            Idal mydal = FactoryDal.getDal();
            Mother specificMother = mydal.GetMothersList().ToList().Find(m => m.ID == motherID);
            List<Mother> Selectedmothers = (from mother in mydal.GetMothersList()
                                            where Distance(mother.PersonAddress, specificMother.PersonAddress) < 0.250 //checks for each mother if she close to the specific mother in a distance less than 250 meter
                                            select mother).ToList();
            return Selectedmothers;
        }
    }
}
