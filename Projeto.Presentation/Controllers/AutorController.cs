using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Presentation.Models;
using Projeto.Entities;
using Projeto.Repository.Persistence;
using System.Collections;
using System.Net;

namespace Projeto.Presentation.Controllers
{
    public class AutorController : Controller
    {
        // GET: Autor
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Autor
        public ActionResult Consulta()
        {
            return View();
        }

        //JsonResult -> Receber chamadas Ajax (JavaScript)
        public JsonResult CadastrarAutor(AutorCadastroViewModel model)
        {
            // verificar se os dados model passaram nas validacoes..
            if (ModelState.IsValid)
            {
                try
                {
                    // entidade..
                    Autor a = new Autor();
                    a.Nome = model.Nome;

                    //gravar no banco..
                    AutorRepository rep = new AutorRepository();
                    rep.Insert(a);

                    return Json($"Autor {a.Nome}, cadastrado com sucesso.");
                }
                catch (Exception e)
                {
                    //retornar mensagem de erro..
                    return Json(e.Message);
                    
                }
            }
            else
            {
                //criar uma rotina para retornar as mensagens de erro de 
                //validacao para cada campo da classe viewmodel..
                Hashtable erros = new Hashtable();

                //varrer o objeto ModelState..
                foreach(var state in ModelState)
                {
                    //verificar se o elemento contem erro..
                    if (state.Value.Errors.Count > 0)
                    {
                        //adicionar o erro dentro do Hashtable..
                        erros[state.Key] = state.Value.Errors
                            .Select(e => e.ErrorMessage).First();
                    }
                }


                // retornar erros de Validação.. Status 400
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(erros);
            }
        }

       //método para retornar a consulta de autores para o Angular..
       public JsonResult ConsultarAutores()
        {
            try
            {
                //declarar uma lista da classe AutorConsultaViewModel..
                List<AutorConsultaViewModel> lista = new List<AutorConsultaViewModel>();

                //varrer cada autor abtido do banco de dados
                AutorRepository rep = new AutorRepository();
                foreach(Autor a in rep.FindAll())
                {
                    AutorConsultaViewModel model = new AutorConsultaViewModel();
                    model.IdAutor = a.IdAutor;
                    model.Nome = a.Nome;

                    lista.Add(model); //adicionando na lista..
                }

                //retornando a lista
                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}