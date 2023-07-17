using Application.Core;
using Application.Core.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Planets;

public class Detail
{
	public class Query : IRequest<Result<PlanetResponse>>
	{
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<PlanetResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<PlanetResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            var planet = await _context.Planets
                .Where(p => p.Id == request.Id)
                .ProjectTo<PlanetResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (planet == null) return null!;

            return Result<PlanetResponse>.Success(planet);            
        }
    }
}
