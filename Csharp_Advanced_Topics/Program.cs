using System.Linq;
using System.Numerics;
using System.Windows;
using System;
using System.Reflection;

namespace Csharp_Advanced_Topics
{
    class Program
    {
        static void Main(string[] args)
        {
            //VectorSamples();
            ReflectionSamples();
        }

        private static void VectorSamples() 
        {
            Vector1();
        }

        private static void ReflectionSamples() 
        {
            Reflection1();
        }

        private static void Reflection1() 
        {
            Type t = typeof(int);

            //Get the public methods
            MethodInfo[] methodInfoPublic = t.GetMethods(BindingFlags.Public | BindingFlags.Instance |
                BindingFlags.DeclaredOnly);
            Console.WriteLine("\nThe number of public methods is {0}", methodInfoPublic.Length);

            // Display all the methods
            DisplayMethodInfo(methodInfoPublic);



        }

        private static void DisplayMethodInfo(MethodInfo[] methodInfo) 
        {
            for (int i = 0; i < methodInfo.Length; i++)
            {
                MethodInfo info = (MethodInfo)methodInfo[i];
                Console.WriteLine("\nThe name of the method is {0}", methodInfo[i]);
            }
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
