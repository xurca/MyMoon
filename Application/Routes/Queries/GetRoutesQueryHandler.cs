using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyMoon.Application.Common.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyMoon.Application.Routes.Queries
{
    public class GetRoutesQueryHandler : IRequestHandler<GetRoutesQueryRequest, GetRoutesQueryResponse>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetRoutesQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetRoutesQueryResponse> Handle(GetRoutesQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _context.Routes
                .AsNoTracking()
                .Include(x => x.Passenger)
                .Filter(request.Location, x => x.Location)
                .Filter(request.From, request.To, x => x.DepartureTime)
                .Select(x => new GetRoutesQueryItem
                {
                    DepartureTime = x.DepartureTime,
                    Destination = x.Destination,
                    LagguageSize = x.LagguageSize,
                    Location = x.Location,
                    FullName = x.Passenger.FullName
                }).ToListAsync();

            return new GetRoutesQueryResponse
            {
                Items = result
            };
        }
    }
}
