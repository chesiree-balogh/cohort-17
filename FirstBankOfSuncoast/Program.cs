using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace FirstBankOfSuncoast
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to First Bank of Suncoast");

      var accountsManager = new AccountsManager();
      accountsManager.LoadAccounts();

      var isRunning = true;
      while (isRunning)
      {

        Console.WriteLine("=======================================");

        var accounts = new List<Account>();
        accounts.Add(new Account { AccountType = "Checking", Amount = 0 });
        accounts.Add(new Account { AccountType = "Saving", Amount = 0 });
        accountsManager.DisplayAccounts();

        Console.WriteLine("What would you like to do? (A)dd funds, (W)ithdrawl funds, (T)ransfer funds, or (Q)iut?");
        var input = Console.ReadLine().ToLower();

        if (input == "a")
        {
          Console.WriteLine("which account would you like to add to? (C)hecking or (S)aving");
          var add = Console.ReadLine().ToLower();
          if (add == "c")
          {
            Console.WriteLine("how much?");
            var deposit = double.Parse(Console.ReadLine());
            accountsManager.Adding("Checking", deposit);
          }
          else if (add == "s")
          {
            Console.WriteLine("how much?");
            var deposit = double.Parse(Console.ReadLine());
            accountsManager.Adding("Saving", deposit);
          }
        }

        else if (input == "w")
        {
          Console.WriteLine("which account would you like to withdrawl from? (C)hecking or (S)aving");
          var withdrawl = Console.ReadLine().ToLower();
          if (withdrawl == "c")
          {
            Console.WriteLine("how much?");
            var withdrawlFunds = double.Parse(Console.ReadLine());
            accountsManager.Withdraw("Checking", withdrawlFunds);
          }
          else if (withdrawl == "s")
          {
            Console.WriteLine("how much?");
            var withdrawlFunds = double.Parse(Console.ReadLine());
            accountsManager.Withdraw("Saving", withdrawlFunds);
          }
        }

        /////////////////////////
        /////////////////////////
        /////////////////////////

        //transfer
        else if (input == "t")
        {
          Console.WriteLine("which account would you like to transfer from? (Checking) or (Saving)");
          var transfer = Console.ReadLine().ToLower();
          if (transfer == "checking")
          {
            Console.WriteLine("how much?");
            var transChecking = double.Parse(Console.ReadLine());
            accountsManager.Adding("Saving", transChecking);
            accountsManager.Withdraw("Checking", transChecking);
            //accountsManager.Transfer("Checking", transChecking);
          }
          //error on line 80

          else if (transfer == "saving")
          {
            Console.WriteLine("how much?");
            var transSaving = double.Parse(Console.ReadLine());
            accountsManager.Adding("Checking", transSaving);
            accountsManager.Withdraw("Saving", transSaving);
            //accountsManager.Transfer("Saving", transSaving);
          }
        }

        //quit
        else if (input == "q")
        {
          isRunning = false;
        }
      }
      accountsManager.SaveAccounts();
    }
  }
}