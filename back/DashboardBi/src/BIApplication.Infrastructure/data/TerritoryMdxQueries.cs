namespace BIApplication.Infrastructure.Data;

public class TerritoryMdxQueries
{
   public static string GetTotalTerritoriesAsync = @"
     SELECT [Measures].[Nbre de territoires] ON COLUMNS
    FROM [CubeExamenFinal]";


    //total vente %territory%order placed by customer
    public static string GetTotalventeByTerrPlacedByCustomerAsync = @"
            SELECT 
            [Measures].[Line Total - Sum] ON COLUMNS,
            NON EMPTY 
            ORDER(
                [Territory].[Name].[Name].Members,
                [Measures].[Line Total - Sum],
                BDESC
            ) ON ROWS
        FROM [CubeExamenFinal]
        WHERE [Dim Online Order Flag].[Online Order Flag ID].&[True]";

    public static string TotalLineByTerritory = @" 
        SELECT 
            non empty 
             {
	        [Territory].[Name].[Name].Members
	        } as [TerritoryName] on rows,
            [Measures].[Line Total] as [LineTotal]on columns
        FROM [CubeExamenFinal]";


    /*  public static string GetTotalVenteByTerritoryGroupAsync = @"
          WITH
              MEMBER [Measures].[TerritoryGroupName] AS [Territory].[Group].CurrentMember.Name
          SELECT
              {[Measures].[TerritoryGroupName], [Measures].[Line Total - Sum]} ON COLUMNS,
              NON EMPTY [Territory].[Group].[Group].Members ON ROWS
          FROM [SalesCube]";*/
}