﻿using Autofac;
using mShop.Core.Infrastructure;
using mShop.Core.Infrastructure.DependencyManagement;
using mShop.Ordering.Services.Orders;

namespace mShop.Ordering.Application.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="DependencyRegistrar" />.
    /// </summary>
    public partial class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Gets the Order.
        /// </summary>
        public int Order => -1;

        /// <summary>
        /// The Register.
        /// </summary>
        /// <param name="builder">The builder<see cref="ContainerBuilder"/>.</param>
        /// <param name="typeFinder">The typeFinder<see cref="ITypeFinder"/>.</param>
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {

        }
    }
}
