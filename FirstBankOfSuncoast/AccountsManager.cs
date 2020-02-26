using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace FirstBankOfSuncoast
{
  public class AccountsManager
  {
    public List<Account> accounts { get; set; } = new List<Account>();

    public void LoadAccounts()
    {
      var reader = new StreamReader("accounts.csv");
      var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
      accounts = csvReader.GetRecords<Account>().ToList();
    }


    public void SaveAccounts()
    {
      var writer = new StreamWriter("accounts.csv");
      var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
      csvWriter.WriteRecords(accounts);
      writer.Flush();
    }


    public void DisplayAccounts()
    {
      foreach (var account in accounts)
      {
        Console.WriteLine($"You have {account.Amount} in you {account.AccountType} account");
      }
    }

    //deposit "add" funds
    public void Adding(string AccountType, double Amount)
    {
      var account = accounts.First(accounts => accounts.AccountType == AccountType).Amount;
      account += Amount;
      accounts.First(account => account.AccountType == AccountType).Amount = account;
    }

    //withdraw
    public void Withdraw(string AccountType, double Amount)
    {
      var account = accounts.First(accounts => accounts.AccountType == AccountType).Amount;
      account -= Amount;
      accounts.First(account => account.AccountType == AccountType).Amount = account;
    }

    /////////////////////////
    ////////////////////////
    //////////////////////////
    ////////////////////////
    //transfer
    // public void Transfer(string AccountType, double Amount)
    // {
    //   if (AccountType == "checking")
    //   {
    //     //error on
    //     var withdrawFrom = accounts.First(accounts => accounts.AccountType == AccountType).Amount;
    //     withdrawFrom -= Amount;
    //     accounts.First(accounts => accounts.AccountType == AccountType).Amount = withdrawFrom;
    //     var depositTo = accounts.First(accounts => accounts.AccountType == "checking").Amount;
    //     depositTo += Amount;
    //     accounts.First(accounts => accounts.AccountType == "checking").Amount = depositTo;
    //   }
    //   else if (AccountType == "saving")
    //   {
    //     var withdrawFrom = accounts.First(accounts => accounts.AccountType == AccountType).Amount;
    //     withdrawFrom -= Amount;
    //     accounts.First(accounts => accounts.AccountType == AccountType).Amount = withdrawFrom;
    //     var depositTo = accounts.First(accounts => accounts.AccountType == "saving").Amount;
    //     depositTo += Amount;
    //     accounts.First(accounts => accounts.AccountType == "saving").Amount = depositTo;
    //   }
    // }
  }
}