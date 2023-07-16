using Application.Core.Dtos;
using AutoMapper;
using Domain;

namespace Application.Core;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<PlanetData, Planet>();

		CreateMap<Planet, PlanetResponse>()
			.ForMember(pr => pr.DecimalMass, d => d.MapFrom(p => p.Mass))
			.ForMember(pr => pr.DecimalDistanceFromTheSun, d => d.MapFrom(p => p.DistanceFromTheSun))
			.ForMember(pr => pr.Mass, d => d.Ignore())
			.ForMember(pr => pr.DistanceFromTheSun, d => d.Ignore());
	}

}
