using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace name_sorter.Tests

{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void CreatePerson()
        {
            Person person = new name_sorter.Person("Alfred Barry Cooper");
        }
        [TestMethod]
        public void PersonToString()
        {
            string[] fullnames = {
                "Alfred Barry Cooper",
                "Alfred Cooper",
                "Alfred Barry Cooper Dent",
            };
            foreach (string name in fullnames)
            {
                Person person = new name_sorter.Person(name);
                Assert.AreEqual(name, person.ToString());
            }
            
        }
        [TestMethod]
        public void PersonCompareTo()
        {
            Person a = new Person("Alfred Barry Charles Dent");
            Person b = new Person("Alfred Barry Dent");
            Person c = new Person("Barry Charles");
            Person d = new Person("Barry Dent");
            Person e = new Person("David Arthur");
            Person f = new Person("Alfred Barry Charles Dent");
            Assert.IsTrue(a.CompareTo(a) == 0); //test self
            Assert.IsTrue(a.CompareTo(f) == 0); //test same name, different person, max length.
            Assert.IsTrue(a.CompareTo(c) > 0); //test a before c
            Assert.IsTrue(c.CompareTo(a) < 0); //test a before c in reverse (testing symmetry)
            Assert.IsTrue(d.CompareTo(e) > 0); //test min length
            Assert.IsTrue(a.CompareTo(b) > 0); //test similar name, one without third name
        }

    }
}
