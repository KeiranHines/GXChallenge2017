using System;
using System.Collections.Generic;
using System.IO;

namespace GlobalXChallenge
{
    class NameSorter
    {
        public static List<Person> ParseNameFileToList(string filePath)
        {
            
            var list = new List<Person>();
            
            if (!File.Exists(filePath))
            {
                throw new Exception("Error: File path not found! \n " + filePath);
            }
            using (var file = new StreamReader(filePath))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    line = line.Trim();
                    var i = line.LastIndexOf(" ");
                    var givenName = line.Substring(0, i);
                    var familyName = line.Substring(i, line.Length-i);
                    if (givenName == null || familyName == null)
                        throw new Exception("Error in file the line: " + line + " does not contain a first and last name");
                    var p = new Person(givenName, familyName);
                    list.Add(p);    
                }
            }
            return list;
        }

        public static void LogListToFile<T>(List<T> list, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            foreach (var element in list)
            {
                File.AppendAllText(fileName,element + "\n");
            }
        }
        
        public static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Error no input file specified, please specify an input file");
                return 1;
            }
            if (args.Length > 1)
            {
                Console.WriteLine("Error: Too many arguements passed in, please only specify one file");
                return 1;
            }
            var filePath = args[0];
            var list = ParseNameFileToList(filePath);
            list.Sort();
            LogListToFile(list, "sorted-names-list.txt");
            foreach (var element in list)
            {
                Console.WriteLine(element);    
            }
            
            return 0;         
        }
    }
}