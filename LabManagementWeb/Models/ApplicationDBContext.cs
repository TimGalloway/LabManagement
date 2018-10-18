using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LabManagementWeb.Models
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext() : base("name=LabManagementWeb_model") { }

        public DbSet<Client> Clients { get; set; }

        public override int SaveChanges()
        {
            AddTimeStamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            AddTimeStamps();
            return await base.SaveChangesAsync();
        }
        private void AddTimeStamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUsername = !string.IsNullOrEmpty(System.Web.HttpContext.Current?.User?.Identity?.Name)
                ? HttpContext.Current.User.Identity.Name
                : "Anonymous";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseModel)entity.Entity).DateCreated = DateTime.Now;
                    ((BaseModel)entity.Entity).UserCreated = currentUsername;
                }

                ((BaseModel)entity.Entity).DateModified = DateTime.Now;
                ((BaseModel)entity.Entity).UserModified = currentUsername;
            }
        }

        public System.Data.Entity.DbSet<LabManagementWeb.Models.JobType> JobTypes { get; set; }

        public System.Data.Entity.DbSet<LabManagementWeb.Models.Job> Jobs { get; set; }

        public System.Data.Entity.DbSet<LabManagementWeb.Models.UserProfile> UserProfiles { get; set; }

    }
}
