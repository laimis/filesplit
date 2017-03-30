using System.Collections.Generic;
using System.Linq;
using Filesplit.Services;
using Filesplit.WebAPI.Controllers;
using Filesplit.WebAPI.OutputModels;
using Xunit;

namespace Filesplit.WebAPI.Tests
{
    public class RecordsControllerTests
    {
        RecordsController _controller;

        private const string INPUT_STRING_ONE = "Smith|Jane|Female|Black|04/05/1950";
        private const string INPUT_STRING_TWO = "Doe|Lori|Female|Black|01/21/1990";
        private const string INPUT_STRING_THREE = "Swick|Rob|Male|Black|10/10/2005";

        private const string FIRST_NAME_ORDERBY_GENDER = "Lori";
        private const string FIRST_NAME_ORDERBY_DOB = "Jane";
        private const string FIRST_NAME_ORDERBY_NAME = "Rob";

        
        public RecordsControllerTests()
        {
            var service = new RecordService();

            _controller = new RecordsController(service);

            _controller.Post(INPUT_STRING_ONE);
            _controller.Post(INPUT_STRING_TWO);
            _controller.Post(INPUT_STRING_THREE);
        }

        [Fact]
        public void Get_ByGender_ReturnsCorrectOrder()
        {
            var results = _controller.SortedByGender();

            AssertCorrectRecordReturned(results, FIRST_NAME_ORDERBY_GENDER);
        }
        
        [Fact]
        public void Get_ByDOB_ReturnsCorrectOrder()
        {
            var results = _controller.SortedByBirthDate();

            AssertCorrectRecordReturned(results, FIRST_NAME_ORDERBY_DOB);
        }

        [Fact]
        public void Get_ByName_ReturnsCorrectOrder()
        {
            var results = _controller.SortedByName();

            AssertCorrectRecordReturned(results, FIRST_NAME_ORDERBY_NAME);
        }

        private void AssertCorrectRecordReturned(IEnumerable<RecordOutputModel> records, string expected)
        {
            Assert.Equal(expected, records.First().FirstName);
        }
    }
}
