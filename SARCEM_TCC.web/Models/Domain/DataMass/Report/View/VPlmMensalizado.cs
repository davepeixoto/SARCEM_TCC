﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report.View
{
    [Table("VPlmMensalizados")]
    public class VPlmMensalizado
    {

        public Guid Id { get; set; }
        public int MaterialId { get; set; }
        public string EmpresaNome { get; set; }
        [StringLength(4)]
        public string CentroLogisticoCodSap { get; set; }
        [StringLength(10)]
        public string MaterialCodSap { get; set; }

        public string MaterialDescricao { get; set; }
        public string MaterialClasse { get; set; }
        public string MaterialUM { get; set; }
        public string ClassificacaoNome { get; set; }
        public string UserName { get; set; }
        [StringLength(10)]
        public string MGCodeCodigoSap { get; set; }
        public string MGCodeDescricao { get; set; }
        public string FamiliaNome { get; set; }
        [StringLength(4)]
        public string Sigla { get; set; }
        public string DiretoriaNome { get; set; }
        public string SubDiretoriaNome { get; set; }
        public string PlmProjeto { get; set; }
        public string PlmInfoAdicional { get; set; }
        public string PlmResponsavel { get; set; }
        public DateTime? PlmDataLanc { get; set; }
        public decimal ValorDeReferencia { get; set; }
        public decimal Mes1CurrYear { get; set; }
        public decimal Mes2CurrYear { get; set; }
        public decimal Mes3CurrYear { get; set; }
        public decimal Mes4CurrYear { get; set; }
        public decimal Mes5CurrYear { get; set; }
        public decimal Mes6CurrYear { get; set; }
        public decimal Mes7CurrYear { get; set; }
        public decimal Mes8CurrYear { get; set; }
        public decimal Mes9CurrYear { get; set; }
        public decimal Mes10CurrYear { get; set; }
        public decimal Mes11CurrYear { get; set; }
        public decimal Mes12CurrYear { get; set; }
        public decimal Mes1AfterYear { get; set; }
        public decimal Mes2AfterYear { get; set; }
        public decimal Mes3AfterYear { get; set; }
        public decimal Mes4AfterYear { get; set; }
        public decimal Mes5AfterYear { get; set; }
        public decimal Mes6AfterYear { get; set; }
        public decimal Mes7AfterYear { get; set; }
        public decimal Mes8AfterYear { get; set; }
        public decimal Mes9AfterYear { get; set; }
        public decimal Mes10AfterYear { get; set; }
        public decimal Mes11AfterYear { get; set; }
        public decimal Mes12AfterYear { get; set; }
        public bool MaterialBloqueado { get; set; }
        public string MaterialSubstituto { get; set; }



    }
}