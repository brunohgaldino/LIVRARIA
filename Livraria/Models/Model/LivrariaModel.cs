using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Livraria.Models.Model
{
    [Table("Livros")]
    public class LivrariaModel
    {   
       // modelo com os campos da tabela de livros
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }      
        public String Titulo { get; set; }
        public String Autor { get; set; }       
        public int Exemplar { get; set; }
    }

}