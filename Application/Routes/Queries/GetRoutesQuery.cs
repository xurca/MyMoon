using FluentValidation;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MyMoon.Application.Routes.Queries
{
    public class GetRoutesQueryRequest : IRequest<GetRoutesQueryResponse>
    {
        public string Location { get; set; }
        public string Destination { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }

    public class GetRoutesQueryResponse
    {
        public IEnumerable<GetRoutesQueryItem> Items { get; set; }
    }

    public class GetRoutesQueryItem
    {
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public int? LagguageSize { get; set; }
        public string Location { get; set; }
        public string FullName { get; set; }
    }

    public class GetRoutesQueryRequestValidator : AbstractValidator<GetRoutesQueryRequest>
    {
        public GetRoutesQueryRequestValidator()
        {
        }
    }
}
