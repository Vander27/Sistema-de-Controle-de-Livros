using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Projeto.Entities;

namespace Projeto.Repository.Mappings
{
    class LivroMap : EntityTypeConfiguration<Livro>
    {
        public LivroMap()
        {
            ToTable("Livro");

            HasKey(l => l.IdLivro);

            Property(l => l.IdLivro)
                .HasColumnName("IdLivro")
                .IsRequired();

            Property(l => l.Titulo)
                .HasColumnName("Titulo")
                .HasMaxLength(100)
                .IsRequired();

            Property(l => l.Genero)
                .HasColumnName("Genero")
                .HasMaxLength(50)
                .IsRequired();

            Property(l => l.Resumo)
                .HasColumnName("Resumo")
                .HasMaxLength(250)
                .IsRequired();

            Property(l => l.Foto)
                .HasColumnName("Foto")
                .HasMaxLength(50)
                .IsRequired();

            Property(l => l.IdAutor)
                .HasColumnName("IdAutor")
                .IsRequired();

            Property(l => l.IdEditora)
                .HasColumnName("IdEditora")
                .IsRequired();

            HasRequired(l => l.Autor)
                .WithMany(a => a.Livros)
                .HasForeignKey(l => l.IdAutor);

            HasRequired(l => l.Editora)
                .WithMany(e => e.Livros)
                .HasForeignKey(l => l.IdEditora);
        }
    }
}
