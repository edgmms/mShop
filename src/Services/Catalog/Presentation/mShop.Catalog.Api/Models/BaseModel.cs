namespace mShop.Catalog.Api.Models
{
    /// <summary>
    /// Represents base model
    /// </summary>
    public partial class BaseModel
    {
        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public BaseModel()
        {
            PostInitialize();
        }

        #endregion

        #region Methods
 
        /// <summary>
        /// Perform additional actions for the model initialization
        /// </summary>
        /// <remarks>Developers can override this method in custom partial classes in order to add some custom initialization code to constructors</remarks>
        protected virtual void PostInitialize()
        {
        }

        #endregion
    }
}
