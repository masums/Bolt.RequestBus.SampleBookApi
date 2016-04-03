using System;
using System.Linq;
using System.Threading.Tasks;
using BookWorm.Api.Features.Shared.Dto;
using BookWorm.Api.Infrastructure.PersistentStores;

namespace BookWorm.Api.Features.DeleteBook
{
    public interface IBookRepository
    {
        Task DeleteAsync(Guid id);
    }

    public class BookRepository : IBookRepository
    {
        private readonly IPersistentStore store;

        public BookRepository(IPersistentStore store)
        {
            this.store = store;
        }

        public Task DeleteAsync(Guid id)
        {
            var records = store.Read<BookRecord>().Where(record => record.Id != id);
            store.Write(records);

            return Task.FromResult(0);
        }
    }
}