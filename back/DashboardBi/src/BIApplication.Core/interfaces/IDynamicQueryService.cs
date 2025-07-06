using BIApplication.Core.models;

namespace BIApplication.Core.interfaces;

public interface IDynamicQueryService
{      
    Task<List<MdxGenericResult>> GetDynamicResultsAsync(string dimension, string hierarchy, string level, string measure);

    
}