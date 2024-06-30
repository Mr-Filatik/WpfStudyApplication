using System.Collections;

namespace Other
{
    public class CustomList<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
    {
        #region Private variables

        private T[] _array;
        private int _lenght;

        #endregion

        #region Properties and Indexer

        public int Capacity => _array.Length;

        public int Lenght => _lenght;

        public T this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        #endregion

        #region Constructors

        public CustomList() : this(4) { }

        public CustomList(int capacity)
        {
            _array = new T[capacity];
            _lenght = 0;
        }

        #endregion

        #region Public Methods

        public void Add(T item)
        {
            if (_lenght == Capacity)
            {
                LenghtIncrease();
            }
            _array[_lenght] = item;
            _lenght++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            var count = collection.Count();
            if (_lenght + count > Capacity)
            {
                LenghtIncrease(count);
            }
            foreach (var item in collection)
            {
                _array[_lenght] = item;
                _lenght++;
            }
        }

        public void Insert(int index, T item)
        {
            if (_lenght == Capacity) //Lenght + 1 > Capacity
            {
                LenghtIncrease();
            }
            var currentArray = _array;
            _array = new T[Capacity];
            var addIndex = 0;
            for (int i = 0; i < _lenght; i++)
            {
                if (i == index)
                {
                    _array[i + addIndex] = item;
                    addIndex = 1;
                }
                _array[i + addIndex] = currentArray[i];
            }
            _lenght++;
        }

        public bool Remove(T item)
        {
            var addIndex = 0;
            var output = false;
            for (int i = 0; i < _lenght; i++)
            {
                _array[i - addIndex] = _array[i];
                if (_array[i - addIndex].Equals(item)) // == don't work with generics
                {
                    addIndex = 1;
                    output = true;
                }
            }
            _lenght--;
            return output;
        }

        public bool RemoveAt(int index)
        {
            var addIndex = 0;
            var output = false;
            for (int i = 0; i < _lenght; i++)
            {
                _array[i - addIndex] = _array[i];
                if (i == index)
                {
                    addIndex = 1;
                    output = true;
                }
            }
            _lenght--;
            return output;
        }

        #endregion

        #region Private Methods

        private void LenghtIncrease()
        {
            var currentArray = _array;
            int newCapacity = Capacity * 2;
            _array = new T[newCapacity];
            for (int i = 0; i < currentArray.Length; i++)
            {
                _array[i] = currentArray[i];
            }
        }

        private void LenghtIncrease(int count)
        {
            var currentArray = _array;
            int newCapacity = Capacity * 2;
            while (_lenght + count > newCapacity)
            {
                newCapacity *= 2;
            }
            _array = new T[newCapacity];
            for (int i = 0; i < currentArray.Length; i++)
            {
                _array[i] = currentArray[i];
            }
        }

        #endregion

        #region IEnumerator and IEnumerable

        private int _indexEnumerable = -1;

        public T Current => _array[_indexEnumerable];

        object IEnumerator.Current => _array[_indexEnumerable];

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_indexEnumerable + 1 < _lenght)
            {
                _indexEnumerable++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _indexEnumerable = -1;
        }

        public void Dispose()
        {
            Reset();
            //+ some code
        }

        #endregion
    }

    public static class CustomListExtention
    {
        public static T[] ToArray<T>(this CustomList<T> customList)
        {
            var array = new T[customList.Lenght];
            for (int i = 0; i < customList.Lenght; i++)
            {
                array[i] = customList[i];
            }
            return array;
        }

        public static List<T> ToList<T>(this CustomList<T> customList)
        {
            var list = new List<T>();
            for (int i = 0; i < customList.Lenght; i++)
            {
                list.Add(customList[i]);
            }
            return list;
        }
    }
}
