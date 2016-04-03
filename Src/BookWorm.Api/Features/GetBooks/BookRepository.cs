using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookWorm.Api.Features.Shared.Dto;
using BookWorm.Api.Infrastructure.PersistentStores;

namespace BookWorm.Api.Features.GetBooks
{
    public interface IBookRepository
    {
        BookRecord GetById(Guid id);
        Task<IEnumerable<BookRecord>> GetAllAsync();
    }

    public class BookRepository : IBookRepository
    {
        private readonly IPersistentStore store;

        public BookRepository(IPersistentStore store)
        {
            this.store = store;
        }

        public BookRecord GetById(Guid id)
        {
            return store.Read<BookRecord>().SingleOrDefault(book => book.Id == id);
        }

        public Task<IEnumerable<BookRecord>> GetAllAsync()
        {
            return Task.FromResult(store.Read<BookRecord>());
        }
    }
}