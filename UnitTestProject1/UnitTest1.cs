using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void createPersonTest()
        {
            Person test = new Person();
        }
    }
}
