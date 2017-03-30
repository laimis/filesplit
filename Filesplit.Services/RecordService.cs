using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Filesplit.Services
{
    public class RecordService : IRecordService
    {
        private readonly char[] SEPERATORS = new [] {'|', ' ', ','};

        private readonly List<Record> _records = new List<Record>();
        
        // parses records out of input and adds them for
        // "storage" so that they can be retrieved later
        //
        // input format:
        //  array of lines in this format:
        //  LastName | FirstName | Gender | FavoriteColor | DateOfBirth
        //
        // delimters can be '|', 'space', and ',' characters
        public bool Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            using (var reader = new StringReader(input))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var parts = line.Split(SEPERATORS);
                    if (parts.Length != 5)
                    {
                        return false;
                    }

                    var record = CreateRecord(parts);

                    _records.Add(record);

                    line = reader.ReadLine();
                }
            }

            return true;
        }

        private Record CreateRecord(string[] parts)
        {
            return new Record
            {
                LastName = parts[0],
                FirstName = parts[1],
                Gender = parts[2],
                FavoriteColor = parts[3],
                DateOfBirth = DateTimeOffset.Parse(parts[4]),
            };
        }

        public IEnumerable<Record> List()
        {
            return _records.AsReadOnly();
        }

        public IEnumerable<Record> List(OrderBy order)
        {
            if (order == OrderBy.Gender)
            {
                return _records
                    .OrderBy(r => r.Gender)
                    .ThenBy(r => r.LastName);
            }
            else if (order == OrderBy.BirthDate)
            {
                return _records.OrderBy(r => r.DateOfBirth);
            }
            
            return _records.OrderByDescending(r => r.LastName);
        }
    }
}
