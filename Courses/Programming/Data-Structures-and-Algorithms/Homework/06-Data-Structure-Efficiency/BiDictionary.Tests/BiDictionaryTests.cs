namespace BiDictionary.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BiDictionary;
    using System.Collections.Generic;

    [TestClass]
    public class BiDictionaryTests
    {
        [TestMethod]
        public void Find_SouldFindValuesAddedByBothKeys()
        {
            // arrange
            var dic = new BiDictionary<int, string, string>();

            // act
            dic.Add(2, "two", "second");
            var actual = dic[2, "two"];

            // assert
            Assert.AreEqual("second", actual);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Find_SouldThrowIfKeysCombinationNotFound()
        {
            // arrange
            var dic = new BiDictionary<int, string, string>();

            // act
            dic.Add(2, "two", "second");
            var actual = dic[3, "two"];

            // assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void FindByFirstKey_SouldFindAllValuesAddedByGivenFirstKey()
        {
            // arrange
            var dic = new BiDictionary<int, string, string>();

            // act
            dic.Add(2, "two", "second");
            dic.Add(2, "three", "third");
            dic.Add(3, "four", "fourth");

            var actual = dic.FindAllByFirstKey(2);

            // assert
            Assert.AreEqual(2, actual.Count);
        }

        [TestMethod]
        public void FindBySecondKey_SouldFindAllValuesAddedByGivenSecondKey()
        {
            // arrange
            var dic = new BiDictionary<int, string, string>();

            // act
            dic.Add(1, "two", "second");
            dic.Add(2, "two", "third");
            dic.Add(3, "two", "fourth");
            dic.Add(3, "one", "fourth");

            var actual = dic.FindAllBySecondKey("two");

            // assert
            Assert.AreEqual(3, actual.Count);
        }
    }
}