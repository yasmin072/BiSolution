using BIApplication.Core.Interfaces;
using BIApplication.Core.models.product;
using Microsoft.AnalysisServices.AdomdClient;

namespace BIApplication.Infrastructure.Data
{
    public class CubeRepository : ICubeRepository
    {
        private readonly string _connectionString;

      public CubeRepository(string connectionString)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

public async Task<List<T>> ExecuteMdxQueryAsync<T>(string mdxQuery, Dictionary<string, string> columnMappings) where T : new()
{
    var results = new List<T>();

    await Task.Run(() =>
    {
        using var conn = new AdomdConnection(_connectionString);
        conn.Open();
        using var cmd = new AdomdCommand(mdxQuery, conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            var obj = new T();
            bool skip = false;

            Console.WriteLine("Colonnes disponibles 22222 :");
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.WriteLine($"Colonne {i}: {reader.GetName(i)}");
                string columnName = reader.GetName(i);
                foreach (var mapping in columnMappings)
                {
                    if (mapping.Value == columnName && !reader.IsDBNull(i))
                    {
                        var prop = typeof(T).GetProperty(mapping.Key);
                        if (prop?.PropertyType == typeof(string))
                        {
                            string value = reader[i].ToString();
                            if (mapping.Key == "SalesReasonName" && value == "Unknown")
                            {
                                skip = true;
                            }
                            prop.SetValue(obj, value);
                        }
                        else if (prop?.PropertyType == typeof(decimal))
                        {
                            prop.SetValue(obj, Convert.ToDecimal(reader[i]));
                        }
                    }
                    // Détection générique des colonnes dynamiques par année
                    var dictProp = typeof(T).GetProperties()
                        .FirstOrDefault(p => p.PropertyType == typeof(Dictionary<string, decimal>));

                    if (dictProp != null && columnName.Contains("Year") && columnName.Contains("[Measures].["))
                    {
                        var dict = (Dictionary<string, decimal>)dictProp.GetValue(obj) ?? new();

                        string yearKey = "Unknown";
                        if (columnName.Contains("Year].&["))
                            yearKey = columnName.Split("Year].&[")[1].Split(']')[0];
                        else if (columnName.Contains("Year].[All]"))
                            yearKey = "All";

                        if (!reader.IsDBNull(i))
                            dict[yearKey] = Convert.ToDecimal(reader[i]);

                        dictProp.SetValue(obj, dict);
                    }

                    /*else if (typeof(T).GetProperty("LineTotalSumsByYear")?.PropertyType == typeof(Dictionary<string, decimal>)
                             && columnName.StartsWith("[Measures].[Line Total]"))
                    {
                        var dictProp = typeof(T).GetProperty("LineTotalSumsByYear");
                        var dict = (Dictionary<string, decimal>)dictProp?.GetValue(obj) ?? new();

                        string yearKey = "Unknown";
                        if (columnName.Contains("Year].&["))
                            yearKey = columnName.Split("Year].&[")[1].Split(']')[0];
                        else if (columnName.Contains("Year].[All]"))
                            yearKey = "All";

                        if (!reader.IsDBNull(i))
                            dict[yearKey] = Convert.ToDecimal(reader[i]);

                        dictProp?.SetValue(obj, dict);
                    }*/
                }
            }

            if (!skip)
                results.Add(obj);
        }
    });

    return results;
}
    public async Task ConnectAsync(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));
        using (var conn = new AdomdConnection(connectionString))
        {
            conn.Open();
        }
    }

    public async Task DisconnectAsync()
    {
        await Task.CompletedTask;
    }

}
}
    



 