using System;
using System.Collections.Generic;
using System.IO;

class Account
{
    private string accountNumber;
    private string ownerName;
    private decimal balance;
    private decimal creditLimit;
    private List<string> logs;

    public Account(string accountNumber, string ownerName, decimal openingBalance)
    {
        this.accountNumber = accountNumber;
        this.ownerName = ownerName;
        this.balance = openingBalance;
        this.creditLimit = openingBalance * 0.2m;
        logs = new List<string>();
    }

    public string GetAccountNumber()
    {
        return accountNumber;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            logs.Add($"{DateTime.Now};Befizetés;{amount};{balance}");
        }
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > 0 && balance - amount >= -creditLimit)
        {
            balance -= amount;
            logs.Add($"{DateTime.Now};Kifizetés;{amount};{balance}");
            return true;
        }
        return false;
    }

    public bool Transfer(Account targetAccount, decimal amount)
    {
        if (Withdraw(amount))
        {
            targetAccount.Deposit(amount);
            logs.Add($"{DateTime.Now};Utalás;{amount};{balance}");
            return true;
        }
        return false;
    }

    public void SaveLogToFile()
    {
        string folder = "logs";

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        string path = Path.Combine(folder, accountNumber + ".txt");
        File.WriteAllLines(path, logs);
    }

    public override string ToString()
    {
        return $"{accountNumber} - {ownerName} - Egyenleg: {balance} Ft";
    }
}