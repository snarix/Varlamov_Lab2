using System;
using System.Data;

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

        public int Length { get; private set; }

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
            while (itemsLenght + Length >= tempCapacity)
            {
                tempCapacity *= 2;
            }
            return tempCapacity;
        }

        public void Add(T item)
        {
            Capacity = EnsureCapacity();
            _items[Length++] = item;
        }

        public void AddRange(T[] items)
        {
            Capacity = EnsureCapacity();
            Array.Copy(items, 0, _items, 0, items.Length);
        }

        public void Clear()
        {
            Capacity = _defaultCapacity;
            Length = 0;
            _items = new T[Capacity];

        }

        public DataTable ToDataTable()
        {
            var res = new DataTable();
            for (int i = 0; i < Length; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < Length; i++)
            {
                row[i] = _items[i];
            }
            res.Rows.Add(row);
            return res;
        }

    }
}
