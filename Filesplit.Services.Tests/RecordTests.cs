using System;
using Xunit;

namespace Filesplit.Services.Tests
{
    public class RecordTests
    {
        [Fact]
        public void DateOfBirthFormatted_ReturnsCorrectFormat()
        {
            var r = new Record();

            r.DateOfBirth = DateTimeOffset.Parse("1982/04/22");

            Assert.Equal("04/22/1982", r.DateOfBirthFormmated);
        }
    }
}
