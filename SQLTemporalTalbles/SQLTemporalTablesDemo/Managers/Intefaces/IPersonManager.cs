using SQLTemporalTablesDemo.Data.DataModels;

namespace SQLTemporalTablesDemo.Managers
{
    public interface IPersonManager
    {
        int Delete(int id);
        List<Person> GetAllPersons();
        Person GetById(int id);
        int Insert(Person entity);
        int Update(Person entity);
    }
}