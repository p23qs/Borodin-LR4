using System.Data.Entity;

namespace Borodin
{
    public partial class ModelEF : DbContext
    {
        public ModelEF() : base("name=ModelEF") { }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasMany(r => r.Users).WithRequired(u => u.Roles)
                .HasForeignKey(u => u.Role_Name).WillCascadeOnDelete(false);
        }
    }
}
