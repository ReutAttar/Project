using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum BankName { Yahav, Discont, Poalim, Leumi }
    public struct BankAccount
    {
        public int AccountNumber { get; set; }
        //public int BankNumber { get; set; }
        public BankName BankName { get; set; }
        public int BranchNumber { get; set; }
        public Address BankAdress { get; set; }
        public double Balance { get; set; }
        public override string ToString()
        {
            string result = "\nBank Account details:\n";
            result += "---------------------\n";
            result += string.Format("Bank name:{0}\n", BankName);
            result += string.Format("Branch number:{0}\n", BranchNumber);
            result += string.Format("Accout number: {0}\n", AccountNumber);
            result += string.Format("Balance: {0}\n", Balance);
            result += BankAdress.ToString() + '\n';
            return result;
        }
    }
}
