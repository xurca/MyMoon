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
            return new GetRoutesQueryResponse
            {
                Items = await _context.Routes.Select(x => new GetRoutesQueryItem
                {

                }).ToListAsync()
            };
        }
    }
}
