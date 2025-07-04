namespace BIApplication.Infrastructure.Data;

public class MdxQueries
{
    // Ajoute d'autres requêtes ici (e.g., pour TotLineSubCatSalesReason)
    public static string GetSalesByBikesAsync = @"
     SELECT [Measures].[Line Total] as [totalline] ON COLUMNS,
      non empty EXCEPT (
	  [Product1].[Product Category ID].MEMBERS AS [categoryName],
	  [Product1].[Product Category ID].[All]
	  )ON ROWS
      FROM  [CubeExamenFinal]";


    public static string totalDueYear = @"
        SELECT 
      NON EMPTY 
        [Dim Date].[Year].[Year].Members * {[Measures].[Total Due]} ON COLUMNS,
      NON EMPTY 
        [Territory].[Name].[Name].Members ON ROWS
    FROM [CubeExamenFinal]";

    public static string totalDueMonth = @"
    SELECT 
      NON EMPTY 
        [Dim Date].[Month Name].[Month Name].Members * {[Measures].[Total Due]} ON COLUMNS,
      NON EMPTY 
        [Territory].[Name].[Name].Members ON ROWS
    FROM [CubeExamenFinal]";
    
    public static string GetTotalClients = @"
        select [Measures].[Customers] on columns 
        from [CubeExamenFinal]";
   
}