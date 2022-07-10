using Microsoft.EntityFrameworkCore;
using SQLTemporalTablesDemo.Data.DataModels;
using SQLTemporalTablesDemo.Managers;

namespace SQLTemporalTablesDemo.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IEntityModifiableManager _entityModifiableManager;
        private readonly IEntityStatusLogManager _entityStatusLogManager;
        public AppDbContext() 
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options, IEntityModifiableManager entityModifiableManager, IEntityStatusLogManager entityStatusLogManager) 
            : base(options)
        {
            _entityModifiableManager = entityModifiableManager;
            _entityStatusLogManager = entityStatusLogManager;
        }

        public override int SaveChanges()
        {
            var changedEntities = ChangeTracker.Entries();
            var deletedEntities = new List<object>();

            foreach (var changedEntity in changedEntities)
            {
                if (changedEntity.Entity is BaseModifiableModel modifiableEntity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            _entityModifiableManager.SetCreated(modifiableEntity);
                            break;

                        case EntityState.Modified:
                            _entityModifiableManager.SetModified(modifiableEntity);
                            break;

                    }
                }

                if (changedEntity.Entity is BaseModifiableDeletableModel deletableEntity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Deleted:
                            changedEntity.State = EntityState.Modified;
                            _entityModifiableManager.SetModified(deletableEntity);
                            deletedEntities.Insert(0, deletableEntity);
                            break;

                    }
                }

                if (changedEntity.Entity is BaseStatusLogModel entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            _entityStatusLogManager.SetModified(entity);
                            break;
                    }
                }
            }

            var baseResult = base.SaveChanges();
            if (deletedEntities.Count == 0)
            {
                return baseResult;
            }

            base.RemoveRange(deletedEntities);
            return baseResult + base.SaveChanges();
        }
    }
}
