using FluentValidation;

namespace mShop.Catalog.Api.Validators
{
    /// <summary>
    /// Base class for validators
    /// </summary>
    /// <typeparam name="TModel">Type of model being validated</typeparam>
    public abstract class BaseFluentValidator<TModel> : AbstractValidator<TModel> where TModel : class
    {
        #region Ctor

        protected BaseFluentValidator()
        {
            PostInitialize();
        }

        #endregion

        #region Utilities

        /// <summary>
        /// override this method in custom partial classes in order to 
        /// add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {
        }

        #endregion
    }
}
