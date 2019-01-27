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
    public class EditoraController : Controller
    {
        // GET: Editora
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Editora
        public ActionResult Consulta()
        {
            return View();
        }

        //JsonResult -> Receber chamadas AJAX (javascript)
        public JsonResult CadastrarEditora(EditoraCadastroViewModel model)
        {
            //verificar  se os dados da model passaram nas validações..
            if (ModelState.IsValid)
            {
                try
                {
                    //entidade
                    Editora e = new Editora();
                    e.Nome = model.Nome;


                    //gravar no banco..
                    EditoraRepository rep = new EditoraRepository();
                    rep.Insert(e);

                    return Json($"Editora {e.Nome}, cadastrado com sucesso.");

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
                //validação para cada campo da classe viewModel..
                Hashtable erros = new Hashtable();

                //varrer o objeto ModelState..
                foreach (var state in ModelState)
                {
                    //verificar se o elemento contem erro..
                    if (state.Value.Errors.Count > 0)
                    {
                        //adicionar o erro dentro do Hastable
                        erros[state.Key] = state.Value.Errors
                            .Select(e => e.ErrorMessage).First();
                    }
                }

                //retornar erros de validaçâo..STATUS 400
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(erros);
            }
        }


        //método para retornar a consulta de Editora para o Angular..
        public JsonResult ConsultarEditora()
        {
            try
            {
                //declarar uma lista da classe EditoraConsultaViewModel..
                List<EditoraConsultaViewModel> lista = new List<EditoraConsultaViewModel>();

                //varrer cada editora obtido do banco de dados
                EditoraRepository rep = new EditoraRepository();
                foreach (Editora e in rep.FindAll())
                {
                    EditoraConsultaViewModel model = new EditoraConsultaViewModel();
                    model.IdEditora = e.IdEditora;
                    model.Nome = e.Nome;

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