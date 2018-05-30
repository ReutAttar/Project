using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace DAL
{
    internal class Dal_imp : Idal
    {
        internal Dal_imp() { }
        private static int SerialContractnumber = 1000000; // serial number that change for each contract 

        public void AddNanny(Nanny n)
        {
            if (DS.DataSource.Nannys.Exists(na => na.ID == n.ID))//check if the nanny is allready exists
                throw new Exception("nanny allready exists");
            DS.DataSource.Nannys.Add(n.NannyDeepClone());
        }
        public void DeleteNanny(Nanny n, bool deleteall = true)
        {
            Nanny Bye = null;
            if (!(DS.DataSource.Nannys.Exists(na => na.ID == n.ID)))//check if the nanny dosent exists
                throw new Exception("Nanny not exists");
            Bye = DS.DataSource.Nannys.Find(item => item.ID == n.ID);//Bye gets the nanny that we want to delete
            DS.DataSource.Nannys.Remove(Bye);
            if (deleteall)// if the use is to delete nanny and not just to update her details
            {
                DS.DataSource.Contracts.RemoveAll(item => item.NannyID == n.ID);//delete nanny Requires delete all her contracts
            }
        }
        public void UpdateNanny(Nanny n)
        {
            if (!(DS.DataSource.Nannys.Exists(na => na.ID == n.ID)))//check if the nanny dosent exists
                throw new Exception("Nanny not exists");
            bool deleteall = false;
            DeleteNanny(n, deleteall);// delete the nanny 
            AddNanny(n);// add the nanny with the new details 
        }

        public void AddMother(Mother m)
        {
            if (DS.DataSource.Mothers.Exists(mo => mo.ID == m.ID))// check if the mother allredy exists
                throw new Exception("Mother allready exists");
            DS.DataSource.Mothers.Add(m.MotherDeepClone());// add new mother to the list 
        }
        public void DeleteMother(Mother m, bool deleteall = true)
        {
            Mother Bye = null;
            if (!(DS.DataSource.Mothers.Exists(mo => mo.ID == m.ID)))// check if the mother dosent exists
                throw new Exception("Mother not exists");
            Bye = DS.DataSource.Mothers.Find(item => item.ID == m.ID);//Bye gets the mother that we want to delete
            DS.DataSource.Mothers.Remove(Bye);
            if (deleteall)// if the use is to delete mother and not just to update her details
            {
                DS.DataSource.Childs.RemoveAll(item => item.MyMotherID == m.ID);//delete mother Requires delete all her childs
                DS.DataSource.Contracts.RemoveAll(item => item.MotherID == m.ID);//delete mother Requires delete all her contracts
            }
        }
        public void UpdateMother(Mother m)
        {
            if (!(DS.DataSource.Mothers.Exists(mo => mo.ID == m.ID)))
                throw new Exception("Mother not exists");
            bool deleteall = false;//  because its only update  
            DeleteMother(m, deleteall);// delete the mother
            AddMother(m);// add the mother wuth the new details 
        }
        public void AddChild(Child c)
        {
            if (DS.DataSource.Childs.Exists(ch => ch.ID == c.ID))// check if the child allready exists
                throw new Exception("Child allready exists");
            DS.DataSource.Childs.Add(c.ChildDeepClone());
        }
        public void DeleteChild(Child ch, bool deleteall = true)
        {
            Child Bye = null;
            if (!(DS.DataSource.Childs.Exists(c => c.ID == ch.ID)))//check if the child dosent exists
                throw new Exception("Child not exists");
            Bye = DS.DataSource.Childs.Find(item => item.ID == ch.ID);//Bye gets the child that we want to delete
            DS.DataSource.Childs.Remove(Bye);
            if (deleteall)// if the use is to delete child and not just to update her details
            {
                DS.DataSource.Contracts.RemoveAll(item => item.ChildID == ch.ID);//delete child Requires delete all his contracts
            }
        }
        public void UpdateChild(Child c)
        {
            if (!(DS.DataSource.Childs.Exists(ch => ch.ID == c.ID)))//check if the child dosent exists
                throw new Exception("Child not exists");
            bool deleteall = false;
            DeleteChild(c, deleteall);// delete the child 
            AddChild(c);//add the child with the new details
        }
        public void AddContract(Contract c)
        {
            if (DS.DataSource.Contracts.Exists(co => co.ChildID == c.ChildID))//check if the contract allready exists
                throw new Exception("Contract allready exists");
            c.ContractNumber = SerialContractnumber++;// update the contract number 
            DS.DataSource.Contracts.Add(c.ContractDeepClone());

        }
        public void DeleteContract(Contract c)
        {
            Contract Bye = null;
            Bye = DS.DataSource.Contracts.Find(item => item.ContractNumber == c.ContractNumber);
            DS.DataSource.Contracts.Remove(Bye);
        }
        public void UpdateContract(Contract c)
        {
            if (!(DS.DataSource.Contracts.Exists(co => co.ContractNumber == c.ContractNumber)))//check uf the contract dosent exists
                throw new Exception("Contract not exists");
            DeleteContract(c);
            AddContract(c);
        }
        public IEnumerable<Nanny> GetNannysList()
        {
            return DS.DataSource.Nannys.Select(item => item.NannyDeepClone());
        }
        public IEnumerable<Mother> GetMothersList()
        {
            return DS.DataSource.Mothers.Select(item => item.MotherDeepClone());
        }
        public IEnumerable<Child> GetChildsListByMother(Mother m)// get mother , return her childrens
        {
            return (from item in DS.DataSource.Childs  //for each child
                    where item.MyMotherID == m.ID   // if its mother id is the same to the mother id that we want  
                    select item.ChildDeepClone());  // add this child 
        }
        public IEnumerable<Child> GetChildsList()
        {
            return DS.DataSource.Childs.Select(item => item.ChildDeepClone());
        }
        public IEnumerable<Contract> GetContractsList()
        {
            return DS.DataSource.Contracts.Select(item => item.ContractDeepClone());
        }

        public IEnumerable<BankAccount> GetBankAccountList() 
        {
            if (DS.DataSource.Banks == null)
                initiate();
            return DS.DataSource.Banks;
        }

        public void initiate()
        {
            {
                DS.DataSource.Banks.Add(new BankAccount { AccountNumber = 1, BankName = BankName.Discont, BranchNumber = 10, BankAdress = new Address { Number = 12, Street = "Hadekel", City = "Eilat", Country = "Israel" } });
                DS.DataSource.Banks.Add(new BankAccount { AccountNumber = 2, BankName = BankName.Leumi, BranchNumber = 11, BankAdress = new Address { Number = 13, Street = "Inbar", City = "Modiin", Country = "Israel" } });
                DS.DataSource.Banks.Add(new BankAccount { AccountNumber = 3, BankName = BankName.Poalim, BranchNumber = 12, BankAdress = new Address { Number = 14, Street = "Yafo", City = "Jerusalem", Country = "Israel" } });
                DS.DataSource.Banks.Add(new BankAccount { AccountNumber = 4, BankName = BankName.Yahav, BranchNumber = 13, BankAdress = new Address { Number = 15, Street = "Almagor", City = "Tel Aviv", Country = "Israel" } });
                DS.DataSource.Banks.Add(new BankAccount { AccountNumber = 5, BankName = BankName.Poalim, BranchNumber = 14, BankAdress = new Address { Number = 16, Street = "Herzel", City = "Or Yehuda", Country = "Israel" } });
            };

        }


    }
}
