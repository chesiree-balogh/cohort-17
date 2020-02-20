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



    static void SaveAccounts(List<Account> accounts)
    {
      var writer = new StreamWriter("accounts.csv");
      var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
      csvWriter.WriteRecords(accounts);
      writer.Flush();
    }

    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to First Bank of Suncoast");

      var accounts = new List<Account>();

      var reader = new StreamReader("accounts.csv");
      var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
      accounts = csvReader.GetRecords<Account>().ToList();


      var isRunning = true;
      while (isRunning)
      {
        //display current account balances
        foreach (var Account in accounts)
        {
          Console.WriteLine($"Your current Checking balance is:{Account.Checking}");
          Console.WriteLine($"& your current Savings balance is:{Account.Saving}");
        }



        Console.WriteLine("What would you like to do? (A)dd funds, (W)ithdrawl funds, (T)ransfer funds, or (Q)iut?");
        var input = Console.ReadLine().ToLower();
        if (input == "a")
        {
          Console.WriteLine("which account would you like to add to? (C)hecking or (S)aving");
          var add = Console.ReadLine().ToLower();
          if (add == "c")
          {

          }
          else if (add == "s")
          {

          }
        }


        else if (input == "w")
        {
          Console.WriteLine("which account would you like to withdrawl from? (C)hecking or (S)aving");
          var withdrawl = Console.ReadLine().ToLower();
          if (withdrawl == "c")
          {

          }
          else if (withdrawl == "s")
          {

          }
        }


        else if (input == "t")
        {
          Console.WriteLine("which account would you like to transfer to? (C)hecking or (S)aving");
          var transfer = Console.ReadLine().ToLower();
          if (transfer == "c")
          {

          }
          else if (transfer == "s")
          {

          }
        }

        else if (input == "q")
        {
          isRunning = false;
        }



      }

    }
  }
}
