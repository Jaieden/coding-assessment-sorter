using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace name_sorter
{
    public class Person
    {

        //Array to store persons names {"First","Middle","Other","Last"} in a scalable way
        //By changing the length of names array, the code can support any number of names (minimum two)
        private string[] names = { "", "", "", "" };

        public Person(string fullName)
        {
            //splits fullname, and throws error if too many or too few names
            string[] splitNames = fullName.Split(' ');
            if (splitNames.Length < 2 || splitNames.Length > names.Length)
            {
                throw new ArgumentException($"Full name must contain between 2 and {names.Length} names", "");
            }
            //Moves each name to their correct place in names array
            names[names.Length - 1] = splitNames[splitNames.Length - 1];
            Array.ConstrainedCopy(splitNames, 0, names, 0, splitNames.Length - 1);
        }

        //Provides back properly formatted name
        override
        public string ToString()
        {
            string[] test = names.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return String.Join(" ", test);
        }

        public string[] Names
        {
            get
            {
                return names;
            }
        }
    }
}
