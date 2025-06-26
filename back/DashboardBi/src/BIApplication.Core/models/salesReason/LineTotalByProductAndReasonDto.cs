namespace BIApplication.Core.models.salesReason;

public class LineTotalByProductAndReasonDto
{
    public string ProductName { get; set; }
    public string SalesReasonName { get; set; }
    public Dictionary<string, decimal> LineTotalSumsByYear { get; set; } = new();
}