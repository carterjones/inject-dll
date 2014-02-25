namespace InjectDLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Nouzuru;

    class Program
    {
        static void Main(string[] args)
        {
            DllInjector di = new DllInjector();
            di.Open("calc");
            string dllPath = @"..\hello-world-dll\hello-world-dll\x86-64\hello-world.dll";
            di.InjectDll(dllPath);
            Console.ReadKey();
        }
    }
}
