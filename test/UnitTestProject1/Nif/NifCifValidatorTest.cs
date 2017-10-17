using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestRep2
{
    /// <summary>
    /// Summary description for NifCifValidatorTest
    /// </summary>
    [TestClass]
    public class NifCifValidatorTest
    {
        public NifCifValidatorTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

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

        [TestMethod]
        public void GenerateNifTest()
        {

            for (Int32 i = 02635700; i < 02635730; i++)
            {
                
                AssertNif(NifGenerator.GenerateNif(i));
            }
        }

        [TestMethod]
        public void GenerateRandomNifTest()
        {

            for (Int32 i = 0; i < 10; i++)
            {
                AssertNif(NifGenerator.GenerateRandomNif());
            }
        }

        [TestMethod]
        public void GenerateRandomNifArrayTest()
        {
            List<String> nifs = NifGenerator.GenerateRandomNif(500);
            for (Int32 i = 0; i < 500; i++)
            {
                AssertNif(nifs[i]);
            }
        }


    }
}
