using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int current = 0;

        public IntegerList()
        {
            _internalStorage = new int[4];
        }

        public IntegerList(int initialSize)
        {
            if (initialSize < 0)
            {
                throw new Exception();// bolje ovo napraviti
            }
            _internalStorage = new int[initialSize];
        }

        public int Count
        {
            get
            {
                return current;
            }
        }

        public void Add(int item)
        {
            current++;
            if (current >= _internalStorage.Length)
            {
                int[] temp = _internalStorage;
                _internalStorage = new int[temp.Length * 2];
                Array.Copy(temp, _internalStorage, temp.Length);
            }
            _internalStorage[current - 1] = item;
        }

        public void Clear()
        {
            Array.Clear(_internalStorage, 0, _internalStorage.Length);
            current = 0;
        }

        public bool Contains(int item)
        {
            foreach (int i in _internalStorage)
            {
                if (i == item)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetElement(int index)
        {
            if (index < _internalStorage.Length)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(int item)
        {
            int len = _internalStorage.Length;
            for (int i = 0; i < len; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(int item)
        {
            int len = _internalStorage.Length;
            for (int i = 0; i < len; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= current)
            {
                return false;
            }
            _internalStorage[index] = 0;
            int len = current;
            for (int i = index + 1; i < len; i++)
            {
                _internalStorage[i - 1] = _internalStorage[i];
            }
            current--;
            return true;
        }

        public static void ListExample(IIntegerList listOfIntegers)
        {
            listOfIntegers.Add(1); // [1]
            listOfIntegers.Add(2); // [1 ,2]
            listOfIntegers.Add(3); // [1 ,2 ,3]
            listOfIntegers.Add(4); // [1 ,2 ,3 ,4]
            listOfIntegers.Add(5); // [1 ,2 ,3 ,4 ,5]
            listOfIntegers.RemoveAt(0); // [2 ,3 ,4 ,5]
            listOfIntegers.Remove(5); // [2 ,3 ,4]
            Console.WriteLine(listOfIntegers.Count); // 3
            Console.WriteLine(listOfIntegers.Remove(100)); // false
            Console.WriteLine(listOfIntegers.RemoveAt(5)); // false
            listOfIntegers.Clear(); // []
            Console.WriteLine(listOfIntegers.Count); // 0
            Console.Read();
        }

        public static void Main(string[] args)
        {
            IIntegerList list = new IntegerList(5);
            ListExample(list);
        }
    }
}
