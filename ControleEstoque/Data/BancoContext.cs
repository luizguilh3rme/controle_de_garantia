using ControleEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Data
{
    public class BancoContext : DbContext
    {
        //Método construtor do banco de dados
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<OntModel> Onts { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<W5Model> W5 { get; set; }
        public DbSet<OnuIntelbrasModel> OnuIntelbras { get; set; }
    }
}
