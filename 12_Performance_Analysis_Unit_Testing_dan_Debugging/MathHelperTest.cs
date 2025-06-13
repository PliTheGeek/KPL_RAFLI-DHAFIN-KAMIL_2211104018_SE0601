using Xunit;
using Modul12_2211104018; // Make sure this matches your main project's namespace

namespace Modul12Test
{
    public class MathHelperTest
    {
        [Theory]
        [InlineData(5, 0, 1)]      // b == 0
        [InlineData(5, -2, -1)]    // b < 0
        [InlineData(101, 2, -2)]   // a > 100
        [InlineData(2, 11, -2)]    // b > 10
        [InlineData(2, 3, 8)]      // normal
        [InlineData(3, 19, -3)]    // overflow
        public void CariNilaiPangkat_Tests(int a, int b, int expected)
        {
            int result = MathHelper.CariNilaiPangkat(a, b);
            Assert.Equal(expected, result);
        }
    }
}
