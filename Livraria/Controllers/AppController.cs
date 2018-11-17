using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Livraria.Models.Model;
using Livraria.Models.Negocio;

namespace Livraria.Controllers
{

    public class AppController : Controller
    {
        // GET: 
        //ACTION
        public ActionResult Index()
        {
            return View();

        }

        // cadastro
        [HttpPost]
        public void Cadastrar(LivrariaModel livro)
        {
            try
            {
                if (string.IsNullOrEmpty(livro.Titulo))
                    throw new Exception("Título Obrigatório");

                if (string.IsNullOrEmpty(livro.Autor))
                    throw new Exception("Autor Obrigatório");

                if (livro.Exemplar == default(int) || livro.Exemplar == null)
                        throw new Exception("Exemplar Obrigatório");

                new LivrariaNeg().Cadastrar(livro);
          
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                var livro = new LivrariaNeg().GetById(id);
              //retorno em Json
                return Json(livro, JsonRequestBehavior.AllowGet);


            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost]
        public void Atualizar(LivrariaModel livro)
        {
            try
            {
                new LivrariaNeg().Atualizar(livro);

            }
            catch (Exception)
            {

                throw;
            }

        }


        public void Deletar(int id)
        {
            try
            {
                new LivrariaNeg().Deletar(id);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ActionResult Listar()
        {
            try
            {
                var listLivros = new LivrariaNeg().Listar();
            
                return Json(listLivros, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }




    }



}