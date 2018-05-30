using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        void AddNanny(Nanny n);// add new nanny to the stock 
        void DeleteNanny(Nanny n);//delete nannay
        void UpdateNanny(Nanny n);// update nanny's details 

        void AddMother(Mother m);// add new mother to the stock 
        void DeleteMother(Mother m);//delete mother
        void UpdateMother(Mother m);// update mother's details 

        void AddChild(Child c);// add new child to the stock 
        void DeleteChild(Child c);//delete child
        void UpdateChild(Child c);// update child's details 

        void AddContract(Contract c);// add new contract to the stock 
        void DeleteContract(Contract c);//delete contract
        void UpdateContract(Contract c);//update contract

        List<Nanny> GetNannysList(); //returns list of all nannies
        List<Mother> GetMothersList(); //returns list of all mothers
        List<Child> GetChildsListByMother(Mother m); //returns list of all childs by mother
        List<Child> GetChildsList(); //returns list of all childs
        List<Contract> GetContractsList(); //returns list of all contracts
        List<BankAccount> GetBankAccountList(); //returns list of all bankaccount

        List<Nanny> SelectedNannys(int NannyAge, Dictionary<DayOfWeek, KeyValuePair<int, int>> HoursNeed, float MaxPayment, int experience, int MaxChilds, float ChildAge); //gets the mother's Requirements and return the nannies that match
        List<Nanny> SelectedNannysByAddress(Address NearMe, int dis, int NannyAge, Dictionary<DayOfWeek, KeyValuePair<int, int>> HoursNeed, float MaxPayment, int experience, int MaxChilds, float ChildAge); //gets the mother's Requirements and returns the nannies that match(with considering to distance)
        List<Child> ChildWithoutNanny(); //returns list of all child that don't have nanny
        List<Nanny> Tamat(); //returns list of all nannies that their vacation days are by the Tamt office
        List<Contract> SelectedContracts(Predicate<Contract> cond); //returns list of contracts according to condition
        int NumOfSelectedContracts(Predicate<Contract> cond); //returns amount of the contracts according to condition

        IEnumerable<IGrouping<string, Nanny>> GroupNannyByChildAge(bool sort = false); //grouping the nannies by child age
        IEnumerable<IGrouping<string, Nanny>> GroupNannyByAddress(bool sort = false); //grouping the nannies by their address
        IEnumerable<IGrouping<float, Nanny>> GroupNannyByChildAgeMaxOrMin(bool max, bool sort = false); //grouping the nannies by maximum child age or minimum
        IEnumerable<IGrouping<double, Contract>> GroupContractByDistanceBetweenNannyAndChild(bool sort = false); //grouping the contracts by distance between nanny to child

        double Distance(Address addressMother, Address addressNanny);//function of google maps that calculates distance
        void calcAvarege(Nanny n, int count, int rate);
        List<Mother> SelectedMothers(String motherID); //returns list of mothers that close to specific mother
    }
}

