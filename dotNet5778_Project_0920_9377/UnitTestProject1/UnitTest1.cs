using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{
    [TestClass]
    //public class UnitTest1
    //{
    //    Address A = new Address { Street = "beit hadfus", Number = 7, City = "JERUSALEM", Country = "ISRAEL" };
    //    Address B = new Address { Street = "beit hadfus", Number = 11, City = "JERUSALEM", Country = "ISRAEL" };
    //    [TestMethod]
    //    public void TestMethod1()
    //    {
    //        double result = BL.FactoryBL.GetInstance.Distance(A, B);
    //        Console.WriteLine("result = {0}", result);
    //    }
    //}
    public class UnitTest2
    {
        
        [TestMethod]
        public void TestMethod2()
        {
            int b = 1240 / 100;
            int c = 1240 % 100;
            Console.WriteLine("result = {0}\n{1}",b,c);
        }
    }
}
