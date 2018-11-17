using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;


using Livraria.Models.Model;

namespace Livraria.Models.Repositorio
{
    public class LivrariaRep
    {
    
        // conexão com banco
        private LivrariaContext db = new LivrariaContext();

        //construtor da classe
        public LivrariaRep() 
        {
            
        }
        //retorna o objeto que possuir aquele Id expecífico.
        public LivrariaModel GetById(int id)
        {          
            // utiliza o find
            LivrariaModel aluno = db.Livros.Find(id);

            return aluno;      
        }

        //Responsável pelo cadastro de novos livros.
        public void Cadastrar(LivrariaModel livro)
        {

            // valida se o titulo já existe no sistema, caso não, dar erro.
            var validaTitulo = db.Livros.Where(Titulo => Titulo.Titulo == livro.Titulo).Count();

            // valida se o exemplar já existe no sistema, caso não, dar erro.
            var validaExemplar = db.Livros.Where(Exemplar => Exemplar.Exemplar == livro.Exemplar).Count();

            if (validaTitulo > 0 && validaExemplar > 0 )
            {
                throw new Exception("Título já existe no sistema!");
            }

            if (validaExemplar > 0)
            {
                throw new Exception("Exemplar já existe no sistema!");
            }

            //adicionar e salva o livro
            db.Livros.Add(livro);
            db.SaveChanges();
           
           
        }

        //responsável por verificar uma livro existente
        //e atualizar os dados
        public void Atualizar(LivrariaModel livro)
        {

            // validações com o novo livro.
            var validaTitulo = db.Livros.Where(Titulo => Titulo.Titulo == livro.Titulo).Count();

            var validaExemplar = db.Livros.Where(Exemplar => Exemplar.Exemplar == livro.Exemplar).Count();

            if (validaTitulo > 0 && validaExemplar > 0)
            {
                throw new Exception("Título já existe no sistema!");
            }

            if (validaExemplar > 0)
            {
                throw new Exception("Exemplar já existe no sistema!");
            }

           //obtem o livro já existente
            var livroDadoAnterior = GetById(livro.Id);
            if (livroDadoAnterior != null)
            {
              
                foreach (var propertyInfo in typeof(LivrariaModel)
                    .GetProperties().Where(x => x.Name != "Id"))
                {
                
                    propertyInfo.SetValue(livroDadoAnterior, propertyInfo.GetValue(livro));
                }
            }
            db.SaveChanges();
        }
        //responsável por remover um item
        public void Deletar(int id)
        {       
            // localiza e remove
            LivrariaModel livro = db.Livros.Find(id);
            db.Livros.Remove(livro);
            db.SaveChanges();
          
        }

        private void RedirectToAction(string v)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LivrariaModel> Listar()
        {         
                return db.Livros.ToList().OrderBy(i => i.Titulo);                       
        }
    }
}