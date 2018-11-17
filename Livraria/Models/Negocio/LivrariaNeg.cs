
using Livraria.Models.Model;


using Livraria.Models.Repositorio;

using System.Collections.Generic;

namespace Livraria.Models.Negocio
{
    public class LivrariaNeg
    {
        public void Cadastrar(LivrariaModel livro)
        {
            new LivrariaRep().Cadastrar(livro);
        }

        public void Atualizar(LivrariaModel livro)
        {
            new LivrariaRep().Atualizar(livro);
        }

        public void Deletar(int id)
        {
            new LivrariaRep().Deletar(id);
        }

        public LivrariaModel GetById(int id)
        {
            return new LivrariaRep().GetById(id);
        }
        public IEnumerable<LivrariaModel> Listar()
        {
            return new LivrariaRep().Listar();
        }
    }
}