using SQLTemporalTablesDemo.Data.DataModels;

namespace SQLTemporalTablesDemo.Managers
{
    public class EntityStatusLogManager : IEntityStatusLogManager
    {
        private readonly ICurrentUserService _currentUserService;

        public EntityStatusLogManager(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        /// <summary>
        /// Sets ModifiedBy and ModifiedDate to appropriate values
        /// </summary>
        public void SetModified<T>(T model) where T : BaseStatusLogModel
        {
            model.ModifiedBy = _currentUserService.UserId;
            model.ModifiedDate = DateTime.Now;
        }
    }
}
