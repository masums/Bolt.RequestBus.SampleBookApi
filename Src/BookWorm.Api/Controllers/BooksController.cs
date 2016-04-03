using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Bolt.RequestBus;
using BookWorm.Api.Features.CreateBook;
using BookWorm.Api.Features.DeleteBook;
using BookWorm.Api.Features.GetBooks;
using BookWorm.Api.Features.Shared.Extensions;
using BookWorm.Api.Infrastructure.Extensions;

namespace BookWorm.Api.Controllers
{
    [RoutePrefix("v1/books")]
    public class GetBooksController : ApiController
    {
        private readonly IRequestBus bus;

        public GetBooksController(IRequestBus bus)
        {
            this.bus = bus;
        }

        [Route("{id}", Name = RouteNames.BookById)]
        [HttpGet]
        public IHttpActionResult Get([FromUri]GetBookByIdRequest request)
        {
            var response = bus.Send<GetBookByIdRequest, BookDto>(request);

            return this.ResponseResult(response);
        }

        [Route]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var response = await bus.SendAsync<GetAllBooksRequest, IEnumerable<BookDto>>(new GetAllBooksRequest());

            return this.ResponseResult(response);
        }

        [Route]
        [HttpPost]
        public IHttpActionResult Post([FromBody] CreateBookRequest request)
        {
            var response = bus.Send<CreateBookRequest, Guid>(request);

            return this.ResponseResult(response, id => Url.BookById(id));
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri] DeleteBookRequest request)
        {
            var response = await bus.SendAsync(request);
            
            return this.ResponseResult(response);
        }
    }
}