using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLaba10;

namespace Laba11
{
    internal class MySortedDictionary<K , T> : IEnumerable<KeyValuePair<K, T>>
    {
        SortedDictionary<K, T> dict;
        
        int count;
        int capacity;

        public int Capacity
        {
            get => capacity;
            private set => capacity = value;
        }

        public int Count { get => count; }

        public MySortedDictionary()
        { 
            Capacity = 0;
            dict = new SortedDictionary<K, T>();
        }
        public MySortedDictionary(IEnumerable<KeyValuePair<K, T>> col)
        {
            foreach (KeyValuePair<K, T> item in col)
            {
                this.Add(item.Key, item.Value);
            }
        }

        public void Add(K key, T element)
        { 
            if (element == null)
                throw new ArgumentNullException();
            foreach (K existing in dict.Keys)
            {
                if (EqualityComparer<K>.Default.Equals(existing, key))
                {
                    return;
                }
            }
            dict.Add(key, element);
            count++;
        }
        public void Remove(K key)
        {
            foreach (K existingKey in dict.Keys)
            {
                if (EqualityComparer<K>.Default.Equals(existingKey, key))
                {
                    dict.Remove(key);
                    count--;
                    return;
                }
            }
        }

        public MySortedDictionary<K, T> CloneDictionary()
        {
            MySortedDictionary<K, T> clone = new MySortedDictionary<K, T>();

            foreach (KeyValuePair<K, T> pair in dict)
            { 
                clone.Add(pair.Key, pair.Value);
            }
            return clone;
        }

        public int Search (MySortedDictionary<K, T> d, Plants plants)
        {
            int index = 0;
            bool exist = false;
            foreach (KeyValuePair<K, T> pair in d)
            {
                if (plants.Equals(pair.Key))
                {
                    exist = true;
                    break;
                }
                index++;
            }
            if (exist)
                return index;
            else return -1;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            return dict.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dict.GetEnumerator();
        }
    }
}
