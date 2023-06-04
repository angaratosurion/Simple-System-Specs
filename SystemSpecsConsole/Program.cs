using SimpleSystemSpecs.Core;
using System;

namespace SystemSpecsConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select a Command to do");
            Console.WriteLine("1:save Specs to a file");
            Console.WriteLine("2: loadSpecs From a File");
           string ans=Console.ReadLine();
            int ch=int.Parse(ans);
            switch(ch)
            {
                case 1:
                    {
                        SystemSpecsManager manager = new SystemSpecsManager();
                        Console.WriteLine("Type a Filename");
                        string filename=Console.ReadLine();
                        manager.SaveSpecs(filename);
                        
                        break;
                    }
            }
        }
    }
}
