using System;
using System.Collections.Generic;
using System.IO;
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

        static void ShowMenu()
        {
            Console.WriteLine("===== BANK DASHBOARD =====");
            Console.WriteLine("1 - Számlák listázása");
            Console.WriteLine("2 - Befizetés");
            Console.WriteLine("3 - Kifizetés");
            Console.WriteLine("4 - Utalás");
            Console.WriteLine("5 - Kilépés");
            Console.Write("Választás: ");
        }

        static void LoadAccounts()
        {
            string[] lines = File.ReadAllLines("szamlak.txt");

            foreach (string line in lines)
            {
                string[] data = line.Split(';');

                string accountNumber = data[0];
                string ownerName = data[1];
                decimal balance = decimal.Parse(data[2]);

                Account account = new Account(accountNumber, ownerName, balance);
                accounts.Add(account);
            }
        }

        static Account FindAccount(string accountNumber)
        {
            foreach (Account account in accounts)
            {
                if (account.GetAccountNumber() == accountNumber)
                {
                    return account;
                }
            }
            return null;
        }

        static void ShowAccounts()
        {
            Console.WriteLine("===== SZÁMLÁK =====");

            foreach (Account account in accounts)
            {
                Console.WriteLine(account);
            }
        }

       
    }
}
