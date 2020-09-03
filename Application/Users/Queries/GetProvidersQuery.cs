using MediatR;
using MyMoon.Application.Common.Models;
using System.Collections.Generic;

namespace MyMoon.Application.Users.Queries
{
    public class GetProvidersQueryRequest : IRequest<GetProvidersQueryResponse>
    {

    }

    public class GetProvidersQueryResponse : Result
    {
        public IEnumerable<ProviderItem> Providers { get; set; }
    }

    public class ProviderItem
    {
        public ProviderItem(string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
        }

        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
