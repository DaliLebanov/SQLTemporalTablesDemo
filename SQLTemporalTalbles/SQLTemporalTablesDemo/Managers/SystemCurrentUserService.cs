using Microsoft.Extensions.Options;
using SQLTemporalTablesDemo.Data.DataModels;

namespace SQLTemporalTablesDemo.Managers
{
    public class SystemCurrentUserService : ICurrentUserService
    {
        private readonly IOptions<SystemUserOptions> _options;

        public SystemCurrentUserService(IOptions<SystemUserOptions> options)
        {
            _options = options;
        }

        public int? UserId => _options.Value.ID;

        public string UserName => _options.Value.UserName;

        public string UserEmail => _options.Value.Email;
        public string UserRole => _options.Value.UserRole;
    }
}
