namespace VShop.Identity.SeedDatabase
{
    public interface IDatabaseSeedInitializer
    {
        void InitializeSeedRoles();
        void InitializeSeedUsers();
    }
}
