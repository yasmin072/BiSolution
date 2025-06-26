namespace BIApplication.Core.models.salesReason;

public class LineTotalByCategoryAndReasonDto
{
    public string CategoryName { get; set; }
    public string SalesReasonName { get; set; }
    public Dictionary<string, decimal> LineTotalSumsByYear { get; set; } = new();

}