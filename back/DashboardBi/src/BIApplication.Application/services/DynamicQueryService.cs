using BIApplication.Core.interfaces;
using BIApplication.Core.Interfaces;
using BIApplication.Core.models;
//using BIApplication.Infrastructure.mdxBuilder;

namespace BIApplication.Application.services;
public class DynamicQueryService : IDynamicQueryService
{
    private readonly ICubeRepository _cubeRepository;
    //private readonly MdxQueryBuilder _builder;

    public DynamicQueryService(ICubeRepository cubeRepository)
    {
        _cubeRepository = cubeRepository;

    }

    public async Task<List<MdxGenericResult>> GetDynamicResultsAsync(string dimension, string hierarchy, string level, string measure)
    {
        // Construction dynamique de la requête MDX
        string mdx = $@"
                SELECT 
                    [Measures].[{measure}] ON COLUMNS,
                    NON EMPTY [{dimension}].[{hierarchy}].[{level}].MEMBERS ON ROWS
                FROM [CubeExamenFinal]";
        string memberCaptionColumnName = $"[{dimension}].[{hierarchy}].[{level}].[MEMBER_CAPTION]";


        var columnMappings = new Dictionary<string, string>
        {
            { "Label", memberCaptionColumnName },
            { "TotalLine", $"[Measures].[{measure}]" }
        };

        return await _cubeRepository.ExecuteMdxQueryAsync<MdxGenericResult>(mdx, columnMappings);
    }
}

