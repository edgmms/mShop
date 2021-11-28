using System.ComponentModel;

namespace mShop.Catalog.Api.Models
{
    /// <summary>
    /// Defines the <see cref="BaseEntitySearchModel" />.
    /// </summary>
    public partial class BaseEntitySearchModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the PageSize.
        /// </summary>
        [DefaultValue(50)]
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the PageIndex.
        /// </summary>
        [DefaultValue(0)]
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether LoadOnlyTotalCount.
        /// </summary>
        [DefaultValue(false)]
        public bool LoadOnlyTotalCount { get; set; }
    }
}
