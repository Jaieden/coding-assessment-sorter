using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace name_sorter
{
    class NameSorterProgram
    {

        private Person[] people;

        public NameSorterProgram(string inputFilepath)
        {
            string[] fullnames = FileReader(inputFilepath);
            people = CreatePeople(fullnames);
        }

        public void Sort(string orderBy)
        {
            IComparer<Person> personSorter = GetPersonSorter(orderBy);
            Array.Sort(people,personSorter);
        }

        public IComparer<Person> GetPersonSorter(string orderBy)
        {
            if (orderBy == "-a")
            {
                return new AscendingPersonSorter();
            }
            else if (orderBy == "-d")
            {
                return new DescendingPersonSorter();
            }
            else
            {
                throw new ArgumentException("Input must be -a or -d");
            }
        }

        public string[] FileReader(string path)
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

        public Person[] CreatePeople(string[] fullnames)
        {
            Person[] people = new Person[fullnames.Length];
            for (int i = 0; i < fullnames.Length; i++)
            {
                people[i] = new Person(fullnames[i]);
            }
            return people;
        }

        public string[] GetPeopleFullnames()
        {
            string[] fullnames = new string[people.Length];
            for (int i = 0; i < people.Length; i++)
            {
                fullnames[i] = people[i].ToString();
            }
            return fullnames;
        }

        public void FileWriter(string outputFilename)
        {
            try
            {
                File.WriteAllLines(outputFilename, GetPeopleFullnames());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not write names to file: {outputFilename} {e}");
            }
        }
    }
}
