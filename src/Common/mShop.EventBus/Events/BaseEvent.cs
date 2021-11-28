using System;

namespace mShop.EventBus.Events
{
    /// <summary>
    /// Defines the <see cref="BaseEvent" />.
    /// </summary>
    public partial class BaseEvent
    {
        /// <summary>
        /// Gets or sets the RequestId.
        /// </summary>
        public Guid RequestId { get; set; }
    }
}
