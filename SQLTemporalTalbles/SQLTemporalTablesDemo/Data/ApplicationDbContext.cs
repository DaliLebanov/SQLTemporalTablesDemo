using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SQLTemporalTablesDemo.Data.DataModels;
using SQLTemporalTablesDemo.Managers;

namespace SQLTemporalTablesDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IEntityModifiableManager _entityModifiableManager;
        private readonly IEntityStatusLogManager _entityStatusLogManager;
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IEntityModifiableManager entityModifiableManager, IEntityStatusLogManager entityStatusLogManager) 
            : base(options)
        {
            _entityModifiableManager = entityModifiableManager;
            _entityStatusLogManager = entityStatusLogManager;
        }

        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Person>().ToTable(p => p.IsTemporal());

            base.OnModelCreating(modelBuilder);

            string adminId = "123";

            string adminRoleId = "321";



            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = adminRoleId,
                Name = "Dali",
                NormalizedName = "DALI"
            });

            var hasher = new PasswordHasher<IdentityUser>();
           
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = adminId,
                UserName = "dali",
                NormalizedUserName = "dali".ToUpper(),
                Email = "dali@mail.com",
                NormalizedEmail = "dali@mail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "qw12QW!@1"),
                SecurityStamp = string.Empty
            });
           
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminId
            });

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
