﻿using Application.Core;
using MediatR;
using Persistence;

namespace Application.Planets;

public class Delete
{
	public class Command : IRequest<Result<Unit>>
    {
		public Guid Id { get; set; }
	}

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var planet = await _context.Planets.FindAsync(request.Id);
            
            if (planet == null) return null!;

            _context.Planets.Remove(planet);

            var isSuccess = await _context.SaveChangesAsync() > 0;

            return isSuccess ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failure on Delete Planet");           
        }
    }
}
