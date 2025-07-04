namespace BIApplication.Core.models.product;

public class QtyOrderByYearMonth
{
    public decimal OrderQty { get; set; }
    public string ProductCategoryID { get; set; }

    public string Year { get; set; }
    public string Month { get; set; }
}