using Xunit;
using static ValidaCNPJ.ValidaCNPJ;

namespace ValidaCNPJ.Tests
{
    public class ValidaCNPJTests
    {
        [Theory]
        [InlineData("00000000000000")]
        [InlineData("11111111111111")]
        [InlineData("22222222222222")]
        [InlineData("13.462.548/2574-82")]
        [InlineData("99.555.666/9902-92")]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData("testingWithText")]
        public void When_Given_Invalid_CNPJ_Should_Return_False(string cnpj)
        {
            Assert.False(Validate(cnpj));
        }
        [Theory]
        [InlineData("96458726000141")]
        [InlineData("74463210000152")]
        [InlineData("03.261.874/0001-90")]
        [InlineData("65.492.604/0001-48")]
        [InlineData("94.919.010/0001-79")]
        [InlineData("68.152.912/0001-12")]
        public void When_Given_Valid_CNPJ_Should_Return_True(string cnpj)
        {
            Assert.True(Validate(cnpj));
        }
    }
}
