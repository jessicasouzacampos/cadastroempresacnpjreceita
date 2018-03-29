using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroEmpresaCNPJReceita.Models
{
    [Table("Extra")]    
    public class Extra
    {
        [Key]
        public int ExtraId { get; set; }
    }
    
}