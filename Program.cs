using System;

namespace GenerateTableConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("please create table,Ex: C [width] [height]");
            Console.WriteLine("This a true Command : C 20 4");
            Console.WriteLine("enter command:");
            TableModel table = new TableModel();
            UseTable useTable = new UseTable();

            // start create table
            while (true)
            {
                string s = Console.ReadLine();
                var re = useTable.RunCommand(s);
                if (re.Code == 200)
                {
                    Console.WriteLine(re.Result);
                    break;
                }
                else
                {
                    Console.WriteLine(re.Result);
                }
            }

            while (true)
            {
                useTable.ConsoleTable();
                Console.WriteLine("enter command:");
                string s = Console.ReadLine();
                if (s == "Q")
                {
                    break;
                }

                var re = useTable.RunCommand(s);
                if (re.Code == 200)
                {
                    Console.WriteLine(re.Result);
                }
                else
                {
                    Console.WriteLine(re.Result);
                }
            }
        }
    }
}
