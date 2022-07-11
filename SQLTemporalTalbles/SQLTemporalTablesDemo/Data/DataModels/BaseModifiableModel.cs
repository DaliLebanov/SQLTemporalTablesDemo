namespace SQLTemporalTablesDemo.Data.DataModels
{
    public abstract class BaseModifiableModel
    {
        public string CreatedBy { get; internal set; }
        public DateTime CreatedDate { get; internal set; }

        public string LastModifiedBy { get; internal set; }
        public DateTime LastModifiedDate { get; internal set; }
    }

    public abstract class BaseModifiableDeletableModel : BaseModifiableModel { }
}
