using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Lib_3
{
    public class ExtensionArray
    {
        public static int[] ArrayCreate(int count, int min, int max)
        {
            int[] mas = new int[count];
            Random rnd = new();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(min, max);
            }
            return mas;
        }

    }
}
