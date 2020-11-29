using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JxCode.Windows;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Hook h = new Hook();
            h.keyMsg += H_keyMsg;
            h.Start();
            Console.ReadKey();
            Console.ReadKey();
            h.Dispose();
        }

        private static void H_keyMsg(JxCode.Windows.Native.Keys obj)
        {
            Console.WriteLine("js");
            Console.WriteLine(obj);
        }
    }
}
