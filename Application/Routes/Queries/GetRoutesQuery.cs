using FluentValidation;
using MediatR;
using System.Collections;
using System.Collections.Generic;

namespace MyMoon.Application.Routes.Queries
{
    public class GetRoutesQueryRequest : IRequest<GetRoutesQueryResponse>
    {

    }

    public class GetRoutesQueryResponse
    {
        public IEnumerable<GetRoutesQueryItem> Items { get; set; }
    }

    public class GetRoutesQueryItem
    {
    }

    public class GetRoutesQueryRequestValidator : AbstractValidator<GetRoutesQueryRequest>
    {
        public GetRoutesQueryRequestValidator()
        {
        }
    }
}
