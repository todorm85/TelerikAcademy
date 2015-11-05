using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace DataStructures.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void FindShouldReturnTheCorrectElementOnValidSearchKey()
        {
            var hashTable = new HashTable<int, int>();
            hashTable.Add(1, 5);

            var actual = hashTable.Find(1);

            Assert.AreEqual(5, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindShould_ThrowOnInvalidSearchKey()
        {
            var hashTable = new HashTable<int, int>();
            hashTable.Add(1, 5);

            hashTable.Find(2);
        }

        [TestMethod]
        public void FindShouldReturnTheCorrectElementWhenItsKeyHasDuplicateHashWithAnotherKey()
        {
            var hashTable = new HashTable<int, int>();
            var capacity = hashTable.Capacity;
            hashTable.Add(capacity, 5);
            hashTable.Add(2 * capacity, 7);

            var actual = hashTable.Find(2 * capacity);

            Assert.AreEqual(7, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindShouldThrowIfSearchingForNonexistingKeyWithDuplicateHashOfAnotherExistingKey()
        {
            var hashTable = new HashTable<int, int>();
            var capacity = hashTable.Capacity;
            hashTable.Add(capacity, 5);

            hashTable.Find(2 * capacity);
        }

        [TestMethod]
        public void CountShouldBeZeroInitially()
        {
            var hashTable = new HashTable<int, int>();

            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        public void CountShouldIncreaseWithAddedValues()
        {
            var hashTable = new HashTable<int, int>();
            hashTable.Add(1, 5);
            hashTable.Add(2, 5);

            Assert.AreEqual(2, hashTable.Count);
        }

        [TestMethod]
        public void RemoveShouldWorkWithValidKey()
        {
            var hashTable = new HashTable<int, int>();
            hashTable.Add(1, 5);
            hashTable.Remove(1);

            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveShouldRemoveCorrectValueWhenKeysWithDuplicateHashArePresent()
        {
            var hashTable = new HashTable<int, int>();
            var capacity = hashTable.Capacity;
            hashTable.Add(capacity, 5);
            hashTable.Add(capacity * 2, 1);

            hashTable.Remove(capacity);
            var actual = hashTable.Find(capacity * 2);

            Assert.AreEqual(1, actual);
            hashTable.Find(capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveShouldThrowOnInvalidKey()
        {
            var hashTable = new HashTable<int, int>();
            hashTable.Add(1, 5);
            hashTable.Remove(2);
        }

        [TestMethod]
        public void CountShouldDecreaseWhenRemovingValues()
        {
            var hashTable = new HashTable<int, int>();
            hashTable.Add(1, 5);
            hashTable.Remove(1);

            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        public void CapacityShouldDoubleWhen75PercentReached()
        {
            var hashTable = new HashTable<int, int>();
            var capacity = hashTable.Capacity;

            for (int i = 0; i <= capacity; i++)
            {
                hashTable.Add(i, i);
            }

            Assert.AreEqual(capacity * 2, hashTable.Capacity);
        }

        [TestMethod]
        public void CapacityDoublingShouldRetainExistingValues()
        {
            var hashTable = new HashTable<int, int>();
            var capacity = hashTable.Capacity;

            for (int i = 0; i <= capacity; i++)
            {
                hashTable.Add(i, i);
            }

            for (int i = 0; i <= capacity; i++)
            {
                Assert.AreEqual(i, hashTable.Find(i));
            }
        }

        [TestMethod]
        public void CountShouldBeCorrectAfterCapacityHasBeenDoubled()
        {
            var hashTable = new HashTable<int, int>();
            var capacity = hashTable.Capacity;

            for (int i = 0; i <= capacity; i++)
            {
                hashTable.Add(i, i);
            }

            Assert.AreEqual(capacity + 1, hashTable.Count);
        }

        [TestMethod]
        public void ClearShouldResetCount()
        {
            var hashTable = new HashTable<int, int>();
            var capacity = hashTable.Capacity;

            for (int i = 0; i <= capacity; i++)
            {
                hashTable.Add(i, i);
            }

            hashTable.Clear();

            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        public void ClearShouldRemoveAllElements()
        {
            var hashTable = new HashTable<int, int>();
            var capacity = hashTable.Capacity;

            for (int i = 0; i <= capacity; i++)
            {
                hashTable.Add(i, i);
            }

            hashTable.Clear();

            for (int i = 0; i <= capacity; i++)
            {
                try
                {
                    hashTable.Find(capacity);
                }
                catch (ArgumentException)
                {
                    continue;
                }

                Assert.Fail();
            }
        }

        [TestMethod]
        public void KeysPropertyShouldReturnAllKeys()
        {
            var hashTable = new HashTable<int, int>();
            var capacity = hashTable.Capacity;

            for (int i = 0; i < capacity; i++)
            {
                hashTable.Add(i, i);
            }

            var keys = new List<int>(hashTable.Keys);

            for (int i = 0; i < capacity; i++)
            {
                Assert.IsTrue(keys.Contains(i));
            }

            Assert.AreEqual(capacity, keys.Count);
        }

        [TestMethod]
        public void IndexerShouldReturnCorrectValue()
        {
            var hashTable = new HashTable<int, int>();
            hashTable.Add(5, 3);

            var actual = hashTable[5];

            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void IndexerShouldEditExistingKey()
        {
            var hashTable = new HashTable<int, int>();
            hashTable.Add(5, 3);

            hashTable[5] = 2;
            var actual = hashTable[5];

            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IndexerShouldThrowOnSetIfNonexistentValue()
        {
            var hashTable = new HashTable<int, int>();

            hashTable[5] = 3;
            var actual = hashTable.Find(5);

            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IndexerShouldThrowOnGetIfNonexistentKey()
        {
            var hashTable = new HashTable<int, int>();

            var actual = hashTable[5];
        }

        [TestMethod]
        public void EnumerationShouldReturnAllValues()
        {
            var hashTable = new HashTable<int, int>();
            var capacity = hashTable.Capacity;

            for (int i = 0; i < capacity; i++)
            {
                hashTable.Add(i, i);
            }

            var keys = new List<int>(hashTable.Keys);

            foreach (var value in hashTable)
            {
                var foundKey = hashTable.Find(value);
                keys.Remove(foundKey);
            }

            Assert.AreEqual(0, keys.Count);
        }
    }
}
