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
        non empty 
		{([Measures].[Sales Order ID Distinct Count] ,
        [Dim Date].[Year].[Year].members							 
		),
		([Measures].[Sales Order ID Distinct Count] ,
        [Dim Date].[Year].[ALL]							 
		)
		}
		ON COLUMNS,
        NON EMPTY
            [Territory].[Name].[Name] *
            [Dim Online Order Flag].[Online Order Flag ID].[Online Order Flag ID]
        ON ROWS
    FROM [CubeExamenFinal]";
}