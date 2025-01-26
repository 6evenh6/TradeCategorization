using System;
using System.Globalization;
using System.Collections.Generic;
using TradeCategorization.Models;

public class Program
{
    public static void Main()
    {
        var referenceDate = GetReferenceDateFromInput();
        var trades = GetTradesFromInput();

        var classifier = new TradeClassifier(referenceDate);

        foreach (var trade in trades)
        {
            string category = classifier.ClassifyTrade(trade);
            Console.WriteLine(category);
        }
    }

    public static DateTime GetReferenceDateFromInput()
    {
        string referenceDateInput = Console.ReadLine();
        return DateTime.ParseExact(referenceDateInput, "MM/dd/yyyy", CultureInfo.InvariantCulture);
    }

    public static List<ITrade> GetTradesFromInput()
    {
        int n = int.Parse(Console.ReadLine());
        var trades = new List<ITrade>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            double value = double.Parse(input[0]);
            string sector = input[1];
            DateTime paymentDate = DateTime.ParseExact(input[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);
            trades.Add(new Trade(value, sector, paymentDate));
        }
        return trades;
    }
}
