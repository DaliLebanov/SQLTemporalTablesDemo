using Microsoft.EntityFrameworkCore;
using SQLTemporalTablesDemo.Data;
using SQLTemporalTablesDemo.Data.DataModels;
using System.Linq;
namespace SQLTemporalTablesDemo.Managers
{
    public class PersonManager : IPersonManager
    {
        protected readonly ApplicationDbContext _context;

        public PersonManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
        }
        public int Delete(int id)
        {
            var person = GetById(id);
            _context.Persons.Remove(person);
            return _context.SaveChanges();
        }
        public Person GetById(int id)
        {
            return _context.Persons.FirstOrDefault(o => o.ID == id);
        }
        public int Insert(Person entity)
        {
            _context.Add(entity);
            return _context.SaveChanges();
        }
        public int Update(Person entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }

        public int Changes(int id)
        {
            var allPersons = _context.Persons.Concat(_context.Persons.FromSqlRaw("SELECT * FROM DepartmentsHistory"));
            var department = from p in allPersons
                             join u in _context.Users on p.LastModifiedBy equals u.Id
                             where p.ID == id
                             select new HistoryViewModel
                             {
                                 ID = p.ID,
                                 ChangedBy = u.UserName,
                                 DateOfChangeUTC = EF.Property<DateTime>(p, "PeriodStart")
                             };
            return _context.SaveChanges();
        }
    }
}
