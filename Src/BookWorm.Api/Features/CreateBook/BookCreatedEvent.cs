using System;
using BookWorm.Api.Infrastructure;
using Bolt.RequestBus;


namespace BookWorm.Api.Features.CreateBook
{
    public class BookCreatedEvent : Bolt.RequestBus.IEvent, IIgnoreEventSource
    {
        public Guid Id { get; set; }
    }
}
