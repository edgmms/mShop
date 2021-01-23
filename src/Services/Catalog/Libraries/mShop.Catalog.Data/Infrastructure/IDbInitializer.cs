namespace mShop.Catalog.Data.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="IDbInitializer" />.
    /// </summary>
    public interface IDbInitializer
    {
        /// <summary>
        /// The SeedData.
        /// </summary>
        void Initialize();
    }
}
