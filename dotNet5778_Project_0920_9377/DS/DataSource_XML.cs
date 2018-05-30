using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DS
{
    public static class DataSource_XML
    {
        public static string ContractXml { get { return @"ContractXml.xml"; } }
        public static string NannyXml { get { return @"NannyXml.xml"; } }
        public static string MotherXml { get { return @"MotherXml.xml"; } }
        public static string ChildXml { get { return @"ChildXml.xml"; } }
        public static string BankAccountXml { get { return @"BankAccountXml.xml"; } }
        public static string AddressXml { get { return @"AddressXml.xml"; } }

        public static XElement Contracts { get; private set; }
        public static XElement Nannys { get; private set; }
        public static XElement Mothers { get; private set; }
        public static XElement Children { get; private set; }
        public static XElement BankAccounts { get; private set; }
        public static XElement Addresses { get; private set; }

        public static void LoadData(string nameofXml)
        {
            //string nameofXml = nameof(elem);
            switch (nameofXml)
            {
                case "Contracts":
                    Contracts = XElement.Load(ContractXml);
                    break;
                case "Nannys":
                    Nannys = XElement.Load(NannyXml);
                    break;
                case "Mothers":
                    Mothers = XElement.Load(MotherXml);
                    break;
                case "Children":
                    Children = XElement.Load(ChildXml);
                    break;
                case "BankAccounts":
                    BankAccounts = XElement.Load(BankAccountXml);
                    break;
                case "Addresses":
                    Addresses = XElement.Load(AddressXml);
                    break;
            }
        }

        public static void SaveData(string nameofXml)
        {
            //string nameofXml = nameof(elem);
            switch (nameofXml)
            {
                case "Contracts":
                    Contracts.Save(ContractXml);
                    break;
                case "Nannys":
                    Nannys.Save(NannyXml);
                    break;
                case "Mothers":
                    Mothers.Save(MotherXml);
                    break;
                case "Children":
                    Children.Save(ChildXml);
                    break;
                case "BankAccounts":
                    BankAccounts.Save(BankAccountXml);
                    break;
                case "Addresses":
                    Addresses.Save(AddressXml);
                    break;
            }
        }
        static DataSource_XML()
        {
            if (!File.Exists(ContractXml))
            {
                Contracts = new XElement("Contracts");
                Contracts.Save(ContractXml);
            }
            try
            {
                Contracts = XElement.Load(ContractXml);
            }
            catch
            {
                throw new Exception("File upload problem");
            }

            if (!File.Exists(NannyXml))
            {
                Nannys = new XElement("nannys");
                Nannys.Save(NannyXml);
            }

            try
            {
                Nannys = XElement.Load(NannyXml);
            }
            catch
            {
                throw new Exception("File upload problem");
            }

            if (!File.Exists(MotherXml))
            {
                Mothers = new XElement("mothers");
                Mothers.Save(MotherXml);
            }

            try
            {
                Mothers = XElement.Load(MotherXml);
            }
            catch
            {
                throw new Exception("File upload problem");
            }

            if (!File.Exists(ChildXml))
            {
                Children = new XElement("children");
                Children.Save(ChildXml);
            }

            try
            {
                Children = XElement.Load(ChildXml);
            }
            catch
            {
                throw new Exception("File upload problem");
            }

            if (!File.Exists(AddressXml))
            {
                Addresses = new XElement("addresses");
                Addresses.Save(AddressXml);
            }

            try
            {
                Addresses = XElement.Load(AddressXml);
            }
            catch
            {
                throw new Exception("File upload problem");
            }

            if (!File.Exists(BankAccountXml))
            {
                BankAccounts = new XElement("bankAccounts");
                BankAccounts.Save(BankAccountXml);
            }

            try
            {
                BankAccounts = XElement.Load(BankAccountXml);
            }
            catch
            {
                throw new Exception("File upload problem");
            }

        }
    }
}
