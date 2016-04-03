using System;
using Bolt.Logger;
using Bolt.RequestBus;
using Bolt.RequestBus.Handlers;
using BookWorm.Api.Features.Shared.Dto;
using BookWorm.Api.Infrastructure.Mappers;

namespace BookWorm.Api.Features.CreateBook
{
    public class CreateBookRequestHandler : RequestHandlerBase<CreateBookRequest, Guid>
    {
        private readonly ILogger logger;
        private readonly IBookRepository repository;
        private readonly IRequestBus bus;
        private readonly IMapper mapper;

        public CreateBookRequestHandler(ILogger logger, IBookRepository repository, IRequestBus bus, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.bus = bus;
            this.mapper = mapper;
        }

        protected override Guid Process(CreateBookRequest msg)
        {
            var id = Guid.NewGuid();

            var record = mapper.Map<BookRecord>(msg);

            record.Id = id;

            repository.Insert(record);

            logger.Info($"New book created with id {id} and title {msg.Title}");

            bus.Publish(new BookCreatedEvent { Id = id });

            return id;
        }
    }
}