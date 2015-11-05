namespace DataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashedSet<T> : IEnumerable<T>
        where T : IComparable
    {
        private HashTable<int, T> innerTable = new HashTable<int, T>();

        public void Add(T value)
        {
            int hash = value.GetHashCode();

            this.innerTable.Add(hash, value);
        }

        public bool Find(T value)
        {
            return this.innerTable.Any(x => x.CompareTo(value) == 0);
        }

        public void Remove(T value)
        {
            int hash = value.GetHashCode();

            this.innerTable.Remove(hash);
        }

        public int Count()
        {
            return this.innerTable.Count();
        }

        public void Clear()
        {
            this.innerTable.Clear();
        }

        public void Union(HashedSet<T> otherSet)
        {
            if (otherSet == null)
            {
                throw new ArgumentNullException("Other set cannot be null.");
            }

            foreach (var value in otherSet)
            {
                if (!this.innerTable.Any(x => x.CompareTo(value) == 0))
                {
                    this.Add(value);
                }
            }
        }

        public void Intersect(HashedSet<T> otherSet)
        {
            if (otherSet == null)
            {
                throw new ArgumentNullException("Other set cannot be null.");
            }

            var duplicateValues = new List<T>();
            foreach (var value in otherSet)
            {
                if (this.innerTable.Any(x => x.CompareTo(value) == 0))
                {
                    duplicateValues.Add(value);
                }
            }

            this.innerTable.Clear();
            foreach (var value in duplicateValues)
            {
                this.Add(value);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var value in this.innerTable)
            {
                yield return value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
