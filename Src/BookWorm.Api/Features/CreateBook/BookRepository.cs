using System.Linq;
using Bolt.Common.Extensions;
using BookWorm.Api.Features.Shared.Dto;
using BookWorm.Api.Infrastructure.PersistentStores;

namespace BookWorm.Api.Features.CreateBook
{
    public interface IBookRepository
    {
        void Insert(BookRecord record);
        BookRecord GetByTitle(string title);
    }

    public class BookRepository : IBookRepository
    {
        private readonly IPersistentStore store;

        public BookRepository(IPersistentStore store)
        {
            this.store = store;
        }

        public void Insert(BookRecord record)
        {
            store.Append(record);
        }

        public BookRecord GetByTitle(string title)
        {
            return store.Read<BookRecord>().FirstOrDefault(x => x.Title.IsSame(title));
        }
    }
}