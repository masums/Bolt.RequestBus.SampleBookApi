using Bolt.Common.Extensions;
using Bolt.RequestBus.Handlers;
using BookWorm.Api.Infrastructure.Mappers;

namespace BookWorm.Api.Features.GetBooks
{
    public class GetBooksByIdRequestHandler : RequestHandlerBase<GetBookByIdRequest, BookDto>
    {
        private readonly IBookRepository repository;
        private readonly IMapper mapper;

        public GetBooksByIdRequestHandler(IBookRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        protected override BookDto Process(GetBookByIdRequest msg)
        {
            return repository.GetById(msg.Id).NullSafeGet(bookRecord => mapper.Map<BookDto>(bookRecord));
        }
    }
}