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

        private RecordService Service = new RecordService();

        [Fact]
        public void Add_WithEmptyInput_Fails()
        {
            var result = this.Service.Add(INVALID_INPUT_NULL);

            Assert.False(result, "Adding null input should fail");
        }

        [Fact]
        public void Add_WithInvalidRecords_Fails()
        {
            var result = this.Service.Add(INVALID_INPUT_BADFORMAT);

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
            var result = this.Service.Add(input);

            Assert.True(result, "Adding valid input should succeed");
        }
    }
}
