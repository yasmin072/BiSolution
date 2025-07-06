namespace BIApplication.Infrastructure.Data;

public class OrdersMdxQueries
{
    public static string OrderCount =@"
        SELECT  [Measures].[Sales Order ID Distinct Count] as [TotalOrder] 
                                  ON COLUMNS 
                                  FROM [CubeExamenFinal]";
    
    public static string OrderFlagMdx = @"
        SELECT 
            [Measures].[Order Qty] ON COLUMNS,
            NON EMPTY [Dim Online Order Flag].[Online Order Flag ID].[Online Order Flag ID].MEMBERS ON ROWS  
        FROM [CubeExamenFinal]";

    public static string OrdersFlagByTerritoryY = @" 
      SELECT
      NON EMPTY {
        ([Measures].[Sales Order ID Distinct Count], [Dim Date].[Year].[Year].Members),
        ([Measures].[Sales Order ID Distinct Count], [Dim Date].[Year].[All])
      } ON COLUMNS,
      NON EMPTY
        [Territory].[Name].[Name].Members *
        FILTER(
            [Dim Online Order Flag].[Online Order Flag ID].[Online Order Flag ID].Members,
            NOT [Dim Online Order Flag].[Online Order Flag ID].CurrentMember IS [Dim Online Order Flag].[Online Order Flag ID].[Unknown]
        )
      ON ROWS
    FROM [CubeExamenFinal]";
}