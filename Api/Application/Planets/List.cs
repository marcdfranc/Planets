using Application.Core;
using Application.Core.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.Planets;

public class List
{
	public class Query : IRequest<Result<PagedList<PlanetResponse>>>
	{
		public PagingParams? Params { get; set; }
	}

    public class Handler : IRequestHandler<Query, Result<PagedList<PlanetResponse>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<PagedList<PlanetResponse>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = _context.Planets
                .ProjectTo<PlanetResponse>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.Position)
                .AsQueryable();

            return Result<PagedList<PlanetResponse>>.Success(
                await PagedList<PlanetResponse>.CreateAsync(query, request.Params?.PageNumber?? 1, request.Params?.PageSize?? 10)
            );
        }
    }
}
