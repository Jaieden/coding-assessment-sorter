using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace name_sorter
{
    public class NameSorter
    {
        static string outputFilename = "sorted-names-list.txt";

        static void Main(string[] args)
        {
            try
            {
                NameSorterProgram fullnameSorter = new NameSorterProgram(args[1]);
                fullnameSorter.Sort(args[0]);
                string[] fullnames = fullnameSorter.GetPeopleFullnames();
                foreach (string fullname in fullnames)
                {
                    Console.WriteLine(fullname);
                }
                fullnameSorter.FileWriter(outputFilename);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Please provide input file name {e}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong {e}");
            }
        }
    }


}
