using System;
using System.Globalization;
using TradeCategorization.Models;

class Program
{
    static void Main()
    {
        // Entrada de dados
        string referenceDateInput = Console.ReadLine();
        DateTime referenceDate = DateTime.ParseExact(referenceDateInput, "MM/dd/yyyy", CultureInfo.InvariantCulture);

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

        var classifier = new TradeClassifier(referenceDate);

        foreach (var trade in trades)
        {
            string category = classifier.ClassifyTrade(trade);
            Console.WriteLine(category);
        }
    }
}
