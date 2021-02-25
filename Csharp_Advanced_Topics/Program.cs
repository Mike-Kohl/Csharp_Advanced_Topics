using System.Linq;
using System.Numerics;
using System.Windows;
using System;

namespace Csharp_Advanced_Topics
{
    class Program
    {
        static void Main(string[] args)
        {
            VectorSamples();
        }

        private static void VectorSamples() 
        {
            Vector1();
        }

        private static void Vector1() 
        {
            byte[] array1 = Enumerable.Range(1, 128)
                .Select(x => (byte)x).ToArray();
            byte[] array2 = Enumerable.Range(4, 128)
                .Select(x => (byte)x).ToArray();
            byte[] result = new byte[128];

            int size = Vector<byte>.Count;

            for (int i = 0; i < array1.Length; i += size)
            {
                var va = new Vector<byte>(array1, i);
                var vb = new Vector<byte>(array2, i);
                var vresult = va + vb;
                vresult.CopyTo(result, i);
            }

        
        }
    }
}
