using System;
using System.Collections.Generic;
using System.Text;

namespace name_sorter
{
    class AscendingPersonSorter : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            //Compares the surname
            int comparisonResult = x.Names[x.Names.Length - 1].CompareTo(y.Names[y.Names.Length - 1]);
            //If surname is the same, loop through given names, returning the result if they are different
            if (comparisonResult == 0)
            {
                for (int i = 0; i < x.Names.Length - 1; i++)
                {
                    comparisonResult = x.Names[i].CompareTo(y.Names[i]);
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
