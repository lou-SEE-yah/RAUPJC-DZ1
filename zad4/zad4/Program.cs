using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad4
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int current = 0;

        public GenericList()
        {
            _internalStorage = new X[4];
        }

        public GenericList(int initialSize)
        {
            if (initialSize < 0)
            {
                throw new Exception();// bolje ovo napraviti
            }
            _internalStorage = new X[initialSize];
        }

        public int Count
        {
            get
            {
                return current;
            }
        }

        public void Add(X item)
        {
            current++;
            if (current > _internalStorage.Length)
            {
                X[] temp = _internalStorage;
                _internalStorage = new X[temp.Length * 2];
                Array.Copy(temp, _internalStorage, temp.Length);
            }
            _internalStorage[current - 1] = item;
        }

        public void Clear()
        {
            Array.Clear(_internalStorage, 0, _internalStorage.Length);
            current = 0;
        }

        public bool Contains(X item)
        {
            foreach (X i in _internalStorage)
            {
                if (i.Equals(item))//provjeri
                {
                    return true;
                }
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index < _internalStorage.Length && index >= 0)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(X item)
        {
            for (int i = 0, len = _internalStorage.Length; i < len; i++)
            {
                if (_internalStorage[i].Equals(item))// provjeri equals
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(X item)
        {
            for (int i = 0, len = _internalStorage.Length; i < len; i++)
            {
                if (_internalStorage[i].Equals(item))//equals
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
            _internalStorage[index] = default(X);
            for (int i = index + 1, len = current; i < len; i++)
            {
                _internalStorage[i - 1] = _internalStorage[i];
            }
            current--;
            _internalStorage[current] = default(X);
            return true;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
