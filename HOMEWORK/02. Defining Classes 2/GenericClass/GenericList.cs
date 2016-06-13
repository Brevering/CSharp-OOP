namespace GenericClass
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class GenericList<T> : IEnumerable<T>
        where T : IComparable
    {
        private T[] data;
        private int lastPosition = 0;

        public GenericList(int capacity)
        {
            this.data = new T[capacity];
        }

        public void Add(T element)
        {
            if (this.lastPosition == this.data.Length)
            {
                this.AutoGrow();
            }

            this.data[lastPosition] = element;
            this.lastPosition++;
        }

        public T this[int index]
        {
            get
            {
                if (index > this.lastPosition - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.data[index];
            }
            private set { this.data[index] = value; }
        }

        public void Clear()
        {
            this.data = new T[this.data.Length];
            this.lastPosition = 0;
        }

        public T Min()
        {
            T min = this.data[0];
            foreach (T element in this.data)
            {
                if (element.CompareTo(min) < 0)
                {
                    min = element;
                }
            }
            return min;
        }

        public T Max()
        {
            T max = this.data[0];
            foreach (T element in this.data)
            {
                if (element.CompareTo(max) > 0)
                {
                    max = element;
                }
            }
            return max;
        }

        public void RemoveByIndex(int index)
        {
            for (int i = index; i < this.lastPosition && i < this.data.Length - 1; i++)
            {
                this.data[i] = this.data[i + 1];
            }
            this.lastPosition--;
            this.data[lastPosition] = default(T);
        }

        public void InsertAtIndex(int index, T element)
        {
            if (this.lastPosition == this.data.Length)
            {
                this.AutoGrow();
            }

            for (int i = this.lastPosition; i > index && i > 0; i--)
            {
                this.data[i] = this.data[i - 1];
            }
            this.data[index] = element;
            this.lastPosition++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.lastPosition; i++)
            {
                sb.Append(this.data[i]);
                if (i < this.lastPosition - 1)
                {
                    sb.Append(", ");
                }
            }
            return sb.ToString();
        }

        private void AutoGrow()
        {
            var newData = new T[this.data.Length * 2];

            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }
            this.data = newData;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.data.Length; i++)
            {
                if (this.data[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
