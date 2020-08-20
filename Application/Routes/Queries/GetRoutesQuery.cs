using FluentValidation;
using MediatR;
using MyMoon.Application.Common.Interfaces;
using MyMoon.Application.Common.Models;
using MyMoon.Domain.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MyMoon.Application.Routes.Queries
{
    public class GetRoutesQueryRequest : SortAndPage, IRequest<GetRoutesQueryResponse>
    {
        public string Location { get; set; }
        public string Destination { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }

    public class GetRoutesQueryResponse
    {
        public IEnumerable<GetRoutesQueryItem> Items { get; set; }
        public int Total { get; set; }
    }

    public class GetRoutesQueryItem
    {
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public LagguageSize? LagguageSize { get; set; }
        public string Location { get; set; }
        public string FullName { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal PricePerSeat { get; set; }
        public decimal TotalSeats { get; set; }
        public decimal Rating { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public IEnumerable<string> Preferences { get; set; }
    }

    public class GetRoutesQueryRequestValidator : AbstractValidator<GetRoutesQueryRequest>
    {
        public GetRoutesQueryRequestValidator()
        {
        }
    }
}
