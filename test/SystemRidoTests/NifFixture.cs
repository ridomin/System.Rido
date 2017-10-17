using System;
using System.Linq;
using Xunit;

namespace SystemRidoTests
{
    public class NifFixture
    {
        [Fact]
        public void SampleNifs()
        {
            AssertNif("00000001R");
            AssertNif("02635702V");
        }

        void AssertNif(string data)
        {
            Console.WriteLine(data);
            Assert.AreEqual(CifNif.Nif, NifCifValidator.IsNifCif(data));
        }
    }
}
