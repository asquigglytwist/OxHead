using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test_AdvanceDataStructures
{
    
    
    /// <summary>
    ///This is a test class for TrieTest and is intended
    ///to contain all TrieTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TrieTest
    {

        string[] asWordsToAdd = { string.Empty, "a", "abc", "abcd", "asdf", "aaabbcacc", "bcdef" };
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for DoesWordCountIncreaseTest
        ///</summary>
        [TestMethod()]
        public void DoesWordCountIncreaseTest()
        {
            Trie target = new Trie();
            for (int i = 1; i < asWordsToAdd.Length; i++)
            {
                Assert.IsTrue(target.AddWord(asWordsToAdd[i]));
                Assert.AreEqual(i, target.WordCount);
            }
            Assert.IsFalse(target.AddWord(asWordsToAdd[0]), "Cannot add empty string to Trie.");
        }
    }
}
