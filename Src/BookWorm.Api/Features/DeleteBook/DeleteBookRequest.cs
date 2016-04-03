using System;
using Bolt.RequestBus;

namespace BookWorm.Api.Features.DeleteBook
{
    public class DeleteBookRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}