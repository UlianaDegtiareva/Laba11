using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLaba10;

namespace Laba11
{
    internal class List <T> //обобщенный класс
    {
        T[] list;
        int capacity;
        int count;

        public int Capacity
        { 
            get => list.Length;
            private set => capacity = value;
        }
        public int Count { get => count; }

        public List()
        { 
            Capacity = 0;
            list = new T[Capacity];
        }
        public List(params T[] list)
        { 
            Capacity = list.Length;
            count = 0;
            this.list = new T[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                this.list[i] = list[i];
                count++;
            }
        }

        public T this[int index]
        { 
            get { return list[index]; } set { list[index] = value; }
        }

        public void Add(T item)
        { 
            if (item == null)
                throw new ArgumentNullException();
            if (Count < Capacity)
            {
                list[count++] = item;
            }
            else 
            {
                T[] temp = new T[Capacity*2];
                for (int i = 0; i < list.Length; i++)
                { 
                    temp[i] = list[i];
                }
                temp[count++] = item;
                list = temp;
            }
        }
        public void Remove(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            int index = Array.IndexOf(list, item);
            if (index < 0)
                return;
            for (int i = index; i < Count - 1; i++)
            {
                list[i] = list[i + 1];
            }
            count--;
            if (Count < Capacity / 2)
            {
                T[] temp = new T[Capacity / 2];
                for (int i = 0; i < Count; i++)
                {
                    temp[i] = list[i];
                }
                list = temp;
            }
        }
    }
}
