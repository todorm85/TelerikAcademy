using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClass
{
    class GenericList<T>
        where T: IComparable
    {
        #region Fields

        private T[] _collection;
        private int _count;

        #endregion

        #region Properties

        public int Count
        {
            get
            {
                return this._count;
            }
            private set
            {
                this._count = value;
            }
        }

        public T this[int index]
        {    
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentException("Nonexistent element. Index out of range!");
                }

                return this._collection[index];
            }
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentException("Nonexistent element. Index out of range!");
                }

                this._collection[index] = value;
            }
        }

        #endregion

        #region Constructors

        public GenericList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("List cannot have less than or equl to 0 capacity!");
            }

            this._collection = new T[capacity];
            this.Count = 0;
        }

        #endregion

        #region Methods

        public T Max()
        {
            T max = this._collection[0];
            for (int i = 1; i < Count; i++)
            {
                if (max.CompareTo(this._collection[i])<=0)
                {
                    max = this._collection[i];
                }
            }

            return max;
        }

        public T Min()
        {
            T min = this._collection[0];
            for (int i = 1; i < Count; i++)
            {
                if (min.CompareTo(this._collection[i]) > 0)
                {
                    min = this._collection[i];
                }
            }

            return min;
        }

        public void AddElement(T element)
        {
            if (Count >= _collection.Length)
            {
                //throw new ArgumentException(String.Format("The capacity of {0} exceeded!", _collection.Length));
                T[] newCollection = new T[this._collection.Length * 2];
                for (int i = 0; i < this.Count; i++)
                {
                    newCollection[i] = this._collection[i];
                }

                this._collection = newCollection;
            }

            this._collection[Count] = element;
            Count++;
        }

        public T GetElement(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentException("Invalid GenericList index!!");
            }

            return _collection[index];
        }

        public void RemoveElement(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentException("Invalid GenericList index for removing!!");
            }

            for (int i = index; i < this._collection.Length - 1; i++)
            {
                this._collection[i] = this._collection[i + 1];
            }

            this.Count--;
        }

        public void InsertElement(T element, int index)
        {
            if (Count >= this._collection.Length)
            {
                //throw new ArgumentException(String.Format("The capacity of {0} exceeded!", _collection.Length));
                T[] newCollection = new T[this._collection.Length * 2];
                for (int i = 0; i < this.Count; i++)
                {
                    newCollection[i] = this._collection[i];
                }

                this._collection = newCollection;
            }

            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentException("Invalid GenericList index! Index was outside the bounds of the collection");
            }

            for (int i = this.Count; i >= index + 1; i--)
            {
                this._collection[i] = this._collection[i - 1];
            }

            this._collection[index] = element;
            this.Count++;
        }

        public void ClearList()
        {
            this._collection = new T[this._collection.Length];
            this.Count = 0;
        }

        public int FindElement(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((element.CompareTo(this._collection[i])) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public override string ToString()
        {
            //return String.Join(", ", this._collection);
            if (this.Count == 0)
            {
                return "Empty list";
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                sb.Append(String.Format("{0}, ", this._collection[i]));
            }

            return sb.ToString().TrimEnd(' ', ',');
        }

        #endregion
    }
}
