using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Projeto.Entities;

namespace Projeto.Repository.Mappings
{
   public class EditoraMap : EntityTypeConfiguration<Editora>
    {
        public EditoraMap()
        {
            ToTable("Editora");

            HasKey(e => e.IdEditora);

            Property(e => e.IdEditora)
                .HasColumnName("IdEditora")
                .IsRequired();

            Property(e => e.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
