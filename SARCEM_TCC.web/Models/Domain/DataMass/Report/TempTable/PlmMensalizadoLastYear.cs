﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SARCEM_TCC.web.Models.Domain.DataMass.Report.TempTable
{
    [Table("PlmMensalizadosLastYear")]
    public class PlmMensalizadoLastYear
    {
        public Guid Id  { get; set; }
        public int MaterialId  { get; set; }
        public string CentroLogisticoCodSap { get; set; }
        public string Sigla  { get; set; }
        public string DiretoriaNome  { get; set; }
        public string SubDiretoriaNome  { get; set; }
        public string PlmProjeto  { get; set; }
        public string PlmInfoAdicional  { get; set; }
        public string PlmResponsavel  { get; set; }
        public DateTime PlmDataLanc  { get; set; }
        public decimal Mes1LastYear  { get; set; }
        public decimal Mes2LastYear  { get; set; }
        public decimal Mes3LastYear  { get; set; }
        public decimal Mes4LastYear  { get; set; }
        public decimal Mes5LastYear  { get; set; }
        public decimal Mes6LastYear  { get; set; }
        public decimal Mes7LastYear  { get; set; }
        public decimal Mes8LastYear  { get; set; }
        public decimal Mes9LastYear  { get; set; }
        public decimal Mes10LastYear  { get; set; }
        public decimal Mes11LastYear  { get; set; }
        public decimal Mes12LastYear  { get; set; }
        public decimal TotLastYear    { get; set; }
        public decimal MedLastYear        { get; set; }
       
       
    }
}