using System;

namespace BookWorm.Api.Features.GetBooks
{
    public class DiscountDto
    {
        public Guid BookId { get; set; }
        public decimal Discount { get; set; }
    }
}