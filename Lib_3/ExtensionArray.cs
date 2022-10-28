using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using LibArray;

namespace Lib_3
{
    public static class ExtensionArray
    {
        public static void ArrayCreate(this Array<int> numbers)
        {
            Random rnd = new();
            for (int i = 0; i < numbers.Capacity; i++)
            {
                numbers.Add(rnd.Next(1, 100));
            }
        }
    }
}
