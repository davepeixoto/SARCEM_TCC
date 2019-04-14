using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report.View
{
    [Table("VMiniImpaqs")]
    public class VMiniImpaq
    {
        [Key]
        public Guid                         Id                          { get; set; }
        public long                         EmpresaID                   { get; set; }
        public int                          MaterialID                  { get; set; }
        public string                       EmpresaNome                 { get; set; }
        [StringLength(10)]
        public string                       MaterialCodSap              { get; set; }
        public string                       MaterialDescricao           { get; set; }
        [StringLength(5)]
        public string                       MaterialUM                  { get; set; }
        [StringLength(2)]
        public string                       MaterialClasse              { get; set; }
        public string                       ClassificacaoNome           { get; set; }
        public string                       FamiliaNome                 { get; set; }
        public string                       MGCodeCodigoSap             { get; set; }
        public string                       MGCodeDescricao             { get; set; }
        public string                       UserName                    { get; set; } // UsuarioLogistica.UserName
        public string                       AutonomiaAppia              { get; set; }
        public string                       AutonomiaCPM12              { get; set; }
        public string                       AutonomiaPLM                { get; set; }
        public string                       AutonomiaAppiaODC           { get; set; }
        public string                       AutonomiaCPM12ODC           { get; set; }
        public string                       AutonomiaPLMODC             { get; set; }
        public int                          QtdeDeContratos             { get; set; }
        public decimal                      ItemDoContratoQtdeDisp      { get; set; }
        public decimal                      TotalAppiaAnoAtual          { get; set; }
        public decimal                      MediaAppiaAnoAtual          { get; set; }
        public decimal                      Cpm12                       { get; set; }
        public decimal                      MediaPLM                    { get; set; }
        public decimal                      TotalPLM                    { get; set; }
        public decimal                      ZmepAtrasado                { get; set; }
        public decimal                      ZmepFuturo                  { get; set; }
        public decimal                      ZmepCorte                   { get; set; }
        public decimal                      FisicoQtde                  { get; set; }
        public decimal                      FisicoValor                 { get; set; }
        public decimal                      ConsumoQtde                 { get; set; }
        public decimal                      ConsumoValor                { get; set; }
        public decimal                      EntradaQtde                 { get; set; }
        public decimal                      EntradaValor                { get; set; }
        public DateTime?                    DataLanc                    { get; set; }
        public decimal                      ValorDeReferencia           { get; set; }
        public bool                         MaterialBloqueado           { get; set; }
        public string                       MaterialSubstituto          { get; set; }

    }
}