namespace BIApplication.Core.models.product;

public class TotalDueByMonth
{
    public string TerritoryName { get; set; }
  //  public string Month { get; set; }
  //  public decimal TotalDue { get; set; }
  public Dictionary<string, decimal> TotalDueByMonthDict { get; set; } = new();

}