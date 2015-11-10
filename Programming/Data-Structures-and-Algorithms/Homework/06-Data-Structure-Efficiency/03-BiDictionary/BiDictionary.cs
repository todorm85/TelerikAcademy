
namespace BiDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides fast search by keys O(1). Removing is slow O(n).
    /// </summary>
    public class BiDictionary<K1, K2, V>
    {
        private Dictionary<K1, List<V>> firstKeyDictionary = new Dictionary<K1, List<V>>();
        private Dictionary<K2, List<V>> secondKeyDictionary = new Dictionary<K2, List<V>>();
        private Dictionary<int, V> bothKeysDictionary = new Dictionary<int, V>();

        public void Add(K1 key1, K2 key2, V value)
        {
            if (key1 == null || key2 == null)
            {
                throw new ArgumentNullException("Keys cannot be null");
            }

            if (!firstKeyDictionary.ContainsKey(key1))
            {
                firstKeyDictionary[key1] = new List<V>();
            }

            firstKeyDictionary[key1].Add(value);


            if (!secondKeyDictionary.ContainsKey(key2))
            {
                secondKeyDictionary[key2] = new List<V>();
            }

            secondKeyDictionary[key2].Add(value);


            var bothKeysHash = GetBothKeysHashCode(key1, key2);
            bothKeysDictionary.Add(bothKeysHash, value);
        }

        private int GetBothKeysHashCode(K1 key1, K2 key2)
        {
            return (key1.GetHashCode() | key2.GetHashCode()) + (key1.GetHashCode() ^ key2.GetHashCode());
        }

        public V this[K1 key1, K2 key2]
        {
            get
            {
                var bothKeysHash = GetBothKeysHashCode(key1, key2);
                return this.bothKeysDictionary[bothKeysHash];
            }
            set
            {
                var bothKeysHash = GetBothKeysHashCode(key1, key2);
                this.bothKeysDictionary[bothKeysHash] = value;
            }
        }

        public V Find(K1 key1, K2 key2)
        {
            var bothKeysHash = GetBothKeysHashCode(key1, key2);

            return this.bothKeysDictionary[bothKeysHash];
        }

        public List<V> FindAllByFirstKey(K1 key)
        {
            return this.firstKeyDictionary[key];
        }

        public List<V> FindAllBySecondKey(K2 key)
        {
            return this.secondKeyDictionary[key];
        }

        public void Remove(K1 key1, K2 key2)
        {
            firstKeyDictionary.Remove(key1);
            secondKeyDictionary.Remove(key2);

            var bothKeysHash = GetBothKeysHashCode(key1, key2);
            bothKeysDictionary.Remove(bothKeysHash);
        }
    }
}
