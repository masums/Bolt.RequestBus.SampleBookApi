using System.Collections.Generic;

namespace BookWorm.Api.Infrastructure.PersistentStores
{
    public interface IPersistentStore
    {
        void Append<T>(IEnumerable<T> data);
        void Append<T>(string groupName, IEnumerable<T> data);
        void Write<T>(string groupName, IEnumerable<T> data);
        void Write<T>(IEnumerable<T> data);
        IEnumerable<T> Read<T>();
        IEnumerable<T> Read<T>(string groupName);
    }
}
