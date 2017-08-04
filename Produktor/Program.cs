using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produktor {
    public static class Program {

        public static void Main(string[] args) {
            Base64Converter.Init();
            InputDuplicator.Init();



            UserInput.Run();
        }
    }

    public static class UserInput {
        public static event ExecuteCommand ExecuteCommandEvent;
        public delegate void ExecuteCommand(string s, EventArgs e);
        public static EventArgs e = null;
        public static void Run() {
            while (true) {
                Console.WriteLine("[=============== Commands ===============]");
                Console.WriteLine("[====     0: Exit                    ====]");
                Console.WriteLine("[====     1: File - To - Base64      ====]");
                Console.WriteLine("[====     2: Repeat input n times    ====]");
                Console.WriteLine("[========================================]");

                var command = Console.ReadLine();
                ExecuteCommandEvent(command, e);

                //switch (command) {
                //    case "0": return;
                //    case "1":
                //        var path = Console.ReadLine();
                //        File.WriteAllText(path + ".base64", Convert.ToBase64String(File.ReadAllBytes(path)));
                //        Console.WriteLine(path + ".base64");
                //        break;

                //    case "2":
                //        Console.WriteLine("Enter string to repat:");
                //        var input = Console.ReadLine();
                //        Console.WriteLine("How many times:");
                //        var repeat = int.Parse(Console.ReadLine());
                //        for (int i = 0; i < repeat; ++i)
                //            Console.WriteLine(input);
                //        break;
                //}
            }
        }
    }

    public static class Base64Converter {
        public static int CommandNo;
        public static string CommandName;
        public static void Init() {
            CommandNo = 1;
            CommandName = new System.Diagnostics.StackFrame().GetMethod().DeclaringType.ToString();
            UserInput.ExecuteCommandEvent += Check;
        }

        private static void Check(string v, EventArgs eventArgs) {
            if (!CommandName.ToLower().Contains(v.ToLower()) || v == CommandNo.ToString())
                return;
            Console.WriteLine("Enter path:");
            var path = Console.ReadLine();
            File.WriteAllText(path + ".base64", Convert.ToBase64String(File.ReadAllBytes(path)));
            Console.WriteLine(path + ".base64");
        }
    }

    public static class InputDuplicator {
        public static int CommandNo;
        public static string CommandName;
        public static void Init() {
            CommandNo = 1;
            CommandName = new System.Diagnostics.StackFrame().GetMethod().DeclaringType.ToString();
            UserInput.ExecuteCommandEvent += Check;
        }

        private static void Check(string v, EventArgs eventArgs) {
            if (!CommandName.ToLower().Contains(v.ToLower()) || v == CommandNo.ToString())
                return;
            Console.WriteLine("Enter path:");
            var path = Console.ReadLine();
            Console.WriteLine("How many times:");
            var howMuch = int.Parse(Console.ReadLine());
            var read = File.ReadAllText(path);
            var sb = new StringBuilder();
            for (int i = 0; i < howMuch; ++i)
                sb.Append(read);

            File.WriteAllText(path + ".duplicated" + howMuch, sb.ToString());
            Console.WriteLine(path + ".duplicted" + howMuch);
        }
    }
}
