using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CadastroEmpresaCNPJReceita.Models
{
    [Table("AtividadeSecundaria")]
    public class AtividadeSecundaria
    {
        [Key]
        public int AtividadeSecundariaId { get; set; }

        [JsonProperty(PropertyName = "code")]
        public String CNAE { get; set; }

        [JsonProperty(PropertyName = "text")]
        public String DescricaoAtividade { get; set; }
    }
}