namespace SQLTemporalTablesDemo.Managers
{
    public interface ICurrentUserService
    {
        int? UserId { get; }
        string UserName { get; }
        string UserEmail { get; }
        string UserRole { get; }
    }
}