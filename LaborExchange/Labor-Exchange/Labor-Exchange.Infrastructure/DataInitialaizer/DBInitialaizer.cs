using Labor_Exchange.Infrastructure.ApplicationContext;

namespace Labor_Exchange.Infrastructure.DataInitialaizer
{
    public static class DBInitialaizer
    {
        public static void Initialize(EFContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
