using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace name_sorter.tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void CreatePerson()
        {
            Person test = new Person("Alfred Barry Cooper");
        }
    }
}
