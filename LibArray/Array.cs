using System;

namespace LibArray
{
    public class Array<T>
    {
        private T[] _items;
        private int _capacity;

        private readonly int _defaultCapacity = 8;

        public Array(int capacity)
        {
            _items = new T[capacity];
            Capacity = capacity;
        }

        public int Lenght { get; private set; }

        public T this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }

        public int Capacity
        {
            get => _capacity;
            private set
            {
                if (value == _capacity)
                {
                    return;
                }
                _capacity = value;
                Array.Resize(ref _items, value);
            }
        }

        private int EnsureCapacity(int itemsLenght = 0)
        {
            int tempCapacity = Capacity;
            while (itemsLenght + Lenght >= tempCapacity)
            {
                tempCapacity *= 2;
            }
            return tempCapacity;
        }

        public void Add(T item)
        {
            Capacity = EnsureCapacity();
            _items[Lenght++] = item;
        }

        public void AddRange(T[] item)
        {
            Capacity = EnsureCapacity();
            Array.Resize(ref _items, item.Length);
        }

        public void Clear()
        {
            Capacity = _defaultCapacity;
            Lenght = 0;
            _items = new T[Capacity];

        }

        public bool Remove(T item)
        {

        }
    }
}
