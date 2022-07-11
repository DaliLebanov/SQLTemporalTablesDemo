using SQLTemporalTablesDemo.Data.DataModels;

namespace SQLTemporalTablesDemo.Managers
{
    public interface IEntityStatusLogManager
    {
        void SetModified<T>(T model) where T : BaseStatusLogModel;
    }
}