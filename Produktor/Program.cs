using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produktor {
    class Program {
        static void Main(string[] args) {
            
            while(true) {
                Console.WriteLine("[=============== Commands ===============]");
                Console.WriteLine("[====     0: Exit                    ====]");
                Console.WriteLine("[====     1: File - To - Base64      ====]");
                Console.WriteLine("[====     2: Repeat input n times      ====]");
                Console.WriteLine("[========================================]");

                var command = Console.ReadLine();

                switch(command) {
                    case "0": return;
                    case "1":
                        var path = Console.ReadLine();
                        File.WriteAllText(path + ".base64", Convert.ToBase64String(File.ReadAllBytes(path)));
                        Console.WriteLine(path + ".base64");
                        break;

                    case "2":
                        Console.WriteLine("Enter string to repat:");
                        var input = Console.ReadLine();
                        Console.WriteLine("How many times:");
                        var repeat = int.Parse(Console.ReadLine());
                        for (int i = 0; i < repeat; ++i)
                            Console.WriteLine(input);
                        break;
                }
            }
        }
    }
}
