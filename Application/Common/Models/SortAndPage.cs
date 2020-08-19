using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Application.Common.Models
{
    public abstract class SortAndPage
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
