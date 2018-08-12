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
                string[] fullnames = FileReader(args[0]);
                Person[] people = CreatePeople(fullnames);
                Array.Sort(people);
                fullnames = GetPeopleFullnames(people);
                foreach (string fullname in fullnames)
                {
                    Console.Write(fullname);
                }
                //FileWriter(fullnames);
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


        static string[] FileReader(string path)
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (Exception e)
            {
                Console.WriteLine($"File not found or invalid input: {path} {e}");
                return new string[0];
            }
        }

        static Person[] CreatePeople(string[] fullnames)
        {
            Person[] people = new Person[fullnames.Length];
            for (int i = 0; i < fullnames.Length; i++)
            {
                people[i] = new Person(fullnames[i]);
            }
            return people;
        }

        static string[] GetPeopleFullnames(Person[] people)
        {
            string[] fullnames = new string[people.Length];
            for (int i = 0; i < people.Length; i++)
            {
                fullnames[i] = people[i].ToString();
            }
            return fullnames;
        }

        static void FileWriter(string[] fullnames)
        {
            try
            {
                File.WriteAllLines(outputFilename, fullnames);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not write names to file: {outputFilename} {e}");
            }
        }

    }


}
