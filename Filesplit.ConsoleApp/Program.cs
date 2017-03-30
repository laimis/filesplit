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
            Output(service, OrderBy.Gender);

            Output(service, OrderBy.BirthDate);

            Output(service, OrderBy.LastName);
        }

        private static void Output(IRecordService service, OrderBy orderBy)
        {
            Console.WriteLine("Output sorted by " + orderBy);
            foreach(var r in service.List(orderBy))
            {
                Console.WriteLine("{0},{1},{2},{3},{4}", 
                    r.FirstName, 
                    r.LastName, 
                    r.Gender, 
                    r.FavoriteColor, 
                    r.DateOfBirthFormmated);
            }
            Console.WriteLine();
        }
    }
}
