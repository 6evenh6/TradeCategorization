using TradeCategorization.Models;

public class TradeClassifier
{
    private DateTime _referenceDate;
    private readonly Dictionary<string, Func<ITrade, bool>> _categoryRules;

    public TradeClassifier(DateTime referenceDate)
    {
        _referenceDate = referenceDate;

        _categoryRules = new Dictionary<string, Func<ITrade, bool>>
        {
            { "EXPIRED", IsExpired },
            { "HIGHRISK", IsHighRisk },
            { "MEDIUMRISK", IsMediumRisk },
            { "PEP", IsPEP }
        };
    }

    public string ClassifyTrade(ITrade trade)
    {
        foreach (var category in _categoryRules)
        {
            if (category.Value(trade))
            {
                return category.Key;
            }
        }

        return "NORMAL";
    }

    private bool IsExpired(ITrade trade)
    {
        return (trade.NextPaymentDate < _referenceDate.AddDays(-30));
    }

    private bool IsHighRisk(ITrade trade)
    {
        return trade.Value > 1000000 && trade.ClientSector == "Private";
    }

    private bool IsMediumRisk(ITrade trade)
    {
        return trade.Value > 1000000 && trade.ClientSector == "Public";
    }
    private bool IsPEP(ITrade trade)
    {
        return trade.IsPoliticallyExposed;
    }
}
