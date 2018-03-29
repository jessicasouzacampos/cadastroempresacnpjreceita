using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CadastroEmpresaCNPJReceita.Models
{
    public class CadastroEmpresaCNPJReceitaContext : DbContext
    {
      
        public CadastroEmpresaCNPJReceitaContext()
            : base("DefaultConnection")
        {
        }

        static CadastroEmpresaCNPJReceitaContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            // Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static CadastroEmpresaCNPJReceitaContext Create()
        {
            return new CadastroEmpresaCNPJReceitaContext();
        }
       
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<Qsa> Qsas { get; set; }
        public DbSet<AtividadePrincipal> AtividadesPrincipais { get; set; }
        public DbSet<AtividadeSecundaria> AtividadesSecundarias { get; set; }

    }
}