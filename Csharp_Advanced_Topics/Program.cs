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

        private static void ReflectionSamples() 
        {
            //Reflection1();
            //Reflection2();
            //Reflection3();
            //Reflection4();
            //Reflection5();

            /* Reflection - Inspection */
            //Reflection6();

            /* Reflection - Construction */
            //Reflection7();
            //Reflection8();
            Reflection9();
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

            // Get the nonpublic methods
            MethodInfo[] methodInfoPrivate = t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance |
                BindingFlags.DeclaredOnly);

            Console.WriteLine("\nThe number of private methods is {0}", methodInfoPrivate.Length);

            // display all the methods
            DisplayMethodInfo(methodInfoPrivate);


        }

        private static void Reflection2() 
        {
            Type t = "Hello".GetType();
            Console.WriteLine(t.FullName);
            FieldInfo[] fieldInfo = t.GetFields();

            for (int i = 0; i < fieldInfo.Length; i++)
            {
                Console.WriteLine(fieldInfo[i]);
            }
        }

        private static void Reflection3() 
        {
            var a = typeof(string).Assembly;
            var types = a.GetTypes();
            Console.WriteLine(types);            
        }

        private static void Reflection4() 
        {
            var t = Type.GetType("System.Int64");
            Console.WriteLine(t.FullName);
            Console.WriteLine(t.GetMethods());
        }

        private static void Reflection5() 
        {
            // back tick 1 - for generic list
            //var t = Type.GetType("System.Collections.Generic.List`1");

            // back tick 2 - for dictionaries
            var t = Type.GetType("System.Collections.Generic.Dictionary`2");
            Console.WriteLine(t.GetMethods());
        }

        private static void Reflection6() 
        {
            var t = typeof(Guid);
            Console.WriteLine(t.Name);

            var ctors = t.GetConstructors();
            Console.WriteLine(ctors);

            foreach (var item in ctors)
            {
                Console.WriteLine(item);
                var pars = item.GetParameters();
                for (var i = 0; i < pars.Length; i++)
                {
                    var par = pars[i];
                    Console.WriteLine($"--{par.ParameterType.Name} {par.Name} ");
                }
            }

            
        }

        private static void Reflection7() 
        {
            var t = typeof(bool);
            var b = Activator.CreateInstance(t);
            var b2 = Activator.CreateInstance<bool>();

            var wc = Activator.CreateInstance("System", "System.Timers.Timer");
            Console.WriteLine(wc);

            Console.WriteLine(wc.Unwrap());

        }

        private static void Reflection8() 
        {
            var alType = Type.GetType("System.Collections.ArrayList");
            Console.WriteLine(alType);

            //get default constructor
            var alCtor = alType.GetConstructor(Array.Empty<Type>());
            Console.WriteLine(alCtor);

            //make an instance of the arraylist
            var al = alCtor.Invoke(Array.Empty<object>());
            Console.WriteLine(al);
        }

        private static void Reflection9() 
        {
            var st = typeof(string);
            var ctor = st.GetConstructor(new[] { typeof(char[]) });
            var str = ctor.Invoke(new object[] 
            { 
                new []{'t', 'e', 's', 't'}
            });

            Console.WriteLine(str);
        }

        private static void DisplayMethodInfo(MethodInfo[] methodInfo) 
        {
            for (int i = 0; i < methodInfo.Length; i++)
            {
                MethodInfo info = (MethodInfo)methodInfo[i];
                Console.WriteLine("\nThe name of the method is {0}", methodInfo[i]);

            }
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
