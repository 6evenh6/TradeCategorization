using System;
using Xunit;
using TradeCategorization.Models;

public class TradeClassifierTests
{
    private readonly DateTime _referenceDate = new DateTime(2020, 12, 11);

    [Fact]
    public void ClassifyTrade_WhenTradeIsExpired_ReturnsExpired()
    {
        // Arrange
        var trade = new Trade(500000, "Private", new DateTime(2020, 10, 01)); // Data de pagamento antiga
        var classifier = new TradeClassifier(_referenceDate);

        // Act
        var result = classifier.ClassifyTrade(trade);

        // Assert
        Assert.Equal("EXPIRED", result);
    }

    [Fact]
    public void ClassifyTrade_WhenTradeIsHighRisk_ReturnsHighRisk()
    {
        // Arrange
        var trade = new Trade(1500000, "Private", new DateTime(2025, 01, 01)); // Valor > 1 milhão, setor privado
        var classifier = new TradeClassifier(_referenceDate);

        // Act
        var result = classifier.ClassifyTrade(trade);

        // Assert
        Assert.Equal("HIGHRISK", result);
    }

    [Fact]
    public void ClassifyTrade_WhenTradeIsMediumRisk_ReturnsMediumRisk()
    {
        // Arrange
        var trade = new Trade(2000000, "Public", new DateTime(2025, 01, 01)); // Valor > 1 milhão, setor público
        var classifier = new TradeClassifier(_referenceDate);

        // Act
        var result = classifier.ClassifyTrade(trade);

        // Assert
        Assert.Equal("MEDIUMRISK", result);
    }

    [Fact]
    public void ClassifyTrade_WhenTradeIsNormal_ReturnsNormal()
    {
        // Arrange
        var trade = new Trade(500000, "Public", new DateTime(2025, 01, 01)); // Valor < 1 milhão, setor público
        var classifier = new TradeClassifier(_referenceDate);

        // Act
        var result = classifier.ClassifyTrade(trade);

        // Assert
        Assert.Equal("NORMAL", result);
    }
}
