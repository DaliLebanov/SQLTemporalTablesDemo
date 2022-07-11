using SQLTemporalTablesDemo.Data.DataModels;

namespace SQLTemporalTablesDemo.Managers
{
    public interface IEntityModifiableManager
    {
        void SetCreated<T>(T model) where T : BaseModifiableModel;
        void SetModified<T>(T model) where T : BaseModifiableModel;
    }
}