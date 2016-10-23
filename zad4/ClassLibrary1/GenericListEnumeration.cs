using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class GenericListEnumerator<T> : IEnumerator<T>
    {
        private GenericList<T> _list;
        private int position;
        private T element;

        public GenericListEnumerator(GenericList<T> list)
        {
            _list = list;
            position = -1;
            element = default(T);
        }

        public T Current
        {
            get
            {
                try
                {
                    return _list.GetElement(position);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public bool MoveNext()
        {
            if (++position >= _list.Count)
            {
                return false;
            }
            else
            {
                element = _list.GetElement(position);
            }
            return true;
        }

        public void Reset()
        {
            position = -1;
        }

        void IDisposable.Dispose() { }
    }
}
