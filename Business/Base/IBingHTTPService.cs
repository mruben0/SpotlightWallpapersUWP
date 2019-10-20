using System.Collections.Generic;
using System.Threading.Tasks;
using SpotLightUWP.Core.Models;

namespace SpotLightUWP.Core.Base
{
    public interface IBingHTTPService
    {
        Task<List<ImageDTO>> URLParserAsync();
    }
}