namespace mShop.Discount.Data.Infrastructure
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
