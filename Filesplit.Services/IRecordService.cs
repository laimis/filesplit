using System.Collections.Generic;

namespace Filesplit.Services
{
    public interface IRecordService
    {
        bool Add(string input);

        IEnumerable<Record> List(OrderBy order);
    }
}