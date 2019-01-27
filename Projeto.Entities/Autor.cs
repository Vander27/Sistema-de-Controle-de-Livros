using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Autor
    {
        public int IdAutor { get; set; }
        public string Nome { get; set; }

        //relacionamento
        public List<Livro> Livros { get; set; }

        public Autor()
        {

        }

        public Autor(int idAutor, string nome)
        {
            IdAutor = idAutor;
            Nome = nome;
        }

        public override string ToString()
        {
            return $"Id: {IdAutor}, Nome: {Nome}";
        }
    }
}
