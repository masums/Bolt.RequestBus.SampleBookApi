namespace BookWorm.Api.Infrastructure.PersistentStores
{
    public static class PersistentStoreExtensions
    {
        public static void Append<T>(this IPersistentStore store, T record)
        {
            store.Append(new[] { record });
        }

        public static void Append<T>(this IPersistentStore store, string groupName, T record)
        {
            store.Append(groupName, new[] { record });
        }
    }
}