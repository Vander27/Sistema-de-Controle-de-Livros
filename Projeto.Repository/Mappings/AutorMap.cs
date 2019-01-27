using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Projeto.Entities;

namespace Projeto.Repository.Mappings
{
   public class AutorMap : EntityTypeConfiguration<Autor>
    {
        public AutorMap()
        {
            ToTable("Autor");

            HasKey(a => a.IdAutor);

            Property(a => a.IdAutor)
                .HasColumnName("IdAutor")
                .IsRequired();

            Property(a => a.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
