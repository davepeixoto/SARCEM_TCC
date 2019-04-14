using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report.TempTable
{
    [Table("AppiaQuerys")]
    public class AppiaQuery
    {
       
       
            public Guid Id { get; set; }
            public int MaterialId { get; set; }
            //public string EmpresaNome { get; set; }
            //[StringLength(10)]
            //public string MaterialCodSap { get; set; }
            //public string MaterialDescricao { get; set; }
            //[StringLength(5)]
            //public string MaterialClasse { get; set; }
            //[StringLength(5)]
            //public string MaterialUM { get; set; }
            //public string ClassificacaoNome { get; set; }
            //public string UserName { get; set; }
            //[StringLength(15)]
            //public string MGCodeCodigoSap { get; set; }
            //public string MGCodeDescricao   { get; set; }
            //public string FamiliaNome       { get; set; }
            public string DiretoriaNome { get; set; }
            public string SubDiretoriaNome { get; set; }
            public string AppiaProjeto { get; set; }
            public string AppiaInfoAdicional { get; set; }
            public string AppiaResponsavel { get; set; }
            public DateTime? AppiaDataLanc { get; set; }
            public decimal MedCurrYear          { get; set; }
            public decimal TotCurrYear          { get; set; }
            public decimal MedAfterYear         { get; set; }
            public decimal TotAfterYear         { get; set; }
            public decimal MedAfterYearPlusOne { get; set; }
            public decimal TotAfterYearPlusOne { get; set; }
            public decimal TotTrienio           { get; set; }
            public decimal MedTrienio           { get; set; }
            //public decimal ValorDeReferencia { get; set; }
            //public decimal MedCurrYearEmReal { get; set; }
            //public decimal TotCurrYearEmReal { get; set; }
            //public decimal MedAfterYearEmReal { get; set; }
            //public decimal TotAfterYearEmReal { get; set; }
            //public decimal MedAfterYearPlusOneEmReal { get; set; }
            //public decimal TotAfterYearPlusOneEmReal { get; set; }
            //public decimal TotTrienioEmReal { get; set; }
            //public decimal MedTrienioEmReal { get; set; }



    }
}