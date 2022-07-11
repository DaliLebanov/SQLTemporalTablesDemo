namespace SQLTemporalTablesDemo.Managers
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        string UserName { get; }
        string UserEmail { get; }
        string UserRole { get; }
    }
}