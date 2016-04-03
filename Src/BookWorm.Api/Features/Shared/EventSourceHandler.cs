using System.Threading.Tasks;
using Bolt.RequestBus;
using BookWorm.Api.Infrastructure;
using BookWorm.Api.Infrastructure.Extensions;
using BookWorm.Api.Infrastructure.PersistentStores;
using BookWorm.Api.Infrastructure.RequestWrappers;

namespace BookWorm.Api.Features.Shared
{
    public class EventSourceHandler<TEvent> 
        : IEventHandler<TEvent>, IAsyncEventHandler<TEvent> where TEvent : IEvent
    {
        private readonly IPersistentStore store;
        private readonly IRequestContext requestContext;
        private readonly ISettings settings;

        public EventSourceHandler(IPersistentStore store, 
            IRequestContext requestContext, 
            ISettings settings)
        {
            this.store = store;
            this.requestContext = requestContext;
            this.settings = settings;
        }

        public void Handle(TEvent eEvent)
        {
            if(eEvent is IIgnoreEventSource) return;

            store.Write(Constants.PersistanceStoreNames.EventSource, new
            {
                CorrelationId = requestContext.CorrelationId(),
                AppId = settings.ApplicationId,
                Type = eEvent.GetType().GetFriendlyName(),
                Event =  eEvent
            });
        }

        public Task HandleAsync(TEvent eEvent)
        {
            if (eEvent is IIgnoreEventSource) return Task.FromResult(0);

            store.Write(Constants.PersistanceStoreNames.EventSource, new
            {
                CorrelationId = requestContext.CorrelationId(),
                AppId = settings.ApplicationId,
                Type = eEvent.GetType().GetFriendlyName(),
                Event = eEvent
            });

            return Task.FromResult(0);
        }
    }
}