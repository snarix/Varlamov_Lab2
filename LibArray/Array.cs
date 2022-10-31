using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Увеличение размера массива
        /// </summary>
        /// <param name="itemsLenght">Длина массива</param>
        /// <returns></returns>

        private int EnsureCapacity(int itemsLenght = 0)
        {
            int tempCapacity = Capacity;
            while (itemsLenght + Length >= tempCapacity)
            {
                tempCapacity *= 2;
            }
            return tempCapacity;
        }

        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="item">Элемент для добавления</param>

        public void Add(T item)
        {
            Capacity = EnsureCapacity();
            _items[Length++] = item;
        }

        /// <summary>
        /// Добавление массива уже к существующему
        /// </summary>
        /// <param name="items">Массив для добавления</param>

        public void AddRange(T[] items)
        {
            Capacity = EnsureCapacity(items.Length);
            Array.Copy(items, 0, _items, Length, items.Length);
            Length += items.Length;
        }

        /// <summary>
        /// Очищение 
        /// </summary>

        public void Clear()
        {
            Capacity = _defaultCapacity;
            Length = 0;
            _items = new T[Capacity];
        }

        /// <summary>
        /// Вывод массива на экран
        /// </summary>
        /// <returns></returns>

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

        /// <summary>
        /// Очищение выбранного элемента
        /// </summary>
        /// <param name="item">Удаляющийся элемент</param>
        /// <returns></returns>

        public bool Remove(T item)
        {
            int x = Array.IndexOf(_items, item);

            if (x >= 0)
            {
                Array.Copy(_items, x + 1, _items, x, Capacity - (x + 1));
                Capacity--;
                Length--;
                return true;
            }
            return false;
        }
    }
}
