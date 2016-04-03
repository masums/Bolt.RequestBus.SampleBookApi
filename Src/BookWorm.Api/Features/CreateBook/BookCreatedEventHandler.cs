using Bolt.RequestBus;
using BookWorm.Api.Features.Shared;
using BookWorm.Api.Infrastructure.PersistentStores;

namespace BookWorm.Api.Features.CreateBook
{
    public class BookCreatedEventHandler : IEventHandler<BookCreatedEvent>
    {
        private readonly IPersistentStore store;

        public BookCreatedEventHandler(IPersistentStore store)
        {
            this.store = store;
        }

        public void Handle(BookCreatedEvent eEvent)
        {
            store.Append(Constants.PersistanceStoreNames.EventSource, eEvent);
        }
    }
}
