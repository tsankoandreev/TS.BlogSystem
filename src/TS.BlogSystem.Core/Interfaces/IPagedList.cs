using System;
using System.Collections.Generic;
using System.Text;

namespace TS.BlogSystem.Core.Interfaces
{
    public interface IPagedList<T> : IList<T>, IPagedBase
    {
    }
}
