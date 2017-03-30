using System.Linq;
using Filesplit.WebAPI.Controllers;
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
            _controller = new RecordsController();

            _controller.Post(INPUT_STRING_ONE);
            _controller.Post(INPUT_STRING_TWO);
            _controller.Post(INPUT_STRING_THREE);
        }

        [Fact]
        public void Get_ByGender_ReturnsCorrectOrder()
        {
            var results = _controller.SortedByGender();

            Assert.Equal(FIRST_NAME_ORDERBY_GENDER, results.First().FirstName);
        }
        
        [Fact]
        public void Get_ByDOB_ReturnsCorrectOrder()
        {
            var results = _controller.SortedByBirthDate();

            Assert.Equal(FIRST_NAME_ORDERBY_DOB, results.First().FirstName);
        }

        [Fact]
        public void Get_ByName_ReturnsCorrectOrder()
        {
            var results = _controller.SortedByName();

            Assert.Equal(FIRST_NAME_ORDERBY_NAME, results.First().FirstName);
        }
    }
}
