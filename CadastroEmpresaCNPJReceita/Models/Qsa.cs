using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroEmpresaCNPJReceita.Models
{
    [Table("Qsa")]
    public class Qsa
    {
        [Key]
        public int QsaId { get; set; }
        public string qual { get; set; }
        public string nome { get; set; }
    }
    
}