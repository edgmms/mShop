namespace mShop.Catalog.Data.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="IDbInitializer" />.
    /// </summary>
    public partial interface IDbInitializer
    {
        /// <summary>
        /// The SeedData.
        /// </summary>
        void Initialize();
    }
}
