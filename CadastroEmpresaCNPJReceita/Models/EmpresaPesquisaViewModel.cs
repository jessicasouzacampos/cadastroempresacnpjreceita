using CodingCraftHOMod1Ex1EF.Atributos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroEmpresaCNPJReceita.Models
{
    public class EmpresaPesquisaViewModel
    {
        public EmpresaPesquisaViewModel()
        {
            CNPJ = null;
        }

        [Display(Name = "Status")]
        public String Status { get; set; }

        [Display(Name = "CNPJ")]
        [DataType(DataType.Currency)]
        [Cnpj]
        public String CNPJ { get; set; }
        
        public IEnumerable<Empresa> Resultados { get; set; }
    }
}