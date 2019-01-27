using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Presentation.Controllers
{
    public class LivroController : Controller
    {
        // GET: Livro
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Livro
        public ActionResult Consulta()
        {
            return View();
        }
    }
}