namespace UniBinderAPI.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EF : DbContext
    {
        public EF()
            : base("name=EF")
        {
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Person>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<Person>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Person>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.SubjectName)
                .IsFixedLength();

            modelBuilder.Entity<Subject>()
                .Property(e => e.PersonID)
                .IsFixedLength();
        }
    }
}
