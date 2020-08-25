using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyMoon.Application.Common.Interfaces;
using MyMoon.Domain.Entities;
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
            var totalCount = await _context.Set<Route>().AsNoTracking().CountAsync();

            var result = await _context.Set<Route>()
                .AsNoTracking()
                .Include(x => x.User)
                .Include(x => x.Preferences)
                .ThenInclude(x => x.Preference)
                .Filter(request.Location, x => x.Location)
                .Filter(request.Destination, x => x.Destination)
                .Filter(request.From, request.To, x => x.DepartureTime)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new GetRoutesQueryItem
                {
                    ArrivalTime = x.ArrivalTime,
                    DepartureTime = x.DepartureTime,
                    Destination = x.Destination,
                    LagguageSize = x.LagguageSize,
                    Location = x.Location,
                    FullName = x.User.FullName,
                    PricePerSeat = x.PricePerSeat,
                    TotalSeats = x.TotalSeats,
                    Rating = x.User.Rating,
                    Age = x.User.Age,
                    Gender = x.User.Gender,
                    Preferences = x.Preferences.Select(p => p.Preference.Name)
                }).ToListAsync();

            return new GetRoutesQueryResponse
            {
                Items = result,
                Total = totalCount
            };
        }
    }
}
