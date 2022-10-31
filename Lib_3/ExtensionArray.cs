using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using LibArray;

namespace Lib_3
{
    public static class ExtensionArray
    {
        /// <summary>
        /// ������������� �������
        /// </summary>
        /// <param name="numbers">������</param>
        public static void ArrayCreate(this Array<int> numbers)
        {
            Random rnd = new();
            for (int i = 0; i < numbers.Capacity; i++)
            {
                numbers.Add(rnd.Next(1, 100));
            }
        }

        /// <summary>
        /// ������ ��� ��������� ��������
        /// </summary>
        /// <param name="numbers">������</param>
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