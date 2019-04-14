namespace SARCEM_TCC.web.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ajuste2015s",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CentroLogisticoID = c.Int(nullable: false),
                        MaterialID = c.Int(nullable: false),
                        ClassificacaoID = c.Int(nullable: false),
                        Ajuste2015QuantidadeConsumida = c.Decimal(storeType: "money"),
                        Ajuste2015MontanteConsumido = c.Decimal(storeType: "money"),
                        Ajuste2015QuantidadeEmEstoque = c.Decimal(storeType: "money"),
                        Ajuste2015MontanteEmEstoque = c.Decimal(storeType: "money"),
                        Ajuste2015CodigoPeriodo = c.Int(),
                        Ajuste2015Periodo = c.Int(),
                        Ajuste2015ADM = c.String(maxLength: 3, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CentrosLogisticos", t => t.CentroLogisticoID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .ForeignKey("dbo.Classificacoes", t => t.ClassificacaoID)
                .Index(t => t.CentroLogisticoID)
                .Index(t => t.MaterialID)
                .Index(t => t.ClassificacaoID);
            
            CreateTable(
                "dbo.CentrosLogisticos",
                c => new
                    {
                        CentroLogisticoID = c.Int(nullable: false, identity: false),
                        CentroLogisticoCodSap = c.String(maxLength: 4, unicode: false),
                        CentroLogisticoNome = c.String(maxLength: 150, unicode: false),
                        Endereco = c.String(maxLength: 150, unicode: false),
                        CEP = c.String(maxLength: 150, unicode: false),
                        Complemento = c.String(maxLength: 150, unicode: false),
                        CidadeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CentroLogisticoID)
                .ForeignKey("dbo.Cidades", t => t.CidadeID)
                .Index(t => t.CidadeID);
            
            CreateTable(
                "dbo.BaseGiros",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        EmpresaID = c.Long(),
                        CentroLogisticoID = c.Int(),
                        BaseGiroTipoCentro = c.String(maxLength: 50, unicode: false),
                        MaterialID = c.Int(),
                        BaseGiroConsQtde = c.Decimal(storeType: "money"),
                        BaseGiroConsValor = c.Decimal(storeType: "money"),
                        BaseGiroEstqQtde = c.Decimal(storeType: "money"),
                        BaseGiroEstqValor = c.Decimal(storeType: "money"),
                        BaseGiroEquivalente = c.Int(),
                        BaseGiroPeriodo = c.Int(),
                        BaseGiroClass = c.Int(),
                        BaseGiroAdm = c.String(maxLength: 5, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CentrosLogisticos", t => t.CentroLogisticoID)
                .ForeignKey("dbo.Empresas", t => t.EmpresaID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .Index(t => t.EmpresaID)
                .Index(t => t.CentroLogisticoID)
                .Index(t => t.MaterialID);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        EmpresaID = c.Long(nullable: false, identity: false),
                        EmpresaNome = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.EmpresaID);
            
            CreateTable(
                "dbo.Cecos",
                c => new
                    {
                        CecoID = c.Long(nullable: false, identity: false),
                        CecoCodSap = c.String(maxLength: 10, unicode: false),
                        CecoSigla = c.String(maxLength: 10, unicode: false),
                        CecoGerencia = c.String(maxLength: 80, unicode: false),
                        CecoDescricao = c.String(maxLength: 80, unicode: false),
                        EmpresaID = c.Long(nullable: false),
                        CecoProjeto = c.String(maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.CecoID)
                .ForeignKey("dbo.Empresas", t => t.EmpresaID)
                .Index(t => t.EmpresaID);
            
            CreateTable(
                "dbo.Ordens",
                c => new
                    {
                        OrdemID = c.Long(nullable: false, identity: false),
                        OrdemCodSap = c.String(maxLength: 20, unicode: false),
                        OrdemTexto = c.String(maxLength: 150, unicode: false),
                        OrdemPEP = c.String(maxLength: 20, unicode: false),
                        CecoID = c.Long(),
                        SubDiretoriaID = c.Int(),
                        OrdemProjeto = c.String(maxLength: 150, unicode: false),
                        OrdemVerba = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.OrdemID)
                .ForeignKey("dbo.Cecos", t => t.CecoID)
                .ForeignKey("dbo.SubDiretorias", t => t.SubDiretoriaID)
                .Index(t => t.CecoID)
                .Index(t => t.SubDiretoriaID);
            
            CreateTable(
                "dbo.Mb51s",
                c => new
                    {
                        Mb51Id = c.Long(nullable: false, identity: true),
                        MaterialID = c.Int(nullable: false),
                        CentroLogisticoID = c.Int(),
                        Mb51Dep = c.Int(),
                        MovSapN1ID = c.Int(),
                        Mb51DocMat = c.String(maxLength: 150, unicode: false),
                        Mb51Itm = c.Int(),
                        Mb51TextoCabDocumento = c.String(maxLength: 150, unicode: false),
                        Mb51Reserva = c.String(maxLength: 150, unicode: false),
                        Mb51Pedido = c.String(maxLength: 150, unicode: false),
                        Mb51Referencia = c.String(maxLength: 150, unicode: false),
                        Mb51Texto = c.String(maxLength: 150, unicode: false),
                        Mb51Tipo = c.String(maxLength: 150, unicode: false),
                        Mb51DataDocumento = c.DateTime(),
                        Mb51DataLancamento = c.DateTime(),
                        OrdemID = c.Long(),
                        Mb51PtoDescarga = c.String(maxLength: 150, unicode: false),
                        Mb51QtdUMReg = c.Decimal(storeType: "money"),
                        Mb51Lote = c.String(maxLength: 150, unicode: false),
                        Mb51MontanteMI = c.Decimal(storeType: "money"),
                        Mb51Periodo = c.Int(),
                        Mb51Equivalente = c.Int(),
                        Mb51Expurgado = c.String(maxLength: 2, unicode: false),
                        Mb51DataLanc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Mb51Id)
                .ForeignKey("dbo.CentrosLogisticos", t => t.CentroLogisticoID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .ForeignKey("dbo.Ordens", t => t.OrdemID)
                .ForeignKey("dbo.MovimentoSapN1s", t => t.MovSapN1ID)
                .Index(t => t.MaterialID)
                .Index(t => t.CentroLogisticoID)
                .Index(t => t.MovSapN1ID)
                .Index(t => t.OrdemID);
            
            CreateTable(
                "dbo.Materiais",
                c => new
                    {
                        MaterialID = c.Int(nullable: false, identity: false),
                        MaterialCodSap = c.String(maxLength: 10, unicode: false),
                        MaterialDescricao = c.String(maxLength: 150, unicode: false),
                        MaterialClasse = c.String(maxLength: 2, unicode: false),
                        MaterialUM = c.String(maxLength: 5, unicode: false),
                        ClassificacaoID = c.Int(nullable: false),
                        FamiliaID = c.Int(nullable: false),
                        MGCodeID = c.Int(nullable: false),
                        MaterialDataInclusao = c.DateTime(nullable: false),
                        MaterialSubId = c.Int(),
                        MaterialBloqueado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialID)
                .ForeignKey("dbo.Classificacoes", t => t.ClassificacaoID)
                .ForeignKey("dbo.Familias", t => t.FamiliaID)
                .ForeignKey("dbo.Materiais", t => t.MaterialSubId)
                .ForeignKey("dbo.MGCodes", t => t.MGCodeID)
                .Index(t => t.ClassificacaoID)
                .Index(t => t.FamiliaID)
                .Index(t => t.MGCodeID)
                .Index(t => t.MaterialSubId);
            
            CreateTable(
                "dbo.Appias",
                c => new
                    {
                        AppiaID = c.Long(nullable: false, identity: true),
                        MaterialID = c.Int(),
                        DiretoriaID = c.Int(),
                        SubDiretoriaID = c.Int(),
                        AppiaProjeto = c.String(maxLength: 200, unicode: false),
                        AppiaInfoAdicional = c.String(maxLength: 200, unicode: false),
                        AppiaResponsavel = c.String(maxLength: 200, unicode: false),
                        UsuarioClienteId = c.String(maxLength: 128, unicode: false),
                        AppiaQuantidade = c.Decimal(storeType: "money"),
                        AppiaAno = c.Int(),
                        AppiaDataLanc = c.DateTime(),
                        MaterialCodSap = c.String(maxLength: 10, unicode: false),
                        CentroLogisticoCodSap = c.String(maxLength: 4, unicode: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AppiaID)
                .ForeignKey("dbo.Diretorias", t => t.DiretoriaID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .ForeignKey("dbo.SubDiretorias", t => t.SubDiretoriaID)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioClienteId)
                .Index(t => t.MaterialID)
                .Index(t => t.DiretoriaID)
                .Index(t => t.SubDiretoriaID)
                .Index(t => t.UsuarioClienteId);
            
            CreateTable(
                "dbo.Diretorias",
                c => new
                    {
                        DiretoriaID = c.Int(nullable: false, identity: false),
                        DiretoriaNome = c.String(maxLength: 150, unicode: false),
                        EmpresaID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.DiretoriaID)
                .ForeignKey("dbo.Empresas", t => t.EmpresaID)
                .Index(t => t.EmpresaID);
            
            CreateTable(
                "dbo.HistoricoPlms",
                c => new
                    {
                        PlmID = c.Long(nullable: false, identity: true),
                        MaterialID = c.Int(),
                        CentroLogisticoID = c.Int(),
                        DiretoriaID = c.Int(),
                        SUbDiretoriaID = c.Int(),
                        PlmProjeto = c.String(maxLength: 150, unicode: false),
                        PlmInfoAdicional = c.String(maxLength: 150, unicode: false),
                        PlmResponsavel = c.String(maxLength: 150, unicode: false),
                        UsuarioClienteId = c.String(maxLength: 128, unicode: false),
                        PlmQuantidade = c.Decimal(storeType: "money"),
                        PlmPeriodo = c.Int(),
                        PlmEquivalente = c.Int(),
                        PlmDataLanc = c.DateTime(),
                    })
                .PrimaryKey(t => t.PlmID)
                .ForeignKey("dbo.CentrosLogisticos", t => t.CentroLogisticoID)
                .ForeignKey("dbo.Diretorias", t => t.DiretoriaID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .ForeignKey("dbo.SubDiretorias", t => t.SUbDiretoriaID)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioClienteId)
                .Index(t => t.MaterialID)
                .Index(t => t.CentroLogisticoID)
                .Index(t => t.DiretoriaID)
                .Index(t => t.SUbDiretoriaID)
                .Index(t => t.UsuarioClienteId);
            
            CreateTable(
                "dbo.SubDiretorias",
                c => new
                    {
                        SubDiretoriaID = c.Int(nullable: false, identity: false),
                        SubDiretoriaNome = c.String(maxLength: 150, unicode: false),
                        SubDiretoriaSigla = c.String(maxLength: 6, unicode: false),
                        DiretoriaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubDiretoriaID)
                .ForeignKey("dbo.Diretorias", t => t.DiretoriaID)
                .Index(t => t.DiretoriaID);
            
            CreateTable(
                "dbo.Plms",
                c => new
                    {
                        PlmID = c.Long(nullable: false, identity: true),
                        MaterialID = c.Int(),
                        CentroLogisticoID = c.Int(),
                        DiretoriaID = c.Int(),
                        SUbDiretoriaID = c.Int(),
                        PlmProjeto = c.String(maxLength: 150, unicode: false),
                        PlmInfoAdicional = c.String(maxLength: 150, unicode: false),
                        PlmResponsavel = c.String(maxLength: 150, unicode: false),
                        UsuarioClienteId = c.String(maxLength: 128, unicode: false),
                        PlmQuantidade = c.Decimal(storeType: "money"),
                        PlmPeriodo = c.Int(),
                        PlmEquivalente = c.Int(),
                        PlmDataLanc = c.DateTime(),
                    })
                .PrimaryKey(t => t.PlmID)
                .ForeignKey("dbo.CentrosLogisticos", t => t.CentroLogisticoID)
                .ForeignKey("dbo.Diretorias", t => t.DiretoriaID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .ForeignKey("dbo.SubDiretorias", t => t.SUbDiretoriaID)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioClienteId)
                .Index(t => t.MaterialID)
                .Index(t => t.CentroLogisticoID)
                .Index(t => t.DiretoriaID)
                .Index(t => t.SUbDiretoriaID)
                .Index(t => t.UsuarioClienteId);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128, unicode: false),
                    Email = c.String(nullable: false, maxLength: 256, unicode: false),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(maxLength: 150, unicode: false),
                    SecurityStamp = c.String(maxLength: 150, unicode: false),
                    PhoneNumber = c.String(maxLength: 150, unicode: false),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256, unicode: false),
                    UserBR = c.String(maxLength: 15, unicode: false),
                    EmpresaID = c.Long(),
                    DiretoriaID = c.Int(),
                    UsuarioLogisticaAtividadeID = c.Int(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diretorias", t => t.DiretoriaID)
                .ForeignKey("dbo.UsuarioLogisticaAtividades", t => t.UsuarioLogisticaAtividadeID)
                .ForeignKey("dbo.Empresas", t => t.EmpresaID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.EmpresaID)
                .Index(t => t.DiretoriaID)
                .Index(t => t.UsuarioLogisticaAtividadeID);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, unicode: false),
                        ClaimType = c.String(maxLength: 8000, unicode: false),
                        ClaimValue = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 150, unicode: false),
                        ProviderKey = c.String(nullable: false, maxLength: 150, unicode: false),
                        UserId = c.String(nullable: false, maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, unicode: false),
                        RoleId = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Classificacoes",
                c => new
                    {
                        ClassificacaoID = c.Int(nullable: false, identity: false),
                        ClassificacaoNome = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.ClassificacaoID);
            
            CreateTable(
                "dbo.Estoques",
                c => new
                    {
                        EstoqueID = c.Long(nullable: false, identity: true),
                        CentroLogisticoID = c.Int(nullable: false),
                        MaterialID = c.Int(nullable: false),
                        EstoqueQtde = c.Decimal(nullable: false, storeType: "money"),
                        EstoqueValor = c.Decimal(storeType: "money"),
                        EstoqueAdmin = c.String(maxLength: 3, unicode: false),
                        EstoquePeriodo = c.Int(),
                        EstoqueEquivalente = c.Int(),
                        ClassificacaoID = c.Int(),
                        EstoqueExpurgado = c.String(maxLength: 3, unicode: false),
                        ClasseAvaliacaoID = c.String(maxLength: 6, unicode: false),
                    })
                .PrimaryKey(t => t.EstoqueID)
                .ForeignKey("dbo.CentrosLogisticos", t => t.CentroLogisticoID)
                .ForeignKey("dbo.ClasseAvaliacoes", t => t.ClasseAvaliacaoID)
                .ForeignKey("dbo.Classificacoes", t => t.ClassificacaoID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .Index(t => t.CentroLogisticoID)
                .Index(t => t.MaterialID)
                .Index(t => t.ClassificacaoID)
                .Index(t => t.ClasseAvaliacaoID);
            
            CreateTable(
                "dbo.ClasseAvaliacoes",
                c => new
                    {
                        ClasseAvaliacaoID = c.String(nullable: false, maxLength: 6, unicode: false),
                        ClasseAvaliacaoDescricao = c.String(maxLength: 150, unicode: false),
                        ClasseAvaliacaoContaRazao = c.String(maxLength: 20, unicode: false),
                        ClasseAvaliacaoTipo = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.ClasseAvaliacaoID);
            
            CreateTable(
                "dbo.Giros",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CentroLogisticoID = c.Int(nullable: false),
                        MaterialID = c.Int(nullable: false),
                        giroConsQtde = c.Decimal(nullable: false, storeType: "money"),
                        giroConsValor = c.Decimal(nullable: false, storeType: "money"),
                        giroEstqQtde = c.Decimal(nullable: false, storeType: "money"),
                        giroEstqValor = c.Decimal(nullable: false, storeType: "money"),
                        giroEquivalente = c.Int(nullable: false),
                        giroPeriodo = c.Long(nullable: false),
                        ClassificacaoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CentrosLogisticos", t => t.CentroLogisticoID)
                .ForeignKey("dbo.Classificacoes", t => t.ClassificacaoID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .Index(t => t.CentroLogisticoID)
                .Index(t => t.MaterialID)
                .Index(t => t.ClassificacaoID);
            
            CreateTable(
                "dbo.Zmovs",
                c => new
                    {
                        ZmovID = c.Long(nullable: false, identity: true),
                        ZmovFecDocum = c.DateTime(),
                        ZmovDocMat = c.String(maxLength: 20, unicode: false),
                        ZmovPos1 = c.Int(),
                        CentroLogisticoID = c.Int(),
                        ZmovAlm = c.Int(),
                        ZmovLote = c.String(maxLength: 20, unicode: false),
                        MaterialID = c.Int(),
                        ZmovCodigoAntiguo = c.String(maxLength: 20, unicode: false),
                        ZmovGr = c.String(maxLength: 5, unicode: false),
                        ZmovCantidad = c.Decimal(storeType: "money"),
                        ZmovE1 = c.String(maxLength: 5, unicode: false),
                        ZmovCMO = c.String(maxLength: 5, unicode: false),
                        ZmovE2 = c.String(maxLength: 5, unicode: false),
                        ZmovProv = c.String(maxLength: 20, unicode: false),
                        ZmovPedido = c.String(maxLength: 20, unicode: false),
                        ZmovPos2 = c.Int(),
                        OrdemID = c.Long(),
                        ZmovTexto = c.String(maxLength: 100, unicode: false),
                        ZmovImpEnt = c.Decimal(storeType: "money"),
                        ZmovImpSal = c.Decimal(storeType: "money"),
                        ZmovNombreDelU = c.String(maxLength: 20, unicode: false),
                        ZmovQtde = c.Decimal(storeType: "money"),
                        ZmovValor = c.Decimal(storeType: "money"),
                        ZmovPeriodo = c.Int(),
                        ZmovEquivalente = c.Int(),
                        ClassificacaoID = c.Int(),
                        ZmovExpurgado = c.String(maxLength: 2, unicode: false),
                        ZmovDataLanc = c.DateTime(),
                    })
                .PrimaryKey(t => t.ZmovID)
                .ForeignKey("dbo.CentrosLogisticos", t => t.CentroLogisticoID)
                .ForeignKey("dbo.Classificacoes", t => t.ClassificacaoID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .ForeignKey("dbo.Ordens", t => t.OrdemID)
                .Index(t => t.CentroLogisticoID)
                .Index(t => t.MaterialID)
                .Index(t => t.OrdemID)
                .Index(t => t.ClassificacaoID);
            
            CreateTable(
                "dbo.Familias",
                c => new
                    {
                        FamiliaID = c.Int(nullable: false, identity: false),
                        FamiliaNome = c.String(maxLength: 150, unicode: false),
                        UsuarioLogisticaID = c.String(maxLength: 128, unicode: false),
                        EmpresaID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.FamiliaID)
                .ForeignKey("dbo.Empresas", t => t.EmpresaID)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioLogisticaID)
                .Index(t => t.UsuarioLogisticaID)
                .Index(t => t.EmpresaID);
            
            CreateTable(
                "dbo.HistoricoMateriais",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HistMatInformacoes = c.String(maxLength: 150, unicode: false),
                        HistMatDataLanc = c.DateTime(nullable: false),
                        MaterialID = c.Int(nullable: false),
                        UsuarioLogisticaID = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioLogisticaID)
                .Index(t => t.MaterialID)
                .Index(t => t.UsuarioLogisticaID);
            
            CreateTable(
                "dbo.ReferenciaDePrecos",
                c => new
                    {
                        PrecoId = c.Int(nullable: false, identity: true),
                        MaterialID = c.Int(nullable: false),
                        PrecoValor = c.Decimal(nullable: false, storeType: "money"),
                        PrecoDataLanc = c.DateTime(nullable: false),
                        UsuarioId = c.String(nullable: false, maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.PrecoId)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.MaterialID)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.UsuarioLogisticaAtividades",
                c => new
                    {
                        UsuarioLogisticaAtividadeID = c.Int(nullable: false, identity: false),
                        UsuarioLogisticaAtividadeNome = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.UsuarioLogisticaAtividadeID);
            
            CreateTable(
                "dbo.HistoricoDeCompras",
                c => new
                    {
                        HistCompID = c.Long(nullable: false, identity: true),
                        MaterialID = c.Int(nullable: false),
                        HistCompDataPedido = c.DateTime(),
                        HistCompResponsavel = c.String(maxLength: 80, unicode: false),
                        HistCompODC = c.String(maxLength: 20, unicode: false),
                        HistCompItem = c.Int(),
                        HistCompQuant = c.Decimal(storeType: "money"),
                        HistCompPreco_semImpostos = c.Decimal(storeType: "money"),
                        HistCompICMS = c.Decimal(storeType: "money"),
                        HistCompIPI = c.Decimal(storeType: "money"),
                        HistCompPreco_comICMS_semIPI = c.Decimal(storeType: "money"),
                        HistCompMoeda = c.String(maxLength: 150, unicode: false),
                        FornecedorID = c.Long(),
                        HistCompPreco_emDolar = c.Decimal(storeType: "money"),
                        HistCompPreco_emRS_semICMS_comIPI = c.Decimal(storeType: "money"),
                        HistCompDolar_doDia = c.Decimal(storeType: "money"),
                        HistCompValor_IPI = c.Decimal(storeType: "money"),
                        HistCompValor_ICMS = c.Decimal(storeType: "money"),
                        HistCompP_x_Q_emRS = c.Decimal(storeType: "money"),
                        HistCompP_x_Q_emUS = c.Decimal(storeType: "money"),
                        HistCompYBR = c.Decimal(storeType: "money"),
                        HistCompGrC = c.String(maxLength: 80, unicode: false),
                        HistCompDataLanc = c.DateTime(),
                    })
                .PrimaryKey(t => t.HistCompID)
                .ForeignKey("dbo.Fornecedores", t => t.FornecedorID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .Index(t => t.MaterialID)
                .Index(t => t.FornecedorID);
            
            CreateTable(
                "dbo.Fornecedores",
                c => new
                    {
                        FornecedorID = c.Long(nullable: false, identity: false),
                        FornecedorNome = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.FornecedorID);
            
            CreateTable(
                "dbo.Contratos",
                c => new
                    {
                        ContratoID = c.Long(nullable: false, identity: false),
                        ContratoNumero = c.String(maxLength: 20, unicode: false),
                        ContratoDataDoc = c.DateTime(),
                        ContratoTipo = c.String(maxLength: 10, unicode: false),
                        ContratoIniPrazo = c.DateTime(),
                        ContratoFimValidade = c.DateTime(),
                        ContratoGCm = c.String(maxLength: 10, unicode: false),
                        BaseCotacaoID = c.Int(),
                        ContratoValFixado = c.Decimal(storeType: "money"),
                        ContratoValGlPend = c.Decimal(storeType: "money"),
                        FornecedorID = c.Long(),
                        ContratoDataLanc = c.DateTime(),
                        ContratoDataAlteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.ContratoID)
                .ForeignKey("dbo.BaseCotacoes", t => t.BaseCotacaoID)
                .ForeignKey("dbo.Fornecedores", t => t.FornecedorID)
                .Index(t => t.BaseCotacaoID)
                .Index(t => t.FornecedorID);
            
            CreateTable(
                "dbo.BaseCotacoes",
                c => new
                    {
                        BaseCotacaoID = c.Int(nullable: false, identity: false),
                        BaseCotacaoNome = c.String(maxLength: 100, unicode: false),
                        BaseCotacaoSigla = c.String(maxLength: 100, unicode: false),
                        BaseCotacaoValor = c.Decimal(nullable: false, storeType: "money"),
                        BaseCotacaoDataDaCotacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.BaseCotacaoID);
            
            CreateTable(
                "dbo.PedidoDeCompras",
                c => new
                    {
                        PedidoDeCompraId = c.Long(nullable: false, identity: false),
                        EmpresaId = c.Long(),
                        Pedido = c.String(maxLength: 20, unicode: false),
                        DataCriacao = c.DateTime(),
                        Tipo = c.String(maxLength: 10, unicode: false),
                        OrgDeCompra = c.String(maxLength: 10, unicode: false),
                        FornecedorId = c.Long(),
                        Criador = c.String(maxLength: 30, unicode: false),
                        CondicaoDePagamentoID = c.Int(),
                        BaseCotacaoID = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.PedidoDeCompraId)
                .ForeignKey("dbo.CondicaoDePagamentos", t => t.CondicaoDePagamentoID)
                .ForeignKey("dbo.Empresas", t => t.EmpresaId)
                .ForeignKey("dbo.Fornecedores", t => t.FornecedorId)
                .ForeignKey("dbo.BaseCotacoes", t => t.BaseCotacaoID)
                .Index(t => t.EmpresaId)
                .Index(t => t.FornecedorId)
                .Index(t => t.CondicaoDePagamentoID)
                .Index(t => t.BaseCotacaoID);
            
            CreateTable(
                "dbo.CondicaoDePagamentos",
                c => new
                    {
                        CondicaoDePagamentoID = c.Int(nullable: false, identity: false),
                        CondicaoDePagamentoCodSap = c.String(maxLength: 6, unicode: false),
                        CondicaoDePagamentoDescricao = c.String(maxLength: 285, unicode: false),
                    })
                .PrimaryKey(t => t.CondicaoDePagamentoID);
            
            CreateTable(
                "dbo.Zmeps",
                c => new
                    {
                        ZmepID = c.Long(nullable: false, identity: true),
                        ZmepPedido = c.String(maxLength: 20, unicode: false),
                        ZmepPos = c.Int(nullable: false),
                        MaterialID = c.Int(nullable: false),
                        ZmepDataEntrg = c.DateTime(),
                        ZmepQtdePedido = c.Decimal(nullable: false, storeType: "money"),
                        ZmepQtdeEmPend = c.Decimal(storeType: "money"),
                        ZmepImpPedido = c.Decimal(storeType: "money"),
                        ZmepImpEmPend = c.Decimal(storeType: "money"),
                        BaseCotacaoID = c.Int(nullable: false),
                        FornecedorID = c.Long(),
                        ContratoID = c.Long(),
                        ZmepDataDaCompra = c.DateTime(nullable: false),
                        CondicaoDePagamentoID = c.Int(nullable: false),
                        ZmepDataLanc = c.DateTime(nullable: false),
                        ZmepCentroImputado = c.String(maxLength: 3, unicode: false),
                    })
                .PrimaryKey(t => t.ZmepID)
                .ForeignKey("dbo.CondicaoDePagamentos", t => t.CondicaoDePagamentoID)
                .ForeignKey("dbo.Contratos", t => t.ContratoID)
                .ForeignKey("dbo.Fornecedores", t => t.FornecedorID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .ForeignKey("dbo.BaseCotacoes", t => t.BaseCotacaoID)
                .Index(t => t.MaterialID)
                .Index(t => t.BaseCotacaoID)
                .Index(t => t.FornecedorID)
                .Index(t => t.ContratoID)
                .Index(t => t.CondicaoDePagamentoID);
            
            CreateTable(
                "dbo.ItemPedidoDeCompras",
                c => new
                    {
                        ItemPedidoDeCompraId = c.Long(nullable: false, identity: false),
                        PedidoDeCompraId = c.Long(nullable: false),
                        ItemPedidoDeCompraDataRemessa = c.DateTime(nullable: false),
                        ItemPedidoDeCompraElim = c.String(maxLength: 10, unicode: false),
                        ItemPedidoDeCompraItem = c.Int(nullable: false),
                        MaterialID = c.Int(),
                        CentroLogisticoID = c.Int(),
                        ItemPedidoDeCompraAvaliacao = c.String(maxLength: 50, unicode: false),
                        ItemPedidoDeCompraQtdePedida = c.Decimal(storeType: "money"),
                        ItemPedidoDeCompraValorLiquido = c.Decimal(storeType: "money"),
                        ItemPedidoDeCompraValorBruto = c.Decimal(storeType: "money"),
                        ItemPedidoDeCompraReqCompra = c.String(maxLength: 20, unicode: false),
                        ItemPedidoDeCompraItemReqCompra = c.Int(nullable: false),
                        ContratoID = c.Long(),
                        ItemPedidoDeCompraItemContrato = c.Int(),
                        ItemPedidoDeCompraValorReferencia = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.ItemPedidoDeCompraId)
                .ForeignKey("dbo.CentrosLogisticos", t => t.CentroLogisticoID)
                .ForeignKey("dbo.Contratos", t => t.ContratoID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .ForeignKey("dbo.PedidoDeCompras", t => t.PedidoDeCompraId)
                .Index(t => t.PedidoDeCompraId)
                .Index(t => t.MaterialID)
                .Index(t => t.CentroLogisticoID)
                .Index(t => t.ContratoID);
            
            CreateTable(
                "dbo.ItemDoContratos",
                c => new
                    {
                        ItemDoContratoID = c.Long(nullable: false, identity: false),
                        ContratoID = c.Long(nullable: false),
                        ItemDoContratoItm = c.Int(nullable: false),
                        MaterialID = c.Int(),
                        ItemDoContratoElim = c.String(maxLength: 10, unicode: false),
                        CentroLogisticoID = c.Int(),
                        ItemDoContratoQtdeDisp = c.Decimal(storeType: "money"),
                        ItemDoContratoQtdeContrato = c.Decimal(storeType: "money"),
                        ItemDoContratoValRef = c.Decimal(storeType: "money"),
                        ItemDoContratoDataLanc = c.DateTime(),
                        ItemDoContratoDataAlteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.ItemDoContratoID)
                .ForeignKey("dbo.CentrosLogisticos", t => t.CentroLogisticoID)
                .ForeignKey("dbo.Contratos", t => t.ContratoID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .Index(t => t.ContratoID)
                .Index(t => t.MaterialID)
                .Index(t => t.CentroLogisticoID);
            
            CreateTable(
                "dbo.Me2ms",
                c => new
                    {
                        Me2mID = c.Long(nullable: false, identity: true),
                        Me2mItem = c.Int(),
                        Me2mDataDoc = c.DateTime(),
                        Me2mDocCompra = c.String(maxLength: 150, unicode: false),
                        MaterialID = c.Int(),
                        Me2mRegInfo = c.String(maxLength: 150, unicode: false),
                        Me2mCentroOrigem = c.Int(),
                        FornecedorID = c.Long(),
                        Me2mE = c.String(maxLength: 150, unicode: false),
                        Me2mCentroRecebedor = c.Int(nullable: false),
                        Me2mDep = c.Int(),
                        Me2mQtdPedida = c.Decimal(storeType: "money"),
                        Me2mQtdeAfornecer = c.Decimal(storeType: "money"),
                        Me2mPrecoLiq = c.Decimal(storeType: "money"),
                        Me2mMoeda = c.String(maxLength: 150, unicode: false),
                        Me2mTipo = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Me2mID)
                .ForeignKey("dbo.Fornecedores", t => t.FornecedorID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .ForeignKey("dbo.CentrosLogisticos", t => t.Me2mCentroOrigem)
                .ForeignKey("dbo.CentrosLogisticos", t => t.Me2mCentroRecebedor)
                .Index(t => t.MaterialID)
                .Index(t => t.Me2mCentroOrigem)
                .Index(t => t.FornecedorID)
                .Index(t => t.Me2mCentroRecebedor);
            
            CreateTable(
                "dbo.Mb52s",
                c => new
                    {
                        Mb52ID = c.Int(nullable: false, identity: true),
                        MaterialID = c.Int(),
                        CentroLogisticoID = c.Int(nullable: false),
                        Mb52Dep = c.Int(),
                        Mb52Lote = c.String(maxLength: 50, unicode: false),
                        Mb52UtLivre = c.Decimal(storeType: "money"),
                        Mb52ValorUtLivre = c.Decimal(storeType: "money"),
                        Mb52EmTrans = c.Decimal(storeType: "money"),
                        Mb52ValorEmTrans = c.Decimal(storeType: "money"),
                        Mb52EmCQ = c.Decimal(storeType: "money"),
                        Mb52ValorEmCQ = c.Decimal(storeType: "money"),
                        Mb52Restrito = c.Decimal(storeType: "money"),
                        Mb52ValorRestrito = c.Decimal(storeType: "money"),
                        Mb52Bloqueados = c.Decimal(storeType: "money"),
                        Mb52ValorBloqueados = c.Decimal(storeType: "money"),
                        Mb52Devolucoes = c.Decimal(storeType: "money"),
                        Mb52ValorDevolucoes = c.Decimal(storeType: "money"),
                        Mb52DataLanc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Mb52ID)
                .ForeignKey("dbo.CentrosLogisticos", t => t.CentroLogisticoID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .Index(t => t.MaterialID)
                .Index(t => t.CentroLogisticoID);
            
            CreateTable(
                "dbo.MGCodes",
                c => new
                    {
                        MGCodeID = c.Int(nullable: false, identity: false),
                        MGCodeCodigoSap = c.String(maxLength: 10, unicode: false),
                        MGCodeDescricao = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.MGCodeID);
            
            CreateTable(
                "dbo.Mm60s",
                c => new
                    {
                        Mm60ID = c.Long(nullable: false, identity: true),
                        MaterialID = c.Int(nullable: false),
                        Mm60Valor = c.Decimal(storeType: "money"),
                        CentroLogisticoID = c.Int(),
                        Mm60DataUltModif = c.DateTime(),
                        Mm60Periodo = c.Int(nullable: false),
                        Mm60Equivalente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Mm60ID)
                .ForeignKey("dbo.CentrosLogisticos", t => t.CentroLogisticoID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .Index(t => t.MaterialID)
                .Index(t => t.CentroLogisticoID);
            
            CreateTable(
                "dbo.Nbs",
                c => new
                    {
                        NbID = c.Int(nullable: false, identity: true),
                        MaterialID = c.Int(),
                        CentroLogisticoID = c.Int(),
                    })
                .PrimaryKey(t => t.NbID)
                .ForeignKey("dbo.CentrosLogisticos", t => t.CentroLogisticoID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .Index(t => t.MaterialID)
                .Index(t => t.CentroLogisticoID);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        ReservaID = c.Int(nullable: false, identity: true),
                        ReservaPedido = c.String(maxLength: 150, unicode: false),
                        ReservaDataCriacao = c.DateTime(),
                        CecoID = c.Long(),
                        ReservaPos = c.Int(nullable: false),
                        MaterialID = c.Int(nullable: false),
                        ReservaQtdeOrdenada = c.Decimal(storeType: "money"),
                        ReservaQtdeDespachada = c.Decimal(storeType: "money"),
                        ReservaQtdePendente = c.Decimal(storeType: "money"),
                        CentroLogisticoID = c.Int(nullable: false),
                        OrdemID = c.Long(),
                        ReservaCodEmpreiteira = c.String(maxLength: 150, unicode: false),
                        ReservaClasseCusto = c.String(maxLength: 150, unicode: false),
                        ReservaLogin = c.String(maxLength: 150, unicode: false),
                        ReservaObs = c.String(maxLength: 150, unicode: false),
                        ReservaLote = c.String(maxLength: 150, unicode: false),
                        ReservaDataLanc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReservaID)
                .ForeignKey("dbo.Cecos", t => t.CecoID)
                .ForeignKey("dbo.CentrosLogisticos", t => t.CentroLogisticoID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .ForeignKey("dbo.Ordens", t => t.OrdemID)
                .Index(t => t.CecoID)
                .Index(t => t.MaterialID)
                .Index(t => t.CentroLogisticoID)
                .Index(t => t.OrdemID);
            
            CreateTable(
                "dbo.Zpi04s",
                c => new
                    {
                        Zpi04ID = c.Long(nullable: false, identity: true),
                        Zpi04DocumentoDeVendas = c.String(maxLength: 150, unicode: false),
                        Zpi04DataCriacao = c.DateTime(),
                        Zpi04CentroDeCusto = c.String(maxLength: 20, unicode: false),
                        Zpi04Posicao = c.Int(),
                        MaterialID = c.Int(),
                        Zpi04QuantidadeSolicitad = c.Decimal(storeType: "money"),
                        Zpi04QuantidadDespachada = c.Decimal(storeType: "money"),
                        Zpi04QuantidadeDeclive = c.Decimal(storeType: "money"),
                        Zpi04DataDespacho = c.DateTime(),
                        Zpi04GuiaDespacho = c.String(maxLength: 20, unicode: false),
                        Zpi04NumeroEntrega = c.String(maxLength: 20, unicode: false),
                        CentroLogisticoID = c.Int(),
                        OrdemID = c.Long(),
                        Zpi04CodContratista = c.Int(),
                        Zpi04MaiorAlocacaoConta = c.String(maxLength: 10, unicode: false),
                        Zpi04UsuarioDigitador = c.String(maxLength: 20, unicode: false),
                        Zpi04NumeroDoProjeto = c.String(maxLength: 20, unicode: false),
                        Zpi04QuantiaEntregue = c.Decimal(storeType: "money"),
                        Zpi04Moeda = c.String(maxLength: 150, unicode: false),
                        Zpi04ValorUnitario = c.Decimal(storeType: "money"),
                        Zpi04Periodo = c.Int(),
                        Zpi04Equivalente = c.Int(),
                        Zpi04Expurgado = c.String(maxLength: 150, unicode: false),
                        Zpi04DataLanc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Zpi04ID)
                .ForeignKey("dbo.CentrosLogisticos", t => t.CentroLogisticoID)
                .ForeignKey("dbo.Materiais", t => t.MaterialID)
                .ForeignKey("dbo.Ordens", t => t.OrdemID)
                .Index(t => t.MaterialID)
                .Index(t => t.CentroLogisticoID)
                .Index(t => t.OrdemID);
            
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        CidadeID = c.Int(nullable: false, identity: false),
                        CidadeNome = c.String(maxLength: 150, unicode: false),
                        EstadoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CidadeID)
                .ForeignKey("dbo.Estados", t => t.EstadoID)
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        EstadoID = c.Int(nullable: false, identity: false),
                        EstadoNome = c.String(maxLength: 150, unicode: false),
                        EstadoSiga = c.String(maxLength: 3, unicode: false),
                        PaisID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstadoID)
                .ForeignKey("dbo.Paises", t => t.PaisID)
                .Index(t => t.PaisID);
            
            CreateTable(
                "dbo.Paises",
                c => new
                    {
                        PaisID = c.Int(nullable: false, identity: false),
                        PaisNome = c.String(maxLength: 50, unicode: false),
                        PaisSigla = c.String(maxLength: 5, unicode: false),
                    })
                .PrimaryKey(t => t.PaisID);
            
            CreateTable(
                "dbo.GiroFechamentosMensais",
                c => new
                    {
                        GiroID = c.Guid(nullable: false),
                        EmpresaID = c.Long(nullable: false),
                        CentroLogisticoID = c.Int(nullable: false),
                        MaterialID = c.Int(nullable: false),
                        ClassificacaoID = c.Int(nullable: false),
                        FamiliaID = c.Int(nullable: false),
                        MGCodeID = c.Int(nullable: false),
                        UserId = c.String(maxLength: 150, unicode: false),
                        GiroEquivalente = c.Int(nullable: false),
                        EmpresaNome = c.String(maxLength: 150, unicode: false),
                        CentroLogisticoCodSap = c.String(maxLength: 4, unicode: false),
                        MaterialCodSap = c.String(maxLength: 10, unicode: false),
                        MaterialDescricao = c.String(maxLength: 150, unicode: false),
                        MaterialUM = c.String(maxLength: 5, unicode: false),
                        MaterialClasse = c.String(maxLength: 2, unicode: false),
                        ClassificacaoNome = c.String(maxLength: 20, unicode: false),
                        FamiliaNome = c.String(maxLength: 150, unicode: false),
                        MGCodeCodigoSap = c.String(maxLength: 10, unicode: false),
                        MGCodeDescricao = c.String(maxLength: 150, unicode: false),
                        UserName = c.String(maxLength: 150, unicode: false),
                        GiroConsQtde = c.Decimal(nullable: false, storeType: "money"),
                        GiroConsValor = c.Decimal(nullable: false, storeType: "money"),
                        GiroEstqQtde = c.Decimal(nullable: false, storeType: "money"),
                        GiroEstqValor = c.Decimal(nullable: false, storeType: "money"),
                        GiroPeriodo = c.Long(nullable: false),
                        Ano = c.Int(nullable: false),
                        Mes = c.Int(nullable: false),
                        TipoDoCentro = c.String(maxLength: 30, unicode: false),
                        Adm = c.String(maxLength: 2, unicode: false),
                    })
                .PrimaryKey(t => t.GiroID);
            
            CreateTable(
                "dbo.MovimentoEstoques",
                c => new
                    {
                        MovEstqID = c.Int(nullable: false, identity: false),
                        MovEstqChave = c.String(maxLength: 150, unicode: false),
                        MovEstqSigla = c.String(maxLength: 5, unicode: false),
                    })
                .PrimaryKey(t => t.MovEstqID);
            
            CreateTable(
                "dbo.MovimentoSapN1s",
                c => new
                    {
                        MovSapN1ID = c.Int(nullable: false, identity: false),
                        MovSapN1CodSap = c.String(maxLength: 5, unicode: false),
                        MovSapN1DescicaoSap = c.String(maxLength: 150, unicode: false),
                        MovSapN1DescricaoLogistica = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.MovSapN1ID);
            
            CreateTable(
                "dbo.MovimentoSapN2s",
                c => new
                    {
                        MovSapN2ID = c.Int(nullable: false, identity: false),
                        MovSapN2TMv2Chave = c.String(maxLength: 10, unicode: false),
                        MovSapN1ID = c.Int(nullable: false),
                        MovSapN2Sinal = c.String(maxLength: 1, unicode: false),
                        MovSapN2StatusPrimario = c.String(maxLength: 150, unicode: false),
                        MovSapN2StatusSecundario = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.MovSapN2ID)
                .ForeignKey("dbo.MovimentoSapN1s", t => t.MovSapN1ID)
                .Index(t => t.MovSapN1ID);
            
            CreateTable(
                "dbo.PlmMensalizadosLastYear",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        CentroLogisticoCodSap = c.String(maxLength: 150, unicode: false),
                        Sigla = c.String(maxLength: 5, unicode: false),
                        DiretoriaNome = c.String(maxLength: 150, unicode: false),
                        SubDiretoriaNome = c.String(maxLength: 150, unicode: false),
                        PlmProjeto = c.String(maxLength: 150, unicode: false),
                        PlmInfoAdicional = c.String(maxLength: 150, unicode: false),
                        PlmResponsavel = c.String(maxLength: 150, unicode: false),
                        PlmDataLanc = c.DateTime(nullable: false),
                        Mes1LastYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes2LastYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes3LastYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes4LastYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes5LastYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes6LastYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes7LastYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes8LastYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes9LastYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes10LastYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes11LastYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes12LastYear = c.Decimal(nullable: false, storeType: "money"),
                        TotLastYear = c.Decimal(nullable: false, storeType: "money"),
                        MedLastYear = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlmMensalizados",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        CentroLogisticoCodSap = c.String(maxLength: 5, unicode: false),
                        Sigla = c.String(maxLength: 5, unicode: false),
                        DiretoriaNome = c.String(maxLength: 150, unicode: false),
                        SubDiretoriaNome = c.String(maxLength: 150, unicode: false),
                        PlmProjeto = c.String(maxLength: 150, unicode: false),
                        PlmInfoAdicional = c.String(maxLength: 150, unicode: false),
                        PlmResponsavel = c.String(maxLength: 150, unicode: false),
                        PlmDataLanc = c.DateTime(),
                        Mes1CurrYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes2CurrYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes3CurrYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes4CurrYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes5CurrYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes6CurrYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes7CurrYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes8CurrYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes9CurrYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes10CurrYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes11CurrYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes12CurrYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes1AfterYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes2AfterYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes3AfterYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes4AfterYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes5AfterYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes6AfterYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes7AfterYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes8AfterYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes9AfterYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes10AfterYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes11AfterYear = c.Decimal(nullable: false, storeType: "money"),
                        Mes12AfterYear = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 150, unicode: false),
                        Name = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            
            
            CreateTable(
                "dbo.ZmepMensalizados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialID = c.Int(nullable: false),
                        Atraso = c.Decimal(nullable: false, storeType: "money"),
                        Month1 = c.Decimal(nullable: false, storeType: "money"),
                        Month2 = c.Decimal(nullable: false, storeType: "money"),
                        Month3 = c.Decimal(nullable: false, storeType: "money"),
                        Month4 = c.Decimal(nullable: false, storeType: "money"),
                        Month5 = c.Decimal(nullable: false, storeType: "money"),
                        Month6 = c.Decimal(nullable: false, storeType: "money"),
                        Month7 = c.Decimal(nullable: false, storeType: "money"),
                        Month8 = c.Decimal(nullable: false, storeType: "money"),
                        Month9 = c.Decimal(nullable: false, storeType: "money"),
                        Month10 = c.Decimal(nullable: false, storeType: "money"),
                        Month11 = c.Decimal(nullable: false, storeType: "money"),
                        Month12 = c.Decimal(nullable: false, storeType: "money"),
                        Month13 = c.Decimal(nullable: false, storeType: "money"),
                        Month14 = c.Decimal(nullable: false, storeType: "money"),
                        Month15 = c.Decimal(nullable: false, storeType: "money"),
                        Month16 = c.Decimal(nullable: false, storeType: "money"),
                        Month17 = c.Decimal(nullable: false, storeType: "money"),
                        Month18 = c.Decimal(nullable: false, storeType: "money"),
                        Month19 = c.Decimal(nullable: false, storeType: "money"),
                        Month20 = c.Decimal(nullable: false, storeType: "money"),
                        Month21 = c.Decimal(nullable: false, storeType: "money"),
                        Month22 = c.Decimal(nullable: false, storeType: "money"),
                        Month23 = c.Decimal(nullable: false, storeType: "money"),
                        Month24 = c.Decimal(nullable: false, storeType: "money"),
                        DataLanc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MovimentoSapN2s", "MovSapN1ID", "dbo.MovimentoSapN1s");
            DropForeignKey("dbo.Mb51s", "MovSapN1ID", "dbo.MovimentoSapN1s");
            DropForeignKey("dbo.Me2ms", "Me2mCentroRecebedor", "dbo.CentrosLogisticos");
            DropForeignKey("dbo.Me2ms", "Me2mCentroOrigem", "dbo.CentrosLogisticos");
            DropForeignKey("dbo.Estados", "PaisID", "dbo.Paises");
            DropForeignKey("dbo.Cidades", "EstadoID", "dbo.Estados");
            DropForeignKey("dbo.CentrosLogisticos", "CidadeID", "dbo.Cidades");
            DropForeignKey("dbo.BaseGiros", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.BaseGiros", "EmpresaID", "dbo.Empresas");
            DropForeignKey("dbo.AspNetUsers", "EmpresaID", "dbo.Empresas");
            DropForeignKey("dbo.Mb51s", "OrdemID", "dbo.Ordens");
            DropForeignKey("dbo.Zpi04s", "OrdemID", "dbo.Ordens");
            DropForeignKey("dbo.Zpi04s", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.Zpi04s", "CentroLogisticoID", "dbo.CentrosLogisticos");
            DropForeignKey("dbo.Reservas", "OrdemID", "dbo.Ordens");
            DropForeignKey("dbo.Reservas", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.Reservas", "CentroLogisticoID", "dbo.CentrosLogisticos");
            DropForeignKey("dbo.Reservas", "CecoID", "dbo.Cecos");
            DropForeignKey("dbo.Nbs", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.Nbs", "CentroLogisticoID", "dbo.CentrosLogisticos");
            DropForeignKey("dbo.Mm60s", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.Mm60s", "CentroLogisticoID", "dbo.CentrosLogisticos");
            DropForeignKey("dbo.Materiais", "MGCodeID", "dbo.MGCodes");
            DropForeignKey("dbo.Mb52s", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.Mb52s", "CentroLogisticoID", "dbo.CentrosLogisticos");
            DropForeignKey("dbo.Mb51s", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.Materiais", "MaterialSubId", "dbo.Materiais");
            DropForeignKey("dbo.HistoricoDeCompras", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.Me2ms", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.Me2ms", "FornecedorID", "dbo.Fornecedores");
            DropForeignKey("dbo.HistoricoDeCompras", "FornecedorID", "dbo.Fornecedores");
            DropForeignKey("dbo.ItemDoContratos", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.ItemDoContratos", "ContratoID", "dbo.Contratos");
            DropForeignKey("dbo.ItemDoContratos", "CentroLogisticoID", "dbo.CentrosLogisticos");
            DropForeignKey("dbo.Contratos", "FornecedorID", "dbo.Fornecedores");
            DropForeignKey("dbo.Contratos", "BaseCotacaoID", "dbo.BaseCotacoes");
            DropForeignKey("dbo.Zmeps", "BaseCotacaoID", "dbo.BaseCotacoes");
            DropForeignKey("dbo.PedidoDeCompras", "BaseCotacaoID", "dbo.BaseCotacoes");
            DropForeignKey("dbo.ItemPedidoDeCompras", "PedidoDeCompraId", "dbo.PedidoDeCompras");
            DropForeignKey("dbo.ItemPedidoDeCompras", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.ItemPedidoDeCompras", "ContratoID", "dbo.Contratos");
            DropForeignKey("dbo.ItemPedidoDeCompras", "CentroLogisticoID", "dbo.CentrosLogisticos");
            DropForeignKey("dbo.PedidoDeCompras", "FornecedorId", "dbo.Fornecedores");
            DropForeignKey("dbo.PedidoDeCompras", "EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.Zmeps", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.Zmeps", "FornecedorID", "dbo.Fornecedores");
            DropForeignKey("dbo.Zmeps", "ContratoID", "dbo.Contratos");
            DropForeignKey("dbo.Zmeps", "CondicaoDePagamentoID", "dbo.CondicaoDePagamentos");
            DropForeignKey("dbo.PedidoDeCompras", "CondicaoDePagamentoID", "dbo.CondicaoDePagamentos");
            DropForeignKey("dbo.AspNetUsers", "UsuarioLogisticaAtividadeID", "dbo.UsuarioLogisticaAtividades");
            DropForeignKey("dbo.ReferenciaDePrecos", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReferenciaDePrecos", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.HistoricoMateriais", "UsuarioLogisticaID", "dbo.AspNetUsers");
            DropForeignKey("dbo.HistoricoMateriais", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.Familias", "UsuarioLogisticaID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Materiais", "FamiliaID", "dbo.Familias");
            DropForeignKey("dbo.Familias", "EmpresaID", "dbo.Empresas");
            DropForeignKey("dbo.Zmovs", "OrdemID", "dbo.Ordens");
            DropForeignKey("dbo.Zmovs", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.Zmovs", "ClassificacaoID", "dbo.Classificacoes");
            DropForeignKey("dbo.Zmovs", "CentroLogisticoID", "dbo.CentrosLogisticos");
            DropForeignKey("dbo.Materiais", "ClassificacaoID", "dbo.Classificacoes");
            DropForeignKey("dbo.Giros", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.Giros", "ClassificacaoID", "dbo.Classificacoes");
            DropForeignKey("dbo.Giros", "CentroLogisticoID", "dbo.CentrosLogisticos");
            DropForeignKey("dbo.Estoques", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.Estoques", "ClassificacaoID", "dbo.Classificacoes");
            DropForeignKey("dbo.Estoques", "ClasseAvaliacaoID", "dbo.ClasseAvaliacoes");
            DropForeignKey("dbo.Estoques", "CentroLogisticoID", "dbo.CentrosLogisticos");
            DropForeignKey("dbo.Ajuste2015s", "ClassificacaoID", "dbo.Classificacoes");
            DropForeignKey("dbo.Appias", "UsuarioClienteId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Appias", "SubDiretoriaID", "dbo.SubDiretorias");
            DropForeignKey("dbo.Appias", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.Appias", "DiretoriaID", "dbo.Diretorias");
            DropForeignKey("dbo.AspNetUsers", "SubDiretoria_SubDiretoriaID", "dbo.SubDiretorias");
            DropForeignKey("dbo.Plms", "UsuarioClienteId", "dbo.AspNetUsers");
            DropForeignKey("dbo.HistoricoPlms", "UsuarioClienteId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "DiretoriaID", "dbo.Diretorias");
            DropForeignKey("dbo.Plms", "SUbDiretoriaID", "dbo.SubDiretorias");
            DropForeignKey("dbo.Plms", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.Plms", "DiretoriaID", "dbo.Diretorias");
            DropForeignKey("dbo.Plms", "CentroLogisticoID", "dbo.CentrosLogisticos");
            DropForeignKey("dbo.Ordens", "SubDiretoriaID", "dbo.SubDiretorias");
            DropForeignKey("dbo.HistoricoPlms", "SUbDiretoriaID", "dbo.SubDiretorias");
            DropForeignKey("dbo.SubDiretorias", "DiretoriaID", "dbo.Diretorias");
            DropForeignKey("dbo.HistoricoPlms", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.HistoricoPlms", "DiretoriaID", "dbo.Diretorias");
            DropForeignKey("dbo.HistoricoPlms", "CentroLogisticoID", "dbo.CentrosLogisticos");
            DropForeignKey("dbo.Diretorias", "EmpresaID", "dbo.Empresas");
            DropForeignKey("dbo.Ajuste2015s", "MaterialID", "dbo.Materiais");
            DropForeignKey("dbo.Mb51s", "CentroLogisticoID", "dbo.CentrosLogisticos");
            DropForeignKey("dbo.Ordens", "CecoID", "dbo.Cecos");
            DropForeignKey("dbo.Cecos", "EmpresaID", "dbo.Empresas");
            DropForeignKey("dbo.BaseGiros", "CentroLogisticoID", "dbo.CentrosLogisticos");
            DropForeignKey("dbo.Ajuste2015s", "CentroLogisticoID", "dbo.CentrosLogisticos");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.MovimentoSapN2s", new[] { "MovSapN1ID" });
            DropIndex("dbo.Estados", new[] { "PaisID" });
            DropIndex("dbo.Cidades", new[] { "EstadoID" });
            DropIndex("dbo.Zpi04s", new[] { "OrdemID" });
            DropIndex("dbo.Zpi04s", new[] { "CentroLogisticoID" });
            DropIndex("dbo.Zpi04s", new[] { "MaterialID" });
            DropIndex("dbo.Reservas", new[] { "OrdemID" });
            DropIndex("dbo.Reservas", new[] { "CentroLogisticoID" });
            DropIndex("dbo.Reservas", new[] { "MaterialID" });
            DropIndex("dbo.Reservas", new[] { "CecoID" });
            DropIndex("dbo.Nbs", new[] { "CentroLogisticoID" });
            DropIndex("dbo.Nbs", new[] { "MaterialID" });
            DropIndex("dbo.Mm60s", new[] { "CentroLogisticoID" });
            DropIndex("dbo.Mm60s", new[] { "MaterialID" });
            DropIndex("dbo.Mb52s", new[] { "CentroLogisticoID" });
            DropIndex("dbo.Mb52s", new[] { "MaterialID" });
            DropIndex("dbo.Me2ms", new[] { "Me2mCentroRecebedor" });
            DropIndex("dbo.Me2ms", new[] { "FornecedorID" });
            DropIndex("dbo.Me2ms", new[] { "Me2mCentroOrigem" });
            DropIndex("dbo.Me2ms", new[] { "MaterialID" });
            DropIndex("dbo.ItemDoContratos", new[] { "CentroLogisticoID" });
            DropIndex("dbo.ItemDoContratos", new[] { "MaterialID" });
            DropIndex("dbo.ItemDoContratos", new[] { "ContratoID" });
            DropIndex("dbo.ItemPedidoDeCompras", new[] { "ContratoID" });
            DropIndex("dbo.ItemPedidoDeCompras", new[] { "CentroLogisticoID" });
            DropIndex("dbo.ItemPedidoDeCompras", new[] { "MaterialID" });
            DropIndex("dbo.ItemPedidoDeCompras", new[] { "PedidoDeCompraId" });
            DropIndex("dbo.Zmeps", new[] { "CondicaoDePagamentoID" });
            DropIndex("dbo.Zmeps", new[] { "ContratoID" });
            DropIndex("dbo.Zmeps", new[] { "FornecedorID" });
            DropIndex("dbo.Zmeps", new[] { "BaseCotacaoID" });
            DropIndex("dbo.Zmeps", new[] { "MaterialID" });
            DropIndex("dbo.PedidoDeCompras", new[] { "BaseCotacaoID" });
            DropIndex("dbo.PedidoDeCompras", new[] { "CondicaoDePagamentoID" });
            DropIndex("dbo.PedidoDeCompras", new[] { "FornecedorId" });
            DropIndex("dbo.PedidoDeCompras", new[] { "EmpresaId" });
            DropIndex("dbo.Contratos", new[] { "FornecedorID" });
            DropIndex("dbo.Contratos", new[] { "BaseCotacaoID" });
            DropIndex("dbo.HistoricoDeCompras", new[] { "FornecedorID" });
            DropIndex("dbo.HistoricoDeCompras", new[] { "MaterialID" });
            DropIndex("dbo.ReferenciaDePrecos", new[] { "UsuarioId" });
            DropIndex("dbo.ReferenciaDePrecos", new[] { "MaterialID" });
            DropIndex("dbo.HistoricoMateriais", new[] { "UsuarioLogisticaID" });
            DropIndex("dbo.HistoricoMateriais", new[] { "MaterialID" });
            DropIndex("dbo.Familias", new[] { "EmpresaID" });
            DropIndex("dbo.Familias", new[] { "UsuarioLogisticaID" });
            DropIndex("dbo.Zmovs", new[] { "ClassificacaoID" });
            DropIndex("dbo.Zmovs", new[] { "OrdemID" });
            DropIndex("dbo.Zmovs", new[] { "MaterialID" });
            DropIndex("dbo.Zmovs", new[] { "CentroLogisticoID" });
            DropIndex("dbo.Giros", new[] { "ClassificacaoID" });
            DropIndex("dbo.Giros", new[] { "MaterialID" });
            DropIndex("dbo.Giros", new[] { "CentroLogisticoID" });
            DropIndex("dbo.Estoques", new[] { "ClasseAvaliacaoID" });
            DropIndex("dbo.Estoques", new[] { "ClassificacaoID" });
            DropIndex("dbo.Estoques", new[] { "MaterialID" });
            DropIndex("dbo.Estoques", new[] { "CentroLogisticoID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "SubDiretoria_SubDiretoriaID" });
            DropIndex("dbo.AspNetUsers", new[] { "UsuarioLogisticaAtividadeID" });
            DropIndex("dbo.AspNetUsers", new[] { "DiretoriaID" });
            DropIndex("dbo.AspNetUsers", new[] { "EmpresaID" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Plms", new[] { "UsuarioClienteId" });
            DropIndex("dbo.Plms", new[] { "SUbDiretoriaID" });
            DropIndex("dbo.Plms", new[] { "DiretoriaID" });
            DropIndex("dbo.Plms", new[] { "CentroLogisticoID" });
            DropIndex("dbo.Plms", new[] { "MaterialID" });
            DropIndex("dbo.SubDiretorias", new[] { "DiretoriaID" });
            DropIndex("dbo.HistoricoPlms", new[] { "UsuarioClienteId" });
            DropIndex("dbo.HistoricoPlms", new[] { "SUbDiretoriaID" });
            DropIndex("dbo.HistoricoPlms", new[] { "DiretoriaID" });
            DropIndex("dbo.HistoricoPlms", new[] { "CentroLogisticoID" });
            DropIndex("dbo.HistoricoPlms", new[] { "MaterialID" });
            DropIndex("dbo.Diretorias", new[] { "EmpresaID" });
            DropIndex("dbo.Appias", new[] { "UsuarioClienteId" });
            DropIndex("dbo.Appias", new[] { "SubDiretoriaID" });
            DropIndex("dbo.Appias", new[] { "DiretoriaID" });
            DropIndex("dbo.Appias", new[] { "MaterialID" });
            DropIndex("dbo.Materiais", new[] { "MaterialSubId" });
            DropIndex("dbo.Materiais", new[] { "MGCodeID" });
            DropIndex("dbo.Materiais", new[] { "FamiliaID" });
            DropIndex("dbo.Materiais", new[] { "ClassificacaoID" });
            DropIndex("dbo.Mb51s", new[] { "OrdemID" });
            DropIndex("dbo.Mb51s", new[] { "MovSapN1ID" });
            DropIndex("dbo.Mb51s", new[] { "CentroLogisticoID" });
            DropIndex("dbo.Mb51s", new[] { "MaterialID" });
            DropIndex("dbo.Ordens", new[] { "SubDiretoriaID" });
            DropIndex("dbo.Ordens", new[] { "CecoID" });
            DropIndex("dbo.Cecos", new[] { "EmpresaID" });
            DropIndex("dbo.BaseGiros", new[] { "MaterialID" });
            DropIndex("dbo.BaseGiros", new[] { "CentroLogisticoID" });
            DropIndex("dbo.BaseGiros", new[] { "EmpresaID" });
            DropIndex("dbo.CentrosLogisticos", new[] { "CidadeID" });
            DropIndex("dbo.Ajuste2015s", new[] { "ClassificacaoID" });
            DropIndex("dbo.Ajuste2015s", new[] { "MaterialID" });
            DropIndex("dbo.Ajuste2015s", new[] { "CentroLogisticoID" });
            DropTable("dbo.VF0b1");
            DropTable("dbo.ZmepMensalizados");
            DropTable("dbo.ValorReferencias");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PlmMensalizados");
            DropTable("dbo.PlmMensalizadosLastYear");
            DropTable("dbo.MovimentoSapN2s");
            DropTable("dbo.MovimentoSapN1s");
            DropTable("dbo.MovimentoEstoques");
            DropTable("dbo.GiroFechamentosMensais");
            DropTable("dbo.Paises");
            DropTable("dbo.Estados");
            DropTable("dbo.Cidades");
            DropTable("dbo.Zpi04s");
            DropTable("dbo.Reservas");
            DropTable("dbo.Nbs");
            DropTable("dbo.Mm60s");
            DropTable("dbo.MGCodes");
            DropTable("dbo.Mb52s");
            DropTable("dbo.Me2ms");
            DropTable("dbo.ItemDoContratos");
            DropTable("dbo.ItemPedidoDeCompras");
            DropTable("dbo.Zmeps");
            DropTable("dbo.CondicaoDePagamentos");
            DropTable("dbo.PedidoDeCompras");
            DropTable("dbo.BaseCotacoes");
            DropTable("dbo.Contratos");
            DropTable("dbo.Fornecedores");
            DropTable("dbo.HistoricoDeCompras");
            DropTable("dbo.UsuarioLogisticaAtividades");
            DropTable("dbo.ReferenciaDePrecos");
            DropTable("dbo.HistoricoMateriais");
            DropTable("dbo.Familias");
            DropTable("dbo.Zmovs");
            DropTable("dbo.Giros");
            DropTable("dbo.ClasseAvaliacoes");
            DropTable("dbo.Estoques");
            DropTable("dbo.Classificacoes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Plms");
            DropTable("dbo.SubDiretorias");
            DropTable("dbo.HistoricoPlms");
            DropTable("dbo.Diretorias");
            DropTable("dbo.Appias");
            DropTable("dbo.Materiais");
            DropTable("dbo.Mb51s");
            DropTable("dbo.Ordens");
            DropTable("dbo.Cecos");
            DropTable("dbo.Empresas");
            DropTable("dbo.BaseGiros");
            DropTable("dbo.CentrosLogisticos");
            DropTable("dbo.Ajuste2015s");
        }
    }
}
