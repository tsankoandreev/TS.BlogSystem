using System;
using System.Collections.Generic;
using System.Text;
using TS.BlogSystem.Core.Interfaces;

namespace TS.BlogSystem.Core.Common
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int resultsCount, int totalUnfiltered)
        {
            ResultsCaunt = resultsCount;
            PageSize = pageSize;
            PageIndex = pageIndex;

            if (resultsCount == 0)
                ResultPages = 1;
            else
                ResultPages = resultsCount % pageSize != 0 ? resultsCount / pageSize + 1 : resultsCount / pageSize;

            AddRange(source);

            TotalCaunt = totalUnfiltered;
        }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int ResultsCaunt { get; private set; }
        public int ResultPages { get; private set; }

        public int TotalCaunt { get; private set; }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 1); }
        }
        public bool HasNextPage
        {
            get { return (PageIndex<ResultPages); }
        }
    }
}
