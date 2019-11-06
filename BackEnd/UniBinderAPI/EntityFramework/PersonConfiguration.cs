using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace UniBinderAPI.EntityFramework
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            this.Property(p => p.PersobID)
                .IsRequired();
           

            this.Property(s => s.PersonName)
                .IsConcurrencyToken();
        }
    }
}