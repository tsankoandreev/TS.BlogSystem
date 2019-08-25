using System;
using System.Collections.Generic;
using System.Text;

namespace TS.BlogSystem.Core.Interfaces
{
    public interface IPagedBase
    {
        int PageIndex { get; }
        int PageSize { get; }
        int ResultsCaunt { get; }
        int ResultPages { get; }
        int TotalCaunt { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}
