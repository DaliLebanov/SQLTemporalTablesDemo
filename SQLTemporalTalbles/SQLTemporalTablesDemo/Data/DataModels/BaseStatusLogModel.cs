namespace SQLTemporalTablesDemo.Data.DataModels
{
    public abstract class BaseStatusLogModel
    {
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
