using Br.Com.Fiap.Domain.Entidades;
using Br.Com.Fiap.Infra.Config;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Infra.Data
{
    public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new TipoUsuarioConfig());
            modelBuilder.ApplyConfiguration(new PerfilConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new EnderecoConfig());
            modelBuilder.ApplyConfiguration(new ConsorcioConfig());
            modelBuilder.ApplyConfiguration(new PrevidenciaConfig());
            modelBuilder.ApplyConfiguration(new PedidoConfig());
            modelBuilder.ApplyConfiguration(new LanceConfig());
            modelBuilder.ApplyConfiguration(new PagamentoConfig());
            modelBuilder.ApplyConfiguration(new ResgateConfig());
        }

        public DbSet<Perfil> Perfis { get; set; }

        public DbSet<TipoUsuario> TiposUsuarios { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Consorcio> Consorcios { get; set; }

        public DbSet<Previdencia> Previdencias { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Lance> Lances { get; set; }

        public DbSet<Resgate> Resgates { get; set; }

        public DbSet<Pagamento> Pagamentos { get; set; }


    }
}
