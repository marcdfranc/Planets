using Application.Core;
using Application.Core.Dtos;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Planets;

public class Create
{
	public class Command : IRequest<Result<Unit>>
	{
		public PlanetData Planet { get; set; }
	}

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var planet = _mapper.Map<Planet>(request.Planet);

            await _context.Planets.AddAsync(planet);

            var isSuccess = await _context.SaveChangesAsync() > 0;

            return isSuccess ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failure to create Planet");
        }
    }
}
