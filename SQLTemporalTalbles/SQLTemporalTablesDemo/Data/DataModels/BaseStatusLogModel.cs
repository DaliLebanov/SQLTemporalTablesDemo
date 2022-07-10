namespace SQLTemporalTablesDemo.Data.DataModels
{
    public abstract class BaseStatusLogModel
    {
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
