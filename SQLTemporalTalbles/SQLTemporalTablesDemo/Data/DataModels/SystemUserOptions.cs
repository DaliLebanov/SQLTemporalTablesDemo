namespace SQLTemporalTablesDemo.Data.DataModels
{
    public class SystemUserOptions
    {
        public const string SystemUser = "SystemUser";

        public int ID { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
        public string UserRole { get; set; }
    }
}
