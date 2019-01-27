using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
   public class Editora
    {
        public int IdEditora { get; set; }
        public string Nome { get; set; }

        public List<Livro> Livros { get; set; }

        public Editora()
        {

        }

        public Editora(int idEditora, string nome)
        {
            IdEditora = idEditora;
            Nome = nome;
        }

        public override string ToString()
        {
            return $"Id: {IdEditora}, Nome: {Nome}";
        }
    }
}
