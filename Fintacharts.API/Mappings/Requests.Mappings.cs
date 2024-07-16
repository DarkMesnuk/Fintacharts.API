using AutoMapper;

namespace Fintacharts.API.Mappings;

public partial class RequestsMappings : Profile
{
    public RequestsMappings()
    {
        CreateMapAssets();
    }
}