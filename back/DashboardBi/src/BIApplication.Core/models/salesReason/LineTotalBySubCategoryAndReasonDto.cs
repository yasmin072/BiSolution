namespace BIApplication.Core.models.salesReason;

public class LineTotalBySubCategoryAndReasonDto
{
    public string SubCategoryName { get; set; }
    public string SalesReasonName { get; set; }
    public Dictionary<string, decimal> LineTotalSumsByYear { get; set; } = new();
}