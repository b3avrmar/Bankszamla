using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankszamla
{
    internal class Program
    {

        static List<Account> accounts = new List<Account>();

        static void Main(string[] args)
        {
            LoadAccounts();

            bool running = true;

            while (running)
            {
                Console.Clear();
                ShowMenu();

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ShowAccounts();
                        break;

                    case "2":
                        MakeDeposit();
                        break;

                    case "3":
                        MakeWithdraw();
                        break;

                    case "4":
                        MakeTransfer();
                        break;

                    case "5":
                        SaveAllLogs();
                        Console.WriteLine("Naplók elmentve.");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Érvénytelen menüpont.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nyomj meg egy gombot a folytatáshoz...");
                    Console.ReadKey();
                }
            }
        }

        
    }
}
