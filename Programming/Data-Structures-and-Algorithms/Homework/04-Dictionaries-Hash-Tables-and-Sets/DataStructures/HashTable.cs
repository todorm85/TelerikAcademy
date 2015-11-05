namespace DataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<TKey, TVal> : IEnumerable<TVal>
        where TKey : IComparable
    {
        private const int InitialCapacity = 16;

        private LinkedList<KeyValuePair<TKey, TVal>>[] innerListArray;

        public HashTable()
        {
            this.Capacity = InitialCapacity;
            this.innerListArray = new LinkedList<KeyValuePair<TKey, TVal>>[this.Capacity];
        }

        public int Capacity { get; private set; }

        public int Count { get; private set; }

        public void Add(TKey key, TVal value)
        {
            var index = key.GetHashCode() % this.Capacity;
            if (innerListArray[index] == null)
            {
                innerListArray[index] = new LinkedList<KeyValuePair<TKey, TVal>>();
            }

            if (CheckIfKeyExists(key))
            {
                throw new InvalidOperationException("Key already exists.");
            }
            

            innerListArray[index].AddLast(new KeyValuePair<TKey, TVal>(key, value));
            this.Count++;

            if (this.Count >= this.Capacity * .75)
            {
                Autogrow();
            }
        }

        private void Autogrow()
        {
            var currentCapacity = this.Capacity;
            this.Capacity *= 2;
            this.Count = 0;

            var oldInnerListArray = (LinkedList<KeyValuePair<TKey, TVal>>[])this.innerListArray.Clone();
            this.innerListArray = new LinkedList<KeyValuePair<TKey, TVal>>[this.Capacity];

            foreach (var kvPairList in oldInnerListArray)
            {
                if (kvPairList == null)
                {
                    continue;
                }

                foreach (var kvPair in kvPairList)
                {
                    var key = kvPair.Key;
                    var value = kvPair.Value;

                    this.Add(key, value);
                }
            }
        }

        public TVal Find(TKey key)
        {
            if (!CheckIfKeyExists(key))
            {
                throw new ArgumentException("Key does not exist.");
            }

            var index = key.GetHashCode() % this.Capacity;
            var foundValue = this.innerListArray[index].First(x => x.Key.CompareTo(key) == 0).Value;

            return foundValue;
        }

        public void Remove(TKey key)
        {
            if (!CheckIfKeyExists(key))
            {
                throw new ArgumentException("Key does not exist.");
            }

            var index = key.GetHashCode() % this.Capacity;
            var foundKVPair = this.innerListArray[index].First(x => x.Key.CompareTo(key) == 0);

            innerListArray[index].Remove(foundKVPair);
            this.Count--;
        }

        private bool CheckIfKeyExists(TKey key)
        {
            var index = key.GetHashCode() % this.Capacity;

            if (innerListArray[index] == null
                            || !this.innerListArray[index].Any(x => x.Key.CompareTo(key) == 0))
            {
                return false;
            }

            return true;
        }

        public void Clear()
        {
            this.Count = 0;
            this.Capacity = InitialCapacity;
            this.innerListArray = new LinkedList<KeyValuePair<TKey, TVal>>[InitialCapacity];
        }

        public IEnumerator<TVal> GetEnumerator()
        {
            foreach (var kvPairList in this.innerListArray)
            {
                if (kvPairList == null)
                {
                    continue;
                }

                foreach (var kvPair in kvPairList)
                {
                    yield return kvPair.Value;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public TKey[] Keys
        {
            get
            {
                var keys = new List<TKey>();
                foreach (var KVPairList in this.innerListArray)
                {
                    if (KVPairList == null)
                    {
                        continue;
                    }

                    foreach (var KVPair in KVPairList)
                    {
                        keys.Add(KVPair.Key);
                    }
                }

                return keys.ToArray();
            }
        }

        public TVal this[TKey key]
        {
            get
            {
                if (!CheckIfKeyExists(key))
                {
                    throw new ArgumentException("Key does not exist.");
                }

                return this.Find(key);
            }
            set
            {
                this.Remove(key);
                this.Add(key, value);
            }
        }
    }
}