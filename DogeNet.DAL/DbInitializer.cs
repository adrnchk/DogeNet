namespace DogeNet.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(DBContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
