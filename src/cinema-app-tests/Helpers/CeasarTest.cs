using Xunit;
using cinema_app_api.Helpers;

namespace cinema_app_tests
{
    public class CeasarTest
    {
        private readonly Ceasar _ceasar;

        public CeasarTest()
        {
            _ceasar = new Ceasar();
        }

        [Theory]
        [InlineData("bcd", "abc")]
        [InlineData("yza", "xyz")]
        [InlineData("bcdefghijklmnopqrstuvwxyza", "abcdefghijklmnopqrstuvwxyz")]
        [InlineData("Hfojvt xjuipvu fevdbujpo jt mjlf tjmwfs jo uif njof", "Genius without education is like silver in the mine")]
        [InlineData("Dbftbs DjqifS. :)", "Caesar CipheR. :)")]
        public void EncodeTest(string expected, string input)
        {
            Assert.Equal(expected, _ceasar.Encrypt(input));
        }

        [Theory]
        [InlineData("abc", "bcd")]
        [InlineData("xyz", "yza")]
        [InlineData("abcdefghijklmnopqrstuvwxyz", "bcdefghijklmnopqrstuvwxyza")]
        [InlineData("Genius without education is like silver in the mine", "Hfojvt xjuipvu fevdbujpo jt mjlf tjmwfs jo uif njof")]
        [InlineData("Caesar CipheR. :)", "Dbftbs DjqifS. :)")]
        public void DecodeTest(string expected, string input)
        {
            Assert.Equal(expected, _ceasar.Decrypt(input));
        }
    }
}