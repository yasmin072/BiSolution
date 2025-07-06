namespace BIApplication.Core.models.orders;

public class OrderFlagByTerritory
{
    public string OnlineOrderFlag { get; set; }
    public string TerritoryName { get; set; }
    public Dictionary<string, decimal> LineTotalSumsByYear { get; set; } = new();
}