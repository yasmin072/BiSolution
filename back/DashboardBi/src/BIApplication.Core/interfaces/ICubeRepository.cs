namespace BIApplication.Core.Interfaces;
//contrat pour acceder aux donnees du cube
public interface ICubeRepository
{
    Task<List<T>> ExecuteMdxQueryAsync<T>(string mdxQuery,Dictionary<string,string> columnMappings) where T : new(); 
    Task ConnectAsync(string connectionString); 
    Task DisconnectAsync();
    //Task<List<T>> ExecuteMdxQueryAsync(string mdxQuery, Dictionary<string, string> columnMappings) where T : new(); 
 
}