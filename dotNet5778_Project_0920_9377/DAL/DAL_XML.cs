using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using DS;

namespace DAL
{
    class DAL_XML : Idal
    {
        private int getContractNumber() // Calculates the following contract number 
        {
            int result;
            var anyContract = DataSource_XML.Contracts.Elements("contract").Any();

            if (!anyContract)// if there is not contract 
                result = 100000;
            else // take the last contract number 
            {
                result = (from e in DataSource_XML.Contracts.Elements("contract")
                          select Int32.Parse(e.Element("ContractNumber").Value)).Max();
            }
            return result;
        }

        public void AddChild(Child c)
        {
            DataSource_XML.LoadData("Children");//load the Children file 
            XElement temp = ((from e in DataSource_XML.Children.Elements() // check if the child is exists  
                              where e.Element("ID").Value == c.ID
                              select e).FirstOrDefault());
            if (temp != null)
                throw new Exception("This Child already exist");

            DataSource_XML.Children.Add(DAL_Converts.ChildToXml(c));//
            DataSource_XML.SaveData("Children");
        }

        public void AddContract(Contract c)
        {
            DataSource_XML.LoadData("Contracts");//load the contract file 
            XElement temp = ((from e in DataSource_XML.Contracts.Elements() // check if there is contract for this child
                              where e.Element("ChildID").Value == c.ChildID
                              select e).FirstOrDefault());
            if (temp != null)
                throw new Exception("Cannot add another Contract to same child");
            XElement contract = DAL_Converts.ContractToXml(c);
            contract.Element("ContractNumber").Value = (getContractNumber() + 1).ToString();// add the new contract number
            DataSource_XML.Contracts.Add(contract);
            DataSource_XML.SaveData("Contracts"); // save the file 
        }

        public void AddMother(Mother m)
        {
            DataSource_XML.LoadData("Mothers"); // load the file
            if (DataSource_XML.Mothers == null) // if there isno mother that saved 
            {
                DataSource_XML.Mothers.Add(DAL_Converts.MotherToXml(m));
                DataSource_XML.Mothers.Save(DataSource_XML.MotherXml);
            }
            XElement temp = ((from e in DataSource_XML.Mothers.Elements()// check if the Mother already exist
                              where e.Element("ID").Value == m.ID
                              select e).FirstOrDefault());
            if (temp != null)
                throw new Exception("This Mother already exist");

            DataSource_XML.Mothers.Add(DAL_Converts.MotherToXml(m));
            DataSource_XML.SaveData("Mothers");
        }

        public void AddNanny(Nanny n)
        {
            DataSource_XML.LoadData("Nannys");// load the nannies file 
            XElement temp = ((from e in DataSource_XML.Nannys.Elements() // check if the Nanny already exist
                              where e.Element("ID").Value == n.ID
                              select e).FirstOrDefault());
            if (temp != null)
                throw new Exception("This Nanny already exist");

            DataSource_XML.Nannys.Add(DAL_Converts.NannyToXml(n));
            DataSource_XML.SaveData("Nannys"); // save the file 
        }

        public void DeleteChild(Child c, bool deleteall = true)
        {
            DataSource_XML.LoadData("Children");// load the Children file 
            XElement temp = ((from e in DataSource_XML.Children.Elements() // check uf the child exist 
                              where e.Element("ID").Value == c.ID
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This Child does not exist");
            temp.Remove();
            DataSource_XML.SaveData("Children");
            XElement tmpC = ((from con in DataSource_XML.Contracts.Elements() // delete the contract with this child 
                              where con.Element("ChildID").Value == c.ID
                              select con).FirstOrDefault());
            if (tmpC != null && deleteall) // deleteall- if the use is to delete and not for update
                DeleteContract(tmpC.XmlToContract());
        }

        public void DeleteContract(Contract c)
        {
            DataSource_XML.LoadData("Contracts");// load the Contracts file 
            XElement temp = ((from e in DataSource_XML.Contracts.Elements()// check if the contract exist - save it in tmp 
                              where e.Element("ChildID").Value == c.ChildID
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This Contract does not exist");
            temp.Remove();
            DataSource_XML.SaveData("Contracts");
        }

        public void DeleteMother(Mother m, bool deleteall = true)
        {
            DataSource_XML.LoadData("Mothers");// load the Mothers file
            XElement temp = ((from e in DataSource_XML.Mothers.Elements()// check if the contract exist c
                              where e.Element("ID").Value == m.ID
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This Mother does not exist");
            temp.Remove();
            DataSource_XML.SaveData("Mothers");
            if (deleteall) // deleteall- if the use is to delete and not for update
            {
                foreach (var item in DataSource_XML.Children.Elements())
                {
                    if (item.Element("MyMotherID").Value == m.ID)
                    {
                        DeleteChild(item.XmlToChild());
                    }
                }
            }
        }

        public void DeleteNanny(Nanny n, bool deleteall = true)
        {
            DataSource_XML.LoadData("Nannys");// load the nnanies file
            XElement temp = ((from e in DataSource_XML.Nannys.Elements()//check if the nanny exist - save it in tmp 
                              where e.Element("ID").Value == n.ID
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This Nanny does not exist");
            temp.Remove();
            DataSource_XML.SaveData("Nannys");
            if (deleteall)  // deleteall- if the use is to delete and not for update
            {
                foreach (var item in DataSource_XML.Contracts.Elements())
                {
                    if (item.Element("NannyID").Value == n.ID)
                    {
                        DeleteContract(item.XmlToContract());
                    }
                }
            }
        }

        public IEnumerable<BankAccount> GetBankAccountList()
        {
            XElement root = DataSource_XML.BankAccounts;
            List<BankAccount> result = new List<BankAccount>();
            foreach (var b in root.Elements("bankaccount"))
            {
                result.Add(b.XmlToBankAccount());
            }
            return result.AsEnumerable();
        }

        public IEnumerable<Child> GetChildsList()
        {
            XElement root = DataSource_XML.Children;
            List<Child> result = new List<Child>();
            foreach (var c in root.Elements("child"))
            {
                result.Add(c.XmlToChild());
            }
            return result.AsEnumerable();
        }

        public IEnumerable<Child> GetChildsListByMother(Mother m)
        {
            XElement root = DataSource_XML.Children;
            List<Child> result = new List<Child>();
            result = (from c in root.Elements("child")              //for each child
                      where m.ID == c.Element("MyMotherID").Value   //if its mother id is the same to the mother id that we want  
                      select DAL_Converts.XmlToChild(c)).ToList();  //add this child 
            return result.AsEnumerable();
        }

        public IEnumerable<Contract> GetContractsList()
        {
            XElement root = DataSource_XML.Contracts;
            List<Contract> result = new List<Contract>();
            foreach (var c in root.Elements("contract"))
            {
                result.Add(c.XmlToContract());
            }
            return result.AsEnumerable();
        }

        public IEnumerable<Mother> GetMothersList()
        {
            XElement root = DataSource_XML.Mothers;
            List<Mother> result = new List<Mother>();
            foreach (var m in root.Elements("mother"))
            {
                result.Add(m.XmlToMother());
            }
            return result.AsEnumerable();
        }

        public IEnumerable<Nanny> GetNannysList()
        {
            XElement root = DataSource_XML.Nannys;
            List<Nanny> result = new List<Nanny>();
            foreach (var n in root.Elements("nanny"))
            {
                result.Add(n.XmlToNanny());
            }
            return result.AsEnumerable();
        }

        public void UpdateChild(Child c)
        {
            DataSource_XML.LoadData("Children");
            XElement temp = ((from e in DataSource_XML.Children.Elements() // check if the child exist
                              where e.Element("ID").Value == c.ID
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This Child not exist");
            temp.ReplaceWith(DAL_Converts.ChildToXml(c));// replace between the child details 
            DataSource_XML.SaveData("Children");
        }

        public void UpdateContract(Contract c)
        {
            DataSource_XML.LoadData("Contracts");
            XElement temp = ((from e in DataSource_XML.Contracts.Elements() // check if the contract exist
                              where e.Element("ChildID").Value == c.ChildID
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This Contract not exist");
            temp.ReplaceWith(DAL_Converts.ContractToXml(c)); // replace between the contract details 
            DataSource_XML.SaveData("Contracts");
        }

        public void UpdateMother(Mother m)
        {
            DataSource_XML.LoadData("Mothers");
            XElement temp = ((from e in DataSource_XML.Mothers.Elements() // check if the mother exist 
                              where e.Element("ID").Value == m.ID
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This Mother not exist");
            temp.ReplaceWith(DAL_Converts.MotherToXml(m));// replace between the mother details 
            DataSource_XML.SaveData("Mothers");
        }

        public void UpdateNanny(Nanny n)
        {
            DataSource_XML.LoadData("Nannys");
            XElement temp = ((from e in DataSource_XML.Nannys.Elements() //check if the nanny exist
                              where e.Element("ID").Value == n.ID
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This Nanny not exist");
            temp.ReplaceWith(DAL_Converts.NannyToXml(n)); // replace between the nanny details 
            DataSource_XML.SaveData("Nannys");
        }
    }
}
