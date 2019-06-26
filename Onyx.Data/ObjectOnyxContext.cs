using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Onyx.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onyx.Data
{
    public partial class ObjectOnyxContext : DbContext
    {
        public ObjectOnyxContext()
            : base("name=OnyxEntities")
        {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
            //throw new UnintentionalCodeFirstException();
            modelBuilder.Entity<CustomerSetting>().ToTable("CustomerSettings")
                .HasKey(c => c.CustomerSettingID)
                .Property(c => c.CustomerSettingID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("CustomerSettingID");

          //  modelBuilder.Entity<Usuario>().ToTable("Usuario")
            //    .HasKey(c=>c.UsuarioID)
              //  .Property(c=>c.UsuarioID)
               // .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                //.HasColumnName("UsuarioID");
        }

    public virtual DbSet<Rol> Rols { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<CustomerSetting> CustomerSettings { get; set; }
    }
}
