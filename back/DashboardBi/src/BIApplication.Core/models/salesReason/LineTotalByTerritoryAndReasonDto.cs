namespace BIApplication.Core.models.salesReason;

public class LineTotalByTerritoryAndReasonDto
{
    public string TerritoryName { get; set; }
    public string SalesReasonName { get; set; }
    public Dictionary<string, decimal> LineTotalSumsByYear { get; set; } = new();
}