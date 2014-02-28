namespace InjectDLL
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Nouzuru;

    class Program
    {
        static void Main(string[] args)
        {
            DllInjector di = new DllInjector();

            if (args.Length != 2)
            {
                Console.WriteLine(
                    "usage: " + System.AppDomain.CurrentDomain.FriendlyName +
                    " <process_image_name> <absolute_dll_path>");
                return;
            }

            bool passedTests = true;
            string procName = args[0];
            string dllPath = args[1];

            if (!di.Open(procName))
            {
                Console.WriteLine(
                    procName +
                    " could not be opened. Verify that it is currently running and that you have the correct " +
                    "permissions to open the process.");
                passedTests = false;
            }

            if (!File.Exists(dllPath))
            {
                Console.WriteLine("The supplied DLL path does not exist.");
                passedTests = false;
            }

            if (passedTests)
            {
                di.InjectDll(dllPath);
            }
        }
    }
}
