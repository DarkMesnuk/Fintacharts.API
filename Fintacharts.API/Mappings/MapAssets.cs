using Fintacharts.API.Application.Handlers.Assets;
using Fintacharts.API.Requests.Assets;

namespace Fintacharts.API.Mappings;

public partial class RequestsMappings
{
    private void CreateMapAssets()
    {
        CreateMap<GetAssetsRequest, GetAssetsQueryRequest>();
        CreateMap<GetAllSupportedAssetsRequest, GetAllSupportedAssetsQueryRequest>();
    }
}