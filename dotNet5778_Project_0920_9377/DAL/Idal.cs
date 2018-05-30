using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface Idal
    {
        void AddNanny(Nanny n);// add new nanny to the stock 
        void DeleteNanny(Nanny n, bool deleteall);//delete nannay, deleteall=false ->its only for the update function
        void UpdateNanny(Nanny n);// update nanny's details 

        void AddMother(Mother m);// add new mother to the stock 
        void DeleteMother(Mother m, bool deleteall);//delete mother, deleteall=false-> its only for the update function
        void UpdateMother(Mother m);// update mother's details 

        void AddChild(Child c);// add new child to the stock 
        void DeleteChild(Child c, bool deleteall);//delete child, deleteall=false -> its only for the update function
        void UpdateChild(Child c);// update child's details 

        void AddContract(Contract c);// add new contract to the stock 
        void DeleteContract(Contract c);//delete contract
        void UpdateContract(Contract c);//update contract

        IEnumerable<Nanny> GetNannysList();
        IEnumerable<Mother> GetMothersList();
        IEnumerable<Child> GetChildsListByMother(Mother m);
        IEnumerable<Child> GetChildsList();
        IEnumerable<Contract> GetContractsList();
        IEnumerable<BankAccount> GetBankAccountList();
    }
}
