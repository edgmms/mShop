using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mShop.Ordering.Core;

namespace mShop.Ordering.Data.Mappings
{
    /// <summary>
    /// Defines the <see cref="IEntityTypeConfigurator" />.
    /// </summary>
    public partial class EntityTypeConfigurator<TEntity>  : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {

        }
    }
}
