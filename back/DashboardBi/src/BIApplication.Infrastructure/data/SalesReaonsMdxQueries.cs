namespace BIApplication.Infrastructure.Data;

public class SalesReaonsMdxQueries
{
    public static string GetLineTotalByCategoryAndReason = @"
        SELECT 
          NON EMPTY {
            ([Measures].[Line Total], [Dim Date].[Year].[Year].Members),
            ([Measures].[Line Total], [Dim Date].[Year].[All])
          } ON COLUMNS,
          NON EMPTY 
            FILTER(
              CROSSJOIN(
                [Product1].[Product Category ID].[Product Category ID].Members,
                [Sales Reason].[Name].[Name].Members
              ),
              NOT [Sales Reason].[Name].CurrentMember IS [Sales Reason].[Name].[Unknown]
            ) ON ROWS
        FROM [CubeExamenFinal]";
    
    public static string GetLineTotalBySubCategoryAndReason = @"
          SELECT 
            NON EMPTY {
              ([Measures].[Line Total], [Dim Date].[Year].[Year].Members),
              ([Measures].[Line Total], [Dim Date].[Year].[All])
            } ON COLUMNS,
            NON EMPTY 
              FILTER(
                CROSSJOIN(
                  [Product1].[Product Subcategory ID].[Product Subcategory ID].Members,
                  [Sales Reason].[Name].[Name].Members
                ),
               NOT [Sales Reason].[Name].CurrentMember  IS [Sales Reason].[Name].[Unknown]
              ) ON ROWS
          FROM [CubeExamenFinal]";
    
    public static string GetLineTotalByProductAndReason = @"
      SELECT 
        NON EMPTY {
          ([Measures].[Line Total], [Dim Date].[Year].[Year].Members),
          ([Measures].[Line Total], [Dim Date].[Year].[All])
        } ON COLUMNS,
        NON EMPTY 
          FILTER(
            CROSSJOIN(
              [Product1].[Product ID].[Product ID].Members,
              [Sales Reason].[Name].[Name].Members
            ),
           NOT [Sales Reason].[Name].CurrentMember  IS [Sales Reason].[Name].[Unknown]
          ) ON ROWS
      FROM [CubeExamenFinal]";

    public static string GetLineTotalByTerritoryAndReason = @"SELECT 
        NON EMPTY {
          ([Measures].[Line Total], [Dim Date].[Year].[Year].Members),
          ([Measures].[Line Total], [Dim Date].[Year].[All])
        } ON COLUMNS,
        NON EMPTY 
          FILTER(
           (
             [Territory].[Name].[Name].Members,
              [Sales Reason].[Name].[Name].Members
            ),
           NOT [Sales Reason].[Name].CurrentMember  IS [Sales Reason].[Name].[Unknown]
          ) ON ROWS
      FROM [CubeExamenFinal]";

}