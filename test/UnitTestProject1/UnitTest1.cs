using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestRep2;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
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
