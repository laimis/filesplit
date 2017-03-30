using System;
using System.IO;
using Filesplit.Services;

namespace Filesplit.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the service
            var service = new RecordService();

            // read in 3 files
            foreach(var f in args)
            {
                var content = File.ReadAllText(f);

                // pass the contents to the service
                service.Add(content);
            }

            // three outputs
            Console.WriteLine("Ouput 1, sorted by gender:");

            Console.WriteLine("Ouput 2, sorted by DOB (ascending):");

            Console.WriteLine("Ouput 3, sorted by last name (descending):");
        }
    }
}
