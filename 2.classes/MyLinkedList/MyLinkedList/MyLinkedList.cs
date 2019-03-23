using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    class MyLinkedList<T> : IEnumerable<T>
        where T: IComparable<T>
    {
        int maxItemCount;
        int currentPos;
        int maxEvailabledPos;
        T[] items;

        public MyLinkedList()
        {
            maxItemCount = 8;
            currentPos = 0;
            items = new T[maxItemCount];
        }

        public void Add(T item)
        {
            if (currentPos == maxItemCount)
            {
                maxItemCount *= 2;
                Array.Resize<T>(ref items, maxItemCount);
            }
            if (currentPos > maxEvailabledPos)
            {
                maxEvailabledPos++;
            }
            items[currentPos++] = item;
            Array.Sort(items, 0, maxEvailabledPos);
        }

        public void SetOnFirst()
        {
            currentPos = 0;
        }

        public T Next()
        {
            if (currentPos > maxEvailabledPos)
            {
                throw new Exception("You can't refer to a non-existent element");
            }
            return items[currentPos++];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i <= maxEvailabledPos; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
