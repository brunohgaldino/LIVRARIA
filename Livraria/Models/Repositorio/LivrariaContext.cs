using Livraria.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Livraria.Models.Repositorio
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext() : base("Livraria")
        {
            //cria a tabela caso não exista
            Database.CreateIfNotExists();
        }

        public DbSet<LivrariaModel> Livros { get; set; }
    }
}