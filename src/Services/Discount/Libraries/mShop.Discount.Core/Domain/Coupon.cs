namespace mShop.Discount.Core.Domain
{
    /// <summary>
    /// Defines the <see cref="Coupon" />.
    /// </summary>
    public partial class Coupon : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ProductId.
        /// </summary>
        public int ProductId { get; set; }

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
