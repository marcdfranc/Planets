using Application.Core;
using Application.Core.Dtos;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Planets;

public class Edit
{
	public class Command : IRequest<Result<Unit>>
	{
        public Guid Id { get; set; }
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
            var planet = await _context.Planets.FindAsync(request.Id);
               
            if (planet == null) return null;

            _mapper.Map(request.Planet, planet);

            var isSuccess = await _context.SaveChangesAsync() > 0;

            return isSuccess? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failure to update planet");         
        }
    }
}
