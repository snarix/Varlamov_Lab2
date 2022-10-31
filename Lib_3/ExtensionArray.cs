using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using LibArray;

namespace Lib_3
{
    public static class ExtensionArray
    {
        /// <summary>
        /// Инициализация массива
        /// </summary>
        /// <param name="numbers">Массив</param>
        public static void ArrayCreate(this Array<int> numbers)
        {
            Random rnd = new();
            for (int i = 0; i < numbers.Capacity; i++)
            {
                numbers.Add(rnd.Next(1, 100));
            }
        }

        /// <summary>
        /// Расчёт над созданным массивом
        /// </summary>
        /// <param name="numbers">Массив</param>
        /// <returns></returns>

        public static int ArrayDifference(this Array<int> numbers)
        {
            int diff = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                diff -= numbers[i];
            }
            return diff;
        }
    }
}