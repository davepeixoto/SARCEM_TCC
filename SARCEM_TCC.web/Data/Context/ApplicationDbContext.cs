using Microsoft.AspNet.Identity.EntityFramework;
using SARCEM_TCC.web.Data.Configs;
using SARCEM_TCC.web.Data.Configs.SqlViews;
using SARCEM_TCC.web.Models;
using SARCEM_TCC.web.Models.Domain;
using SARCEM_TCC.web.Models.Domain.DataMass;
using SARCEM_TCC.web.Models.Domain.DataMass.QuickChangeMass;
using SARCEM_TCC.web.Models.Domain.DataMass.Report.TempTable;
using SARCEM_TCC.web.Models.Domain.DataMass.Report.View;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SARCEM_TCC.web.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()

           : base("logistica", throwIfV1Schema: false)
        {
            this.Database.CommandTimeout = 600;
        }


        //Classes Domínio
        public DbSet<BaseCotacao> BaseCotacoes { get; set; }
        public DbSet<CentroLogistico> CentrosLogisticos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<ClasseAvaliacao> ClasseAvaliacoes { get; set; }
        public DbSet<Classificacao> Classificacoes { get; set; }
        public DbSet<CondicaoDePagamento> CondicaoDePagamentos { get; set; }
        public DbSet<Diretoria> Diretorias { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<MGCode> MGCodes { get; set; }
        public DbSet<MovimentoEstoque> MovimentoEstoques { get; set; }
        public DbSet<MovimentoSapN1> MovimentoSapN1s { get; set; }
        public DbSet<MovimentoSapN2> MovimentoSapN2s { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<SubDiretoria> SubDiretorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioCliente> UsuarioClientes { get; set; }
        public DbSet<UsuarioLogistica> UsuarioLogisticas { get; set; }
        public DbSet<UsuarioLogisticaAtividade> UsuarioLogisticaAtividades { get; set; }
        public DbSet<HistoricoMaterial> HistoricoMateriais { get; set; }



        // Classes DataMass
        public DbSet<Ajuste2015> Ajuste2015s { get; set; }
        public DbSet<Appia> Appias { get; set; }
        public DbSet<BaseGiro> BaseGiros { get; set; }
        public DbSet<Ceco> Cecos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Giro> Giros { get; set; }
        public DbSet<HistoricoDeCompra> HistoricoDeCompras { get; set; }
        public DbSet<Mb51> Mb51s { get; set; }
        public DbSet<Me2m> Me2ms { get; set; }
        public DbSet<Mm60> Mm60s { get; set; }
        public DbSet<Ordem> Ordens { get; set; }
        public DbSet<Plm> Plms { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Zmov> Zmovs { get; set; }
        public DbSet<Zpi04> Zpi04s { get; set; }
        public DbSet<ReferenciaDePreco> ReferenciaDePrecos { get; set; }


        // Classes QuickChangeMass
        public DbSet<Contrato> Contratos { get; set; }
       
        public DbSet<ItemDoContrato> ItemDosContratos { get; set; }
        public DbSet<Mb52> Mb52s { get; set; }
        public DbSet<Zmep> Zmeps { get; set; }
        public DbSet<PedidoDeCompra> PedidoDeCompras { get; set; }
        public DbSet<ItemPedidoDeCompra> ItemPedidoDeCompras { get; set; }
        public DbSet<ZmepMensalizado> ZmepMensalizados { get; set; }


        // Report.TempTable
        public DbSet<PlmMensalizado> PlmMensalizados { get; set; }
        public DbSet<PlmMensalizadoLastYear> PlmMensalizadoLastYears { get; set; }
       // public DbSet<AppiaQuery> AppiaQuerys { get; set; }
        public DbSet<GiroFechamentoMensal> GiroFechamentosMensais { get;set;}

     
        public DbSet<ValorReferencia> ValorReferencias { get; set; }
    
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

    


            modelBuilder.Entity<IdentityUserRole>().Property(c => c.UserId).HasMaxLength(128);
            modelBuilder.Entity<IdentityUserLogin>().Property(c => c.UserId).HasMaxLength(128);
            modelBuilder.Entity<IdentityUserClaim>().Property(c => c.UserId).HasMaxLength(128);
            modelBuilder.Entity<IdentityUserClaim>().Property(c => c.ClaimType).HasMaxLength(8000);
            modelBuilder.Entity<IdentityUserClaim>().Property(c => c.ClaimValue).HasMaxLength(8000);

            


            base.OnModelCreating(modelBuilder);

            modelBuilder.Properties<decimal>().Configure(c => c.HasColumnType("money"));

            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(150));

            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("varchar"));

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<VF0b1>()
                .HasKey(f => f.MaterialID);

     

            modelBuilder.Configurations.Add(new BaseCotacaoConfig());
            modelBuilder.Configurations.Add(new CentroLogisticoConfig());
            modelBuilder.Configurations.Add(new CidadeConfig());
            modelBuilder.Configurations.Add(new ClasseAvaliacaoConfig());
            modelBuilder.Configurations.Add(new ClassificacaoConfig());
            modelBuilder.Configurations.Add(new CondicaoDePagamentoConfig());
            modelBuilder.Configurations.Add(new DiretoriaConfig());
            modelBuilder.Configurations.Add(new EmpresaConfig());
            modelBuilder.Configurations.Add(new EstadoConfig());
            modelBuilder.Configurations.Add(new FamiliaConfig());
            modelBuilder.Configurations.Add(new MaterialConfig());
            modelBuilder.Configurations.Add(new MGCodeConfig());
            modelBuilder.Configurations.Add(new MovimentoEstoqueConfig());
            modelBuilder.Configurations.Add(new MovimentoSapN1Config());
            modelBuilder.Configurations.Add(new MovimentoSapN2Config());
            modelBuilder.Configurations.Add(new PaisConfig());
            modelBuilder.Configurations.Add(new SubDiretoriaConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new HistoricoMaterialConfig());
            modelBuilder.Configurations.Add(new ReferenciaDePrecoConfig());
            modelBuilder.Configurations.Add(new Ajuste2015Config());
            modelBuilder.Configurations.Add(new AppiaConfig());
            modelBuilder.Configurations.Add(new BaseGiroConfig());
            modelBuilder.Configurations.Add(new CecoConfig());
            modelBuilder.Configurations.Add(new EstoqueConfig());
            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new GiroConfig());
            modelBuilder.Configurations.Add(new HistoricoDeCompraConfig());
            modelBuilder.Configurations.Add(new Mb51Config());
            modelBuilder.Configurations.Add(new Me2mConfig());
            modelBuilder.Configurations.Add(new Mm60Config());
            modelBuilder.Configurations.Add(new OrdemConfig());
            modelBuilder.Configurations.Add(new PlmConfig());
            modelBuilder.Configurations.Add(new ReservaConfig());
            modelBuilder.Configurations.Add(new ZmovConfig());
            modelBuilder.Configurations.Add(new Zpi04Config());
            modelBuilder.Configurations.Add(new HistoricoPlmConfig());


            //// Classes QuickChangeMass
            modelBuilder.Configurations.Add(new ContratoConfig());
            modelBuilder.Configurations.Add(new ItemDoContratoConfig());
            modelBuilder.Configurations.Add(new Mb52Config());
            modelBuilder.Configurations.Add(new ZmepConfig());
            modelBuilder.Configurations.Add(new PedidoDeCompraConfig());
            modelBuilder.Configurations.Add(new ItemPedidoDeCompraConfig());
            modelBuilder.Configurations.Add(new ZmepMensalizadoConfig());

            //// Report
            //// Report.TempTable
            modelBuilder.Configurations.Add(new PlmMensalizadoConfig());
            modelBuilder.Configurations.Add(new PlmMensalizadoLastYearConfig());
            modelBuilder.Configurations.Add(new GiroFechamentoMensalConfig());

            ////Report.View
            modelBuilder.Configurations.Add(new ValorReferenciaConfig());


        }


    }
}