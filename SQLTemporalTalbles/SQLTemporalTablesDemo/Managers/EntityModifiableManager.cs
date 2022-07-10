using SQLTemporalTablesDemo.Data.DataModels;

namespace SQLTemporalTablesDemo.Managers
{
    public class EntityModifiableManager : IEntityModifiableManager
    {
        private readonly ICurrentUserService _currentUserService;

        public EntityModifiableManager(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        /// <summary>
        /// Sets CreatedBy, CreatedDate, LastModifiedBy and LastModifiedDate to appropriate values
        /// </summary>
        public void SetCreated<T>(T model) where T : BaseModifiableModel
        {
            model.CreatedBy = _currentUserService.UserId.Value;
            model.CreatedDate = DateTime.Now;

            model.LastModifiedBy = _currentUserService.UserId.Value;
            model.LastModifiedDate = DateTime.Now;
        }

        /// <summary>
        /// Sets LastModifiedBy and LastModifiedDate to appropriate values
        /// </summary>
        public void SetModified<T>(T model) where T : BaseModifiableModel
        {
            model.LastModifiedBy = _currentUserService.UserId.Value;
            model.LastModifiedDate = DateTime.Now;
        }
    }

   
}
