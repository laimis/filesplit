namespace Filesplit.Services
{
    public class RecordService : IRecordService
    {
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
            return false;
        }
    }
}
