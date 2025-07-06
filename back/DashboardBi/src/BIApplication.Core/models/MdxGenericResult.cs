namespace BIApplication.Core.models;

public class MdxGenericResult
{
    public string Label { get; set; } = string.Empty; // Peut être SalesReasonName, Category, TerritoryName
    public decimal TotalLine { get; set; }
}