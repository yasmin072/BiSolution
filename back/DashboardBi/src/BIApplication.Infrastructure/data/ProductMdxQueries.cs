namespace BIApplication.Infrastructure.Data;

public class ProductMdxQueries
{
    public static string GetTotalProductShipped = @"
      select 
     [Measures].[Product ID Distinct Count] on columns ,
     non empty (
     [Dim Status].[Status ID].[Status ID].members 
     ) on rows 
    from [CubeExamenFinal]";


    public static string GetTop3ProdTotalDue = @"SELECT 
       [Measures].[Total Due] ON COLUMNS,
        TopCount(
            Filter(
                NonEmpty([Product1].[Product ID].[Product ID]),
                [Product1].[Product ID].CurrentMember.Member_Caption <> ""Unknown""
            ),
            3       
        ) ON ROWS
    FROM [CubeExamenFinal]";

    public static string GetTop3ProdTotalLine = @"
        SELECT 
           [Measures].[Line Total] ON COLUMNS,
            TopCount(
                Filter(
                    NonEmpty([Product1].[Product ID].[Product ID].MEMBERS),
                    [Product1].[Product ID].CurrentMember.Member_Caption <> ""Unknown""
                ),
                3        
            ) ON ROWS
        FROM [CubeExamenFinal]";

    public static string GetTotalProduct = @"   SELECT  
       [Measures].[Product ID Distinct Count] as [nbProduct] ON COLUMNS
       FROM [CubeExamenFinal]";
}

