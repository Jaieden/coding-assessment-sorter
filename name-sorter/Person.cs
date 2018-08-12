using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace name_sorter
{
    public class Person : IComparable<Person>
    {

        //Array to store persons names {"First","Middle","Other","Last"} in a scalable way
        //By changing the length of names array, the code can support any number of names (minimum two)
        public string[] names = { "", "", "", "" };

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

        public int CompareTo(Person other)
        {
            //Compares the surname
            int comparisonResult = names[names.Length - 1].CompareTo(other.names[other.names.Length - 1]);
            //If surname is the same, loop through given names, returning the result if they are different
            if (comparisonResult == 0)
            {
                for (int i = 0; i < names.Length - 1; i++)
                {
                    comparisonResult = names[i].CompareTo(other.names[i]);
                    if (comparisonResult != 0)
                    {
                        return comparisonResult;
                    }
                }
            }
            //If surname is different returns value. Also will return zero if all names are equal
            return comparisonResult;
        }
    }
}
