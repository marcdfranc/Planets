using AutoMapper;
using XCliente.Core.Dtos;

namespace XCliente.Core;

internal class MappingProfiles : Profile
{
	public MappingProfiles()
	{
        CreateMap<BasicClient, PlanetClient>();

    }

}
