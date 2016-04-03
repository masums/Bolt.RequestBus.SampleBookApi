using System;
using System.Collections.Generic;

namespace BookWorm.Api.Features.GetBooks
{
    public interface IDiscountApiProxy
    {
        IEnumerable<DiscountDto> Get(IEnumerable<Guid> bookIds);
    }
}
