namespace SQLTemporalTablesDemo.Data.DataModels
{
    public abstract class BaseModifiableModel
    {
        public int CreatedBy { get; internal set; }
        public DateTime CreatedDate { get; internal set; }

        public int LastModifiedBy { get; internal set; }
        public DateTime LastModifiedDate { get; internal set; }
    }

    public abstract class BaseModifiableDeletableModel : BaseModifiableModel { }
}
