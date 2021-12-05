namespace mShop.Discount.Core.Domain
{
    /// <summary>
    /// Defines the <see cref="Coupon" />.
    /// </summary>
    public class Coupon : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ProductName.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Amount.
        /// </summary>
        public int Amount { get; set; }
    }
}
