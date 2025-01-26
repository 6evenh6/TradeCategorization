using TradeCategorization.Models;

public class TradeClassifier
{
    private DateTime _referenceDate;

    public TradeClassifier(DateTime referenceDate)
    {
        _referenceDate = referenceDate;
    }

    public string ClassifyTrade(ITrade trade)
    {
        if (IsExpired(trade))
        {
            return "EXPIRED";
        }

        if (IsHighRisk(trade))
        {
            return "HIGHRISK";
        }

        if (IsMediumRisk(trade))
        {
            return "MEDIUMRISK";
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
}
