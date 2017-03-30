using System;
using System.Linq;
using Xunit;

namespace Filesplit.Services.Tests
{
    public class RecordServiceTests
    {
        private const string INVALID_INPUT_NULL = null;
        private const string INVALID_INPUT_BADFORMAT = "notoexpstingthis";
        private const string VALID_INPUT_PIPE = "Simutis|Laimonas|Male|Blue|1982/04/22";
        private const string VALID_INPUT_SPACE = "Simutis Laimonas Male Blue 1982/04/22";
        private const string VALID_INPUT_COMMA = "Simutis,Laimonas,Male,Blue,1982/04/22";
        private const string VALID_INPUT_MULTIPLE = 
@"Simutis,Laimonas,Male,Blue,1982/04/22
Bauer,Emily,Female,Blue,2013/06/12
Bauer,Isabel,Female,Blue,2017/07/29
";
        private const string RECORD_TEST_LAST = "Simutis";
        private const string RECORD_TEST_FIRST = "Laimonas";
        private const string RECORD_TEST_GENDER = "Male";
        private const string RECORD_TEST_COLOR = "Blue";
        private DateTimeOffset RECORD_TEST_DOB = DateTimeOffset.Parse("04/22/1982");
        private const string SORTED_TEST_FIRSTNAME_BY_GENDER = "Emily";
        private const string SORTED_TEST_FIRSTNAME_BY_BOD = "Laimonas";
        private const string SORTED_TEST_FIRSTNAME_BY_LAST = "Laimonas";


        [Fact]
        public void Add_WithEmptyInput_Fails()
        {
            var service = new RecordService();

            var result = service.Add(INVALID_INPUT_NULL);

            Assert.False(result, "Adding null input should fail");
        }

        [Fact]
        public void Add_WithInvalidRecords_Fails()
        {
            var service = new RecordService();
            
            var result = service.Add(INVALID_INPUT_BADFORMAT);

            Assert.False(result, "Adding invalid input should fail");
        }

        [Fact]
        public void Add_WithValidRecordsComma_Succeeds()
        {
            TestIfValidParse(VALID_INPUT_COMMA);
        }

        [Fact]
        public void Add_WithValidRecordsPipe_Succeeds()
        {
            TestIfValidParse(VALID_INPUT_PIPE);
        }

        [Fact]
        public void Add_WithValidRecordsSpace_Succeeds()
        {
            TestIfValidParse(VALID_INPUT_SPACE);
        }
        
        private void TestIfValidParse(string input)
        {
            var service = new RecordService();
            
            var result = service.Add(input);

            Assert.True(result, "Adding valid input should succeed");
        }

        [Fact]
        public void Add_AddsCorrectNumberOfRecords()
        {
            var service = new RecordService();

            service.Add(VALID_INPUT_MULTIPLE);

            var result = service.List();

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void Add_CorrectlyParses()
        {
            var service = CreateServiceAndAddRecords();

            var result = service.List();

            var record = result.First();

            Assert.Equal(RECORD_TEST_COLOR, record.FavoriteColor);
            Assert.Equal(RECORD_TEST_DOB, record.DateOfBirth);
            Assert.Equal(RECORD_TEST_FIRST, record.FirstName);
            Assert.Equal(RECORD_TEST_LAST, record.LastName);
            Assert.Equal(RECORD_TEST_GENDER, record.Gender);
        }

        private static RecordService CreateServiceAndAddRecords()
        {
            var service = new RecordService();

            service.Add(VALID_INPUT_MULTIPLE);

            return service;
        }

        [Fact]
        public void List_SortByGender_ReturnsProperOrder()
        {
            var service = CreateServiceAndAddRecords();

            var results = service.List(OrderBy.Gender);

            var record = results.First();

            Assert.Equal(SORTED_TEST_FIRSTNAME_BY_GENDER, record.FirstName);
        }

        [Fact]
        public void List_SortByBOD_ReturnsProperOrder()
        {
            var service = CreateServiceAndAddRecords();

            var results = service.List(OrderBy.BirthDate);

            var records = results.First();

            Assert.Equal(SORTED_TEST_FIRSTNAME_BY_BOD, records.FirstName);
        }

        [Fact]
        public void List_SortByLastName_ReturnsProperOrder()
        {
            var service = CreateServiceAndAddRecords();

            var results = service.List(OrderBy.LastName);

            var records = results.First();

            Assert.Equal(SORTED_TEST_FIRSTNAME_BY_LAST, records.FirstName);
        }
    }
}
