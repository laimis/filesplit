using System;

namespace Filesplit.Services
{
    public class Record
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string FavoriteColor { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
    }
}