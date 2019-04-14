using SARCEM_TCC.web.DTO;
using SARCEM_TCC.web.Models.Domain.DataMass.Report.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SARCEM_TCC.web.Helper
{
    public class Filtro
    {
        public static IList<PlmMensalizadoFiltrado> Plm12(IEnumerable<VPlmMensalizado> lista, bool historico)
        {
            int mes;

            if (historico)
            {
                mes = 1;
            }
            else
            {
                mes = DateTime.Now.Month;
            }





            switch (mes)
            {
                case 1:
                    {
                        return (from x in lista

                                select new PlmMensalizadoFiltrado()
                                {

                                    Id = x.Id,
                                    MaterialId = x.MaterialId,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialClasse = x.MaterialClasse,
                                    MaterialUM = x.MaterialUM,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    UserName = x.UserName,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    FamiliaNome = x.FamiliaNome,
                                    Sigla = x.Sigla,
                                    DiretoriaNome = x.DiretoriaNome,
                                    SubDiretoriaNome = x.SubDiretoriaNome,
                                    PlmProjeto = x.PlmProjeto,
                                    PlmInfoAdicional = x.PlmInfoAdicional,
                                    PlmResponsavel = x.PlmResponsavel,
                                    PlmDataLanc = x.PlmDataLanc,
                                    ValorDeReferencia = x.ValorDeReferencia,
                                    Media = (
                                                    x.Mes1CurrYear +
                                                    x.Mes2CurrYear +
                                                    x.Mes3CurrYear +
                                                    x.Mes4CurrYear +
                                                    x.Mes5CurrYear +
                                                    x.Mes6CurrYear +
                                                    x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear) / 12,




                                    MediaEmReal = ((
                                                    x.Mes1CurrYear +
                                                    x.Mes2CurrYear +
                                                    x.Mes3CurrYear +
                                                    x.Mes4CurrYear +
                                                    x.Mes5CurrYear +
                                                    x.Mes6CurrYear +
                                                    x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear) / 12) * x.ValorDeReferencia,

                                    Total = (
                                                    x.Mes1CurrYear +
                                                    x.Mes2CurrYear +
                                                    x.Mes3CurrYear +
                                                    x.Mes4CurrYear +
                                                    x.Mes5CurrYear +
                                                    x.Mes6CurrYear +
                                                    x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear),



                                    TotalEmReal = (
                                                    x.Mes1CurrYear +
                                                    x.Mes2CurrYear +
                                                    x.Mes3CurrYear +
                                                    x.Mes4CurrYear +
                                                    x.Mes5CurrYear +
                                                    x.Mes6CurrYear +
                                                    x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear) * x.ValorDeReferencia,

                                    Mes1 = x.Mes1CurrYear,
                                    Mes2 = x.Mes2CurrYear,
                                    Mes3 = x.Mes3CurrYear,
                                    Mes4 = x.Mes4CurrYear,
                                    Mes5 = x.Mes5CurrYear,
                                    Mes6 = x.Mes6CurrYear,
                                    Mes7 = x.Mes7CurrYear,
                                    Mes8 = x.Mes8CurrYear,
                                    Mes9 = x.Mes9CurrYear,
                                    Mes10 = x.Mes10CurrYear,
                                    Mes11 = x.Mes11CurrYear,
                                    Mes12 = x.Mes12CurrYear,
                                    MaterialBloqueado = x.MaterialBloqueado,
                                    MaterialSubstituto = x.MaterialSubstituto,


                                }
                                ).ToList();
                    };

                case 2:
                    {
                        return (from x in lista

                                select new PlmMensalizadoFiltrado()
                                {

                                    Id = x.Id,
                                    MaterialId = x.MaterialId,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialClasse = x.MaterialClasse,
                                    MaterialUM = x.MaterialUM,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    UserName = x.UserName,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    FamiliaNome = x.FamiliaNome,
                                    Sigla = x.Sigla,
                                    DiretoriaNome = x.DiretoriaNome,
                                    SubDiretoriaNome = x.SubDiretoriaNome,
                                    PlmProjeto = x.PlmProjeto,
                                    PlmInfoAdicional = x.PlmInfoAdicional,
                                    PlmResponsavel = x.PlmResponsavel,
                                    PlmDataLanc = x.PlmDataLanc,
                                    ValorDeReferencia = x.ValorDeReferencia,
                                    Media = (
                                                    x.Mes2CurrYear +
                                                    x.Mes3CurrYear +
                                                    x.Mes4CurrYear +
                                                    x.Mes5CurrYear +
                                                    x.Mes6CurrYear +
                                                    x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear) / 12,

                                    MediaEmReal = ((
                                                    x.Mes2CurrYear +
                                                    x.Mes3CurrYear +
                                                    x.Mes4CurrYear +
                                                    x.Mes5CurrYear +
                                                    x.Mes6CurrYear +
                                                    x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear) / 12) * x.ValorDeReferencia,

                                    Total = (
                                                    x.Mes2CurrYear +
                                                    x.Mes3CurrYear +
                                                    x.Mes4CurrYear +
                                                    x.Mes5CurrYear +
                                                    x.Mes6CurrYear +
                                                    x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear),

                                    TotalEmReal = (
                                                    x.Mes2CurrYear +
                                                    x.Mes3CurrYear +
                                                    x.Mes4CurrYear +
                                                    x.Mes5CurrYear +
                                                    x.Mes6CurrYear +
                                                    x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear) * x.ValorDeReferencia,
                                    Mes1 = x.Mes2CurrYear,
                                    Mes2 = x.Mes3CurrYear,
                                    Mes3 = x.Mes4CurrYear,
                                    Mes4 = x.Mes5CurrYear,
                                    Mes5 = x.Mes6CurrYear,
                                    Mes6 = x.Mes7CurrYear,
                                    Mes7 = x.Mes8CurrYear,
                                    Mes8 = x.Mes9CurrYear,
                                    Mes9 = x.Mes10CurrYear,
                                    Mes10 = x.Mes11CurrYear,
                                    Mes11 = x.Mes12CurrYear,
                                    Mes12 = x.Mes1AfterYear,
                                    MaterialBloqueado = x.MaterialBloqueado,
                                    MaterialSubstituto = x.MaterialSubstituto,


                                }
                                ).ToList();
                    };

                case 3:
                    {
                        return (from x in lista

                                select new PlmMensalizadoFiltrado()
                                {

                                    Id = x.Id,
                                    MaterialId = x.MaterialId,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialClasse = x.MaterialClasse,
                                    MaterialUM = x.MaterialUM,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    UserName = x.UserName,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    FamiliaNome = x.FamiliaNome,
                                    Sigla = x.Sigla,
                                    DiretoriaNome = x.DiretoriaNome,
                                    SubDiretoriaNome = x.SubDiretoriaNome,
                                    PlmProjeto = x.PlmProjeto,
                                    PlmInfoAdicional = x.PlmInfoAdicional,
                                    PlmResponsavel = x.PlmResponsavel,
                                    PlmDataLanc = x.PlmDataLanc,
                                    ValorDeReferencia = x.ValorDeReferencia,

                                    Media = (
                                    x.Mes3CurrYear +
                                    x.Mes4CurrYear +
                                    x.Mes5CurrYear +
                                    x.Mes6CurrYear +
                                    x.Mes7CurrYear +
                                    x.Mes8CurrYear +
                                    x.Mes9CurrYear +
                                    x.Mes10CurrYear +
                                    x.Mes11CurrYear +
                                    x.Mes12CurrYear +
                                    x.Mes1AfterYear +
                                    x.Mes2AfterYear
                                    ) / 12,

                                    MediaEmReal = ((
                                    x.Mes3CurrYear +
                                    x.Mes4CurrYear +
                                    x.Mes5CurrYear +
                                    x.Mes6CurrYear +
                                    x.Mes7CurrYear +
                                    x.Mes8CurrYear +
                                    x.Mes9CurrYear +
                                    x.Mes10CurrYear +
                                    x.Mes11CurrYear +
                                    x.Mes12CurrYear +
                                    x.Mes1AfterYear +
                                    x.Mes2AfterYear
                                    ) / 12) * x.ValorDeReferencia,

                                    Total = (
                                    x.Mes3CurrYear +
                                    x.Mes4CurrYear +
                                    x.Mes5CurrYear +
                                    x.Mes6CurrYear +
                                    x.Mes7CurrYear +
                                    x.Mes8CurrYear +
                                    x.Mes9CurrYear +
                                    x.Mes10CurrYear +
                                    x.Mes11CurrYear +
                                    x.Mes12CurrYear +
                                    x.Mes1AfterYear +
                                    x.Mes2AfterYear
                                    ),

                                    TotalEmReal = (
                                    x.Mes3CurrYear +
                                    x.Mes4CurrYear +
                                    x.Mes5CurrYear +
                                    x.Mes6CurrYear +
                                    x.Mes7CurrYear +
                                    x.Mes8CurrYear +
                                    x.Mes9CurrYear +
                                    x.Mes10CurrYear +
                                    x.Mes11CurrYear +
                                    x.Mes12CurrYear +
                                    x.Mes1AfterYear +
                                    x.Mes2AfterYear
                                    ) * x.ValorDeReferencia,


                                    Mes1 = x.Mes3CurrYear,
                                    Mes2 = x.Mes4CurrYear,
                                    Mes3 = x.Mes5CurrYear,
                                    Mes4 = x.Mes6CurrYear,
                                    Mes5 = x.Mes7CurrYear,
                                    Mes6 = x.Mes8CurrYear,
                                    Mes7 = x.Mes9CurrYear,
                                    Mes8 = x.Mes10CurrYear,
                                    Mes9 = x.Mes11CurrYear,
                                    Mes10 = x.Mes12CurrYear,
                                    Mes11 = x.Mes1AfterYear,
                                    Mes12 = x.Mes2AfterYear,

                                    MaterialBloqueado = x.MaterialBloqueado,
                                    MaterialSubstituto = x.MaterialSubstituto,

                                }
                                ).ToList();
                    };


                case 4:
                    {
                        return (from x in lista

                                select new PlmMensalizadoFiltrado()
                                {

                                    Id = x.Id,
                                    MaterialId = x.MaterialId,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialClasse = x.MaterialClasse,
                                    MaterialUM = x.MaterialUM,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    UserName = x.UserName,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    FamiliaNome = x.FamiliaNome,
                                    Sigla = x.Sigla,
                                    DiretoriaNome = x.DiretoriaNome,
                                    SubDiretoriaNome = x.SubDiretoriaNome,
                                    PlmProjeto = x.PlmProjeto,
                                    PlmInfoAdicional = x.PlmInfoAdicional,
                                    PlmResponsavel = x.PlmResponsavel,
                                    PlmDataLanc = x.PlmDataLanc,
                                    ValorDeReferencia = x.ValorDeReferencia,
                                    Media = (
                                            x.Mes4CurrYear +
                                            x.Mes5CurrYear +
                                            x.Mes6CurrYear +
                                            x.Mes7CurrYear +
                                            x.Mes8CurrYear +
                                            x.Mes9CurrYear +
                                            x.Mes10CurrYear +
                                            x.Mes11CurrYear +
                                            x.Mes12CurrYear +
                                            x.Mes1AfterYear +
                                            x.Mes2AfterYear +
                                            x.Mes3AfterYear) / 12,

                                    MediaEmReal = ((
                                            x.Mes4CurrYear +
                                            x.Mes5CurrYear +
                                            x.Mes6CurrYear +
                                            x.Mes7CurrYear +
                                            x.Mes8CurrYear +
                                            x.Mes9CurrYear +
                                            x.Mes10CurrYear +
                                            x.Mes11CurrYear +
                                            x.Mes12CurrYear +
                                            x.Mes1AfterYear +
                                            x.Mes2AfterYear +
                                            x.Mes3AfterYear) / 12) * x.ValorDeReferencia,

                                    Total = (
                                            x.Mes4CurrYear +
                                            x.Mes5CurrYear +
                                            x.Mes6CurrYear +
                                            x.Mes7CurrYear +
                                            x.Mes8CurrYear +
                                            x.Mes9CurrYear +
                                            x.Mes10CurrYear +
                                            x.Mes11CurrYear +
                                            x.Mes12CurrYear +
                                            x.Mes1AfterYear +
                                            x.Mes2AfterYear +
                                            x.Mes3AfterYear),

                                    TotalEmReal = (
                                            x.Mes4CurrYear +
                                            x.Mes5CurrYear +
                                            x.Mes6CurrYear +
                                            x.Mes7CurrYear +
                                            x.Mes8CurrYear +
                                            x.Mes9CurrYear +
                                            x.Mes10CurrYear +
                                            x.Mes11CurrYear +
                                            x.Mes12CurrYear +
                                            x.Mes1AfterYear +
                                            x.Mes2AfterYear +
                                            x.Mes3AfterYear) * x.ValorDeReferencia,


                                    Mes1 = x.Mes4CurrYear,
                                    Mes2 = x.Mes5CurrYear,
                                    Mes3 = x.Mes6CurrYear,
                                    Mes4 = x.Mes7CurrYear,
                                    Mes5 = x.Mes8CurrYear,
                                    Mes6 = x.Mes9CurrYear,
                                    Mes7 = x.Mes10CurrYear,
                                    Mes8 = x.Mes11CurrYear,
                                    Mes9 = x.Mes12CurrYear,
                                    Mes10 = x.Mes1AfterYear,
                                    Mes11 = x.Mes2AfterYear,
                                    Mes12 = x.Mes3AfterYear,
                                    MaterialBloqueado = x.MaterialBloqueado,
                                    MaterialSubstituto = x.MaterialSubstituto,


                                }
                                ).ToList();
                    };

                case 5:
                    {
                        return (from x in lista

                                select new PlmMensalizadoFiltrado()
                                {

                                    Id = x.Id,
                                    MaterialId = x.MaterialId,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialClasse = x.MaterialClasse,
                                    MaterialUM = x.MaterialUM,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    UserName = x.UserName,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    FamiliaNome = x.FamiliaNome,
                                    Sigla = x.Sigla,
                                    DiretoriaNome = x.DiretoriaNome,
                                    SubDiretoriaNome = x.SubDiretoriaNome,
                                    PlmProjeto = x.PlmProjeto,
                                    PlmInfoAdicional = x.PlmInfoAdicional,
                                    PlmResponsavel = x.PlmResponsavel,
                                    PlmDataLanc = x.PlmDataLanc,
                                    ValorDeReferencia = x.ValorDeReferencia,
                                    Media = (
                                    x.Mes5CurrYear +
                                    x.Mes6CurrYear +
                                    x.Mes7CurrYear +
                                    x.Mes8CurrYear +
                                    x.Mes9CurrYear +
                                    x.Mes10CurrYear +
                                    x.Mes11CurrYear +
                                    x.Mes12CurrYear +
                                    x.Mes1AfterYear +
                                    x.Mes2AfterYear +
                                    x.Mes3AfterYear +
                                    x.Mes4AfterYear) / 12,

                                    MediaEmReal = ((
                                    x.Mes5CurrYear +
                                    x.Mes6CurrYear +
                                    x.Mes7CurrYear +
                                    x.Mes8CurrYear +
                                    x.Mes9CurrYear +
                                    x.Mes10CurrYear +
                                    x.Mes11CurrYear +
                                    x.Mes12CurrYear +
                                    x.Mes1AfterYear +
                                    x.Mes2AfterYear +
                                    x.Mes3AfterYear +
                                    x.Mes4AfterYear) / 12) * x.ValorDeReferencia,

                                    Total = (
                                    x.Mes5CurrYear +
                                    x.Mes6CurrYear +
                                    x.Mes7CurrYear +
                                    x.Mes8CurrYear +
                                    x.Mes9CurrYear +
                                    x.Mes10CurrYear +
                                    x.Mes11CurrYear +
                                    x.Mes12CurrYear +
                                    x.Mes1AfterYear +
                                    x.Mes2AfterYear +
                                    x.Mes3AfterYear +
                                    x.Mes4AfterYear),

                                    TotalEmReal = (
                                    x.Mes5CurrYear +
                                    x.Mes6CurrYear +
                                    x.Mes7CurrYear +
                                    x.Mes8CurrYear +
                                    x.Mes9CurrYear +
                                    x.Mes10CurrYear +
                                    x.Mes11CurrYear +
                                    x.Mes12CurrYear +
                                    x.Mes1AfterYear +
                                    x.Mes2AfterYear +
                                    x.Mes3AfterYear +
                                    x.Mes4AfterYear) * x.ValorDeReferencia,


                                    Mes1 = x.Mes5CurrYear,
                                    Mes2 = x.Mes6CurrYear,
                                    Mes3 = x.Mes7CurrYear,
                                    Mes4 = x.Mes8CurrYear,
                                    Mes5 = x.Mes9CurrYear,
                                    Mes6 = x.Mes10CurrYear,
                                    Mes7 = x.Mes11CurrYear,
                                    Mes8 = x.Mes12CurrYear,
                                    Mes9 = x.Mes1AfterYear,
                                    Mes10 = x.Mes2AfterYear,
                                    Mes11 = x.Mes3AfterYear,
                                    Mes12 = x.Mes4AfterYear,
                                    MaterialBloqueado = x.MaterialBloqueado,
                                    MaterialSubstituto = x.MaterialSubstituto,

                                }
                                ).ToList();
                    };

                case 6:
                    {
                        return (from x in lista

                                select new PlmMensalizadoFiltrado()
                                {

                                    Id = x.Id,
                                    MaterialId = x.MaterialId,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialClasse = x.MaterialClasse,
                                    MaterialUM = x.MaterialUM,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    UserName = x.UserName,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    FamiliaNome = x.FamiliaNome,
                                    Sigla = x.Sigla,
                                    DiretoriaNome = x.DiretoriaNome,
                                    SubDiretoriaNome = x.SubDiretoriaNome,
                                    PlmProjeto = x.PlmProjeto,
                                    PlmInfoAdicional = x.PlmInfoAdicional,
                                    PlmResponsavel = x.PlmResponsavel,
                                    PlmDataLanc = x.PlmDataLanc,
                                    ValorDeReferencia = x.ValorDeReferencia,
                                    Media = (x.Mes6CurrYear +
                                                    x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear) / 12,

                                    MediaEmReal = ((x.Mes6CurrYear +
                                                    x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear) / 12) * x.ValorDeReferencia,

                                    Total = (x.Mes6CurrYear +
                                                    x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear),

                                    TotalEmReal = (x.Mes6CurrYear +
                                                    x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear) * x.ValorDeReferencia,


                                    Mes1 = x.Mes6CurrYear,
                                    Mes2 = x.Mes7CurrYear,
                                    Mes3 = x.Mes8CurrYear,
                                    Mes4 = x.Mes9CurrYear,
                                    Mes5 = x.Mes10CurrYear,
                                    Mes6 = x.Mes11CurrYear,
                                    Mes7 = x.Mes12CurrYear,
                                    Mes8 = x.Mes1AfterYear,
                                    Mes9 = x.Mes2AfterYear,
                                    Mes10 = x.Mes3AfterYear,
                                    Mes11 = x.Mes4AfterYear,
                                    Mes12 = x.Mes5AfterYear,
                                    MaterialBloqueado = x.MaterialBloqueado,
                                    MaterialSubstituto = x.MaterialSubstituto,


                                }
                                ).ToList();
                    };

                case 7:
                    {
                        return (from x in lista

                                select new PlmMensalizadoFiltrado()
                                {

                                    Id = x.Id,
                                    MaterialId = x.MaterialId,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialClasse = x.MaterialClasse,
                                    MaterialUM = x.MaterialUM,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    UserName = x.UserName,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    FamiliaNome = x.FamiliaNome,
                                    Sigla = x.Sigla,
                                    DiretoriaNome = x.DiretoriaNome,
                                    SubDiretoriaNome = x.SubDiretoriaNome,
                                    PlmProjeto = x.PlmProjeto,
                                    PlmInfoAdicional = x.PlmInfoAdicional,
                                    PlmResponsavel = x.PlmResponsavel,
                                    PlmDataLanc = x.PlmDataLanc,
                                    ValorDeReferencia = x.ValorDeReferencia,
                                    Media = (x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear) / 12,

                                    MediaEmReal = ((x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear) / 12) * x.ValorDeReferencia,

                                    Total = (x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear),

                                    TotalEmReal = (x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear) * x.ValorDeReferencia,


                                    Mes1 = x.Mes7CurrYear,
                                    Mes2 = x.Mes8CurrYear,
                                    Mes3 = x.Mes9CurrYear,
                                    Mes4 = x.Mes10CurrYear,
                                    Mes5 = x.Mes11CurrYear,
                                    Mes6 = x.Mes12CurrYear,
                                    Mes7 = x.Mes1AfterYear,
                                    Mes8 = x.Mes2AfterYear,
                                    Mes9 = x.Mes3AfterYear,
                                    Mes10 = x.Mes4AfterYear,
                                    Mes11 = x.Mes5AfterYear,
                                    Mes12 = x.Mes6AfterYear,
                                    MaterialBloqueado = x.MaterialBloqueado,
                                    MaterialSubstituto = x.MaterialSubstituto,


                                }
                                ).ToList();
                    };

                case 8:
                    {
                        return (from x in lista

                                select new PlmMensalizadoFiltrado()
                                {

                                    Id = x.Id,
                                    MaterialId = x.MaterialId,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialClasse = x.MaterialClasse,
                                    MaterialUM = x.MaterialUM,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    UserName = x.UserName,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    FamiliaNome = x.FamiliaNome,
                                    Sigla = x.Sigla,
                                    DiretoriaNome = x.DiretoriaNome,
                                    SubDiretoriaNome = x.SubDiretoriaNome,
                                    PlmProjeto = x.PlmProjeto,
                                    PlmInfoAdicional = x.PlmInfoAdicional,
                                    PlmResponsavel = x.PlmResponsavel,
                                    PlmDataLanc = x.PlmDataLanc,
                                    ValorDeReferencia = x.ValorDeReferencia,
                                    Media = (x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear) / 12,

                                    MediaEmReal = ((x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear) / 12) * x.ValorDeReferencia,

                                    Total = (x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear),

                                    TotalEmReal = (x.Mes7CurrYear +
                                                    x.Mes8CurrYear +
                                                    x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear) * x.ValorDeReferencia,


                                    Mes1 = x.Mes8CurrYear,
                                    Mes2 = x.Mes9CurrYear,
                                    Mes3 = x.Mes10CurrYear,
                                    Mes4 = x.Mes11CurrYear,
                                    Mes5 = x.Mes12CurrYear,
                                    Mes6 = x.Mes1AfterYear,
                                    Mes7 = x.Mes2AfterYear,
                                    Mes8 = x.Mes3AfterYear,
                                    Mes9 = x.Mes4AfterYear,
                                    Mes10 = x.Mes5AfterYear,
                                    Mes11 = x.Mes6AfterYear,
                                    Mes12 = x.Mes7AfterYear,

                                    MaterialBloqueado = x.MaterialBloqueado,
                                    MaterialSubstituto = x.MaterialSubstituto,

                                }
                                ).ToList();
                    };


                case 9:
                    {
                        return (from x in lista

                                select new PlmMensalizadoFiltrado()
                                {

                                    Id = x.Id,
                                    MaterialId = x.MaterialId,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialClasse = x.MaterialClasse,
                                    MaterialUM = x.MaterialUM,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    UserName = x.UserName,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    FamiliaNome = x.FamiliaNome,
                                    Sigla = x.Sigla,
                                    DiretoriaNome = x.DiretoriaNome,
                                    SubDiretoriaNome = x.SubDiretoriaNome,
                                    PlmProjeto = x.PlmProjeto,
                                    PlmInfoAdicional = x.PlmInfoAdicional,
                                    PlmResponsavel = x.PlmResponsavel,
                                    PlmDataLanc = x.PlmDataLanc,
                                    ValorDeReferencia = x.ValorDeReferencia,
                                    Media = (x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear +
                                                    x.Mes7AfterYear +
                                                    x.Mes8AfterYear) / 12,

                                    MediaEmReal = ((x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear +
                                                    x.Mes7AfterYear +
                                                    x.Mes8AfterYear) / 12) * x.ValorDeReferencia,

                                    Total = (x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear +
                                                    x.Mes7AfterYear +
                                                    x.Mes8AfterYear),

                                    TotalEmReal = (x.Mes9CurrYear +
                                                    x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear +
                                                    x.Mes7AfterYear +
                                                    x.Mes8AfterYear) * x.ValorDeReferencia,

                                    Mes1 = x.Mes9CurrYear,
                                    Mes2 = x.Mes10CurrYear,
                                    Mes3 = x.Mes11CurrYear,
                                    Mes4 = x.Mes12CurrYear,
                                    Mes5 = x.Mes1AfterYear,
                                    Mes6 = x.Mes2AfterYear,
                                    Mes7 = x.Mes3AfterYear,
                                    Mes8 = x.Mes4AfterYear,
                                    Mes9 = x.Mes5AfterYear,
                                    Mes10 = x.Mes6AfterYear,
                                    Mes11 = x.Mes7AfterYear,
                                    Mes12 = x.Mes8AfterYear,
                                    MaterialBloqueado = x.MaterialBloqueado,
                                    MaterialSubstituto = x.MaterialSubstituto,



                                }
                                ).ToList();
                    };

                case 10:
                    {
                        return (from x in lista

                                select new PlmMensalizadoFiltrado()
                                {

                                    Id = x.Id,
                                    MaterialId = x.MaterialId,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialClasse = x.MaterialClasse,
                                    MaterialUM = x.MaterialUM,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    UserName = x.UserName,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    FamiliaNome = x.FamiliaNome,
                                    Sigla = x.Sigla,
                                    DiretoriaNome = x.DiretoriaNome,
                                    SubDiretoriaNome = x.SubDiretoriaNome,
                                    PlmProjeto = x.PlmProjeto,
                                    PlmInfoAdicional = x.PlmInfoAdicional,
                                    PlmResponsavel = x.PlmResponsavel,
                                    PlmDataLanc = x.PlmDataLanc,
                                    ValorDeReferencia = x.ValorDeReferencia,
                                    Media = (x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear +
                                                    x.Mes7AfterYear +
                                                    x.Mes8AfterYear +
                                                    x.Mes9AfterYear) / 12,

                                    MediaEmReal = ((x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear +
                                                    x.Mes7AfterYear +
                                                    x.Mes8AfterYear +
                                                    x.Mes9AfterYear) / 12) * x.ValorDeReferencia,

                                    Total = (x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear +
                                                    x.Mes7AfterYear +
                                                    x.Mes8AfterYear +
                                                    x.Mes9AfterYear),

                                    TotalEmReal = (x.Mes10CurrYear +
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear +
                                                    x.Mes7AfterYear +
                                                    x.Mes8AfterYear +
                                                    x.Mes9AfterYear) * x.ValorDeReferencia,


                                    Mes1 = x.Mes10CurrYear,
                                    Mes2 = x.Mes11CurrYear,
                                    Mes3 = x.Mes12CurrYear,
                                    Mes4 = x.Mes1AfterYear,
                                    Mes5 = x.Mes2AfterYear,
                                    Mes6 = x.Mes3AfterYear,
                                    Mes7 = x.Mes4AfterYear,
                                    Mes8 = x.Mes5AfterYear,
                                    Mes9 = x.Mes6AfterYear,
                                    Mes10 = x.Mes7AfterYear,
                                    Mes11 = x.Mes8AfterYear,
                                    Mes12 = x.Mes9AfterYear,
                                    MaterialBloqueado = x.MaterialBloqueado,
                                    MaterialSubstituto = x.MaterialSubstituto,

                                }
                                ).ToList();
                    };

                case 11:
                    {
                        return (from x in lista

                                select new PlmMensalizadoFiltrado()
                                {

                                    Id = x.Id,
                                    MaterialId = x.MaterialId,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialClasse = x.MaterialClasse,
                                    MaterialUM = x.MaterialUM,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    UserName = x.UserName,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    FamiliaNome = x.FamiliaNome,
                                    Sigla = x.Sigla,
                                    DiretoriaNome = x.DiretoriaNome,
                                    SubDiretoriaNome = x.SubDiretoriaNome,
                                    PlmProjeto = x.PlmProjeto,
                                    PlmInfoAdicional = x.PlmInfoAdicional,
                                    PlmResponsavel = x.PlmResponsavel,
                                    PlmDataLanc = x.PlmDataLanc,
                                    ValorDeReferencia = x.ValorDeReferencia,
                                    Media = (
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear +
                                                    x.Mes7AfterYear +
                                                    x.Mes8AfterYear +
                                                    x.Mes9AfterYear +
                                                    x.Mes10AfterYear) / 12,




                                    MediaEmReal = ((
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear +
                                                    x.Mes7AfterYear +
                                                    x.Mes8AfterYear +
                                                    x.Mes9AfterYear +
                                                    x.Mes10AfterYear) / 12) * x.ValorDeReferencia,
                                    Total = (
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear +
                                                    x.Mes7AfterYear +
                                                    x.Mes8AfterYear +
                                                    x.Mes9AfterYear +
                                                    x.Mes10AfterYear),

                                    TotalEmReal = (
                                                    x.Mes11CurrYear +
                                                    x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear +
                                                    x.Mes7AfterYear +
                                                    x.Mes8AfterYear +
                                                    x.Mes9AfterYear +
                                                    x.Mes10AfterYear) * x.ValorDeReferencia,

                                    Mes1 = x.Mes11CurrYear,
                                    Mes2 = x.Mes12CurrYear,
                                    Mes3 = x.Mes1AfterYear,
                                    Mes4 = x.Mes2AfterYear,
                                    Mes5 = x.Mes3AfterYear,
                                    Mes6 = x.Mes4AfterYear,
                                    Mes7 = x.Mes5AfterYear,
                                    Mes8 = x.Mes6AfterYear,
                                    Mes9 = x.Mes7AfterYear,
                                    Mes10 = x.Mes8AfterYear,
                                    Mes11 = x.Mes9AfterYear,
                                    Mes12 = x.Mes10AfterYear,
                                    MaterialBloqueado = x.MaterialBloqueado,
                                    MaterialSubstituto = x.MaterialSubstituto,


                                }
                                ).ToList();
                    };

                case 12:
                    {
                        return (from x in lista

                                select new PlmMensalizadoFiltrado()
                                {

                                    Id = x.Id,
                                    MaterialId = x.MaterialId,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialClasse = x.MaterialClasse,
                                    MaterialUM = x.MaterialUM,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    UserName = x.UserName,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    FamiliaNome = x.FamiliaNome,
                                    Sigla = x.Sigla,
                                    DiretoriaNome = x.DiretoriaNome,
                                    SubDiretoriaNome = x.SubDiretoriaNome,
                                    PlmProjeto = x.PlmProjeto,
                                    PlmInfoAdicional = x.PlmInfoAdicional,
                                    PlmResponsavel = x.PlmResponsavel,
                                    PlmDataLanc = x.PlmDataLanc,
                                    ValorDeReferencia = x.ValorDeReferencia,

                                    Media = (x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear +
                                                    x.Mes7AfterYear +
                                                    x.Mes8AfterYear +
                                                    x.Mes9AfterYear +
                                                    x.Mes10AfterYear +
                                                    x.Mes11AfterYear) / 12,

                                    MediaEmReal = ((x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear +
                                                    x.Mes7AfterYear +
                                                    x.Mes8AfterYear +
                                                    x.Mes9AfterYear +
                                                    x.Mes10AfterYear +
                                                    x.Mes11AfterYear) / 12) * x.ValorDeReferencia,

                                    Total = (x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear +
                                                    x.Mes7AfterYear +
                                                    x.Mes8AfterYear +
                                                    x.Mes9AfterYear +
                                                    x.Mes10AfterYear +
                                                    x.Mes11AfterYear),

                                    TotalEmReal = (x.Mes12CurrYear +
                                                    x.Mes1AfterYear +
                                                    x.Mes2AfterYear +
                                                    x.Mes3AfterYear +
                                                    x.Mes4AfterYear +
                                                    x.Mes5AfterYear +
                                                    x.Mes6AfterYear +
                                                    x.Mes7AfterYear +
                                                    x.Mes8AfterYear +
                                                    x.Mes9AfterYear +
                                                    x.Mes10AfterYear +
                                                    x.Mes11AfterYear) * x.ValorDeReferencia,


                                    Mes1 = x.Mes12CurrYear,
                                    Mes2 = x.Mes1AfterYear,
                                    Mes3 = x.Mes2AfterYear,
                                    Mes4 = x.Mes3AfterYear,
                                    Mes5 = x.Mes4AfterYear,
                                    Mes6 = x.Mes5AfterYear,
                                    Mes7 = x.Mes6AfterYear,
                                    Mes8 = x.Mes7AfterYear,
                                    Mes9 = x.Mes8AfterYear,
                                    Mes10 = x.Mes9AfterYear,
                                    Mes11 = x.Mes10AfterYear,
                                    Mes12 = x.Mes11AfterYear,

                                    MaterialBloqueado = x.MaterialBloqueado,
                                    MaterialSubstituto = x.MaterialSubstituto,

                                }
                                ).ToList();
                    };

                default:
                    return null;
            }
        }

        public static IList<PlmMensalizadoFiltrado> CastingPlmFiltro(IEnumerable<VPlmMensalizadoLastYear> lista)
        {
            return (from x in lista

                    select new PlmMensalizadoFiltrado()
                    {

                        Id = x.Id,
                        MaterialId = x.MaterialId,
                        EmpresaNome = x.EmpresaNome,
                        CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                        MaterialCodSap = x.MaterialCodSap,
                        MaterialDescricao = x.MaterialDescricao,
                        MaterialClasse = x.MaterialClasse,
                        MaterialUM = x.MaterialUM,
                        ClassificacaoNome = x.ClassificacaoNome,
                        UserName = x.UserName,
                        MGCodeCodigoSap = x.MGCodeCodigoSap,
                        MGCodeDescricao = x.MGCodeDescricao,
                        FamiliaNome = x.FamiliaNome,
                        Sigla = x.Sigla,
                        DiretoriaNome = x.DiretoriaNome,
                        SubDiretoriaNome = x.SubDiretoriaNome,
                        PlmProjeto = x.PlmProjeto,
                        PlmInfoAdicional = x.PlmInfoAdicional,
                        PlmResponsavel = x.PlmResponsavel,
                        PlmDataLanc = x.PlmDataLanc,
                        ValorDeReferencia = x.ValorDeReferencia,
                        Media = x.Media,
                        MediaEmReal = x.MediaEmReal,
                        Total = x.Total,
                        TotalEmReal = x.TotalEmReal,
                        Mes1 = x.Mes1,
                        Mes2 = x.Mes2,
                        Mes3 = x.Mes3,
                        Mes4 = x.Mes4,
                        Mes5 = x.Mes5,
                        Mes6 = x.Mes6,
                        Mes7 = x.Mes7,
                        Mes8 = x.Mes8,
                        Mes9 = x.Mes9,
                        Mes10 = x.Mes10,
                        Mes11 = x.Mes11,
                        Mes12 = x.Mes12,
                        MaterialBloqueado = x.MaterialBloqueado,
                        MaterialSubstituto = x.MaterialSubstituto,
                    }
                                    ).ToList();

        }

        public static IList<EstoqueHistoricoFiltrado> EstHist(IList<VEstoqueHistorico> lista)
        {
            var mes = DateTime.Now.Month;

            switch (mes)
            {
                case 1:
                    {
                        return (from x in lista
                                select new EstoqueHistoricoFiltrado()
                                {
                                    EmpresaID = x.EmpresaID,

                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialUM = x.MaterialUM,
                                    MaterialClasse = x.MaterialClasse,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    FamiliaNome = x.FamiliaNome,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    UserName = x.UserName,
                                    TipoDaInfo = x.TipoDaInfo,
                                    Acumulado = (x.M12 + x.M11 + x.M10 + x.M9 + x.M8 + x.M7 + x.M6 + x.M5 + x.M4 + x.M3 + x.M2 + x.M1),
                                    Media = (x.M12 + x.M11 + x.M10 + x.M9 + x.M8 + x.M7 + x.M6 + x.M5 + x.M4 + x.M3 + x.M2 + x.M1) / 12,
                                    M1 = x.M1,
                                    M2 = x.M2,
                                    M3 = x.M3,
                                    M4 = x.M4,
                                    M5 = x.M5,
                                    M6 = x.M6,
                                    M7 = x.M7,
                                    M8 = x.M8,
                                    M9 = x.M9,
                                    M10 = x.M10,
                                    M11 = x.M11,
                                    M12 = x.M12,

                                    DataLanc = x.DataLanc,

                                }).ToList();

                    }

                case 2:
                    {
                        return (from x in lista
                                select new EstoqueHistoricoFiltrado()
                                {
                                    EmpresaID = x.EmpresaID,
                                    MaterialID = x.MaterialID,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialUM = x.MaterialUM,
                                    MaterialClasse = x.MaterialClasse,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    FamiliaNome = x.FamiliaNome,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    UserName = x.UserName,
                                    TipoDaInfo = x.TipoDaInfo,
                                    Acumulado = x.M12,
                                    Media = x.M12,
                                    M1 = x.M1,
                                    M2 = x.M2,
                                    M3 = x.M3,
                                    M4 = x.M4,
                                    M5 = x.M5,
                                    M6 = x.M6,
                                    M7 = x.M7,
                                    M8 = x.M8,
                                    M9 = x.M9,
                                    M10 = x.M10,
                                    M11 = x.M11,
                                    M12 = x.M12,
                                    DataLanc = x.DataLanc,

                                }).ToList();


                    }

                case 3:
                    {
                        return (from x in lista
                                select new EstoqueHistoricoFiltrado()
                                {
                                    EmpresaID = x.EmpresaID,
                                    MaterialID = x.MaterialID,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialUM = x.MaterialUM,
                                    MaterialClasse = x.MaterialClasse,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    FamiliaNome = x.FamiliaNome,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    UserName = x.UserName,
                                    TipoDaInfo = x.TipoDaInfo,
                                    Acumulado = x.M12 + x.M11,
                                    Media = (x.M12 + x.M11) / 2,
                                    M1 = x.M1,
                                    M2 = x.M2,
                                    M3 = x.M3,
                                    M4 = x.M4,
                                    M5 = x.M5,
                                    M6 = x.M6,
                                    M7 = x.M7,
                                    M8 = x.M8,
                                    M9 = x.M9,
                                    M10 = x.M10,
                                    M11 = x.M11,
                                    M12 = x.M12,
                                    DataLanc = x.DataLanc,

                                }).ToList();

                    }

                case 4:
                    {
                        return (from x in lista
                                select new EstoqueHistoricoFiltrado()
                                {
                                    EmpresaID = x.EmpresaID,
                                    MaterialID = x.MaterialID,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialUM = x.MaterialUM,
                                    MaterialClasse = x.MaterialClasse,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    FamiliaNome = x.FamiliaNome,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    UserName = x.UserName,
                                    TipoDaInfo = x.TipoDaInfo,
                                    Acumulado = x.M12 + x.M11 + x.M10,
                                    Media = (x.M12 + x.M11 + x.M10) / 3,
                                    M1 = x.M1,
                                    M2 = x.M2,
                                    M3 = x.M3,
                                    M4 = x.M4,
                                    M5 = x.M5,
                                    M6 = x.M6,
                                    M7 = x.M7,
                                    M8 = x.M8,
                                    M9 = x.M9,
                                    M10 = x.M10,
                                    M11 = x.M11,
                                    M12 = x.M12,
                                    DataLanc = x.DataLanc,

                                }).ToList();

                    }

                case 5:
                    {
                        return (from x in lista
                                select new EstoqueHistoricoFiltrado()
                                {
                                    EmpresaID = x.EmpresaID,
                                    MaterialID = x.MaterialID,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialUM = x.MaterialUM,
                                    MaterialClasse = x.MaterialClasse,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    FamiliaNome = x.FamiliaNome,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    UserName = x.UserName,
                                    TipoDaInfo = x.TipoDaInfo,
                                    Acumulado = x.M12 + x.M11 + x.M10 + x.M9,
                                    Media = (x.M12 + x.M11 + x.M10 + x.M9) / 4,
                                    M1 = x.M1,
                                    M2 = x.M2,
                                    M3 = x.M3,
                                    M4 = x.M4,
                                    M5 = x.M5,
                                    M6 = x.M6,
                                    M7 = x.M7,
                                    M8 = x.M8,
                                    M9 = x.M9,
                                    M10 = x.M10,
                                    M11 = x.M11,
                                    M12 = x.M12,
                                    DataLanc = x.DataLanc,

                                }).ToList();

                    }

                case 6:
                    {
                        return (from x in lista
                                select new EstoqueHistoricoFiltrado()
                                {
                                    EmpresaID = x.EmpresaID,
                                    MaterialID = x.MaterialID,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialUM = x.MaterialUM,
                                    MaterialClasse = x.MaterialClasse,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    FamiliaNome = x.FamiliaNome,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    UserName = x.UserName,
                                    TipoDaInfo = x.TipoDaInfo,
                                    Acumulado = x.M12 + x.M11 + x.M10 + x.M9 + x.M8,
                                    Media = (x.M12 + x.M11 + x.M10 + x.M9 + x.M8) / 5,
                                    M1 = x.M1,
                                    M2 = x.M2,
                                    M3 = x.M3,
                                    M4 = x.M4,
                                    M5 = x.M5,
                                    M6 = x.M6,
                                    M7 = x.M7,
                                    M8 = x.M8,
                                    M9 = x.M9,
                                    M10 = x.M10,
                                    M11 = x.M11,
                                    M12 = x.M12,
                                    DataLanc = x.DataLanc,

                                }).ToList();

                    }

                case 7:
                    {
                        return (from x in lista
                                select new EstoqueHistoricoFiltrado()
                                {
                                    EmpresaID = x.EmpresaID,
                                    MaterialID = x.MaterialID,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialUM = x.MaterialUM,
                                    MaterialClasse = x.MaterialClasse,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    FamiliaNome = x.FamiliaNome,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    UserName = x.UserName,
                                    TipoDaInfo = x.TipoDaInfo,
                                    Acumulado = (x.M12 + x.M11 + x.M10 + x.M9 + x.M8 + x.M7),
                                    Media = (x.M12 + x.M11 + x.M10 + x.M9 + x.M8 + x.M7) / 6,
                                    M1 = x.M1,
                                    M2 = x.M2,
                                    M3 = x.M3,
                                    M4 = x.M4,
                                    M5 = x.M5,
                                    M6 = x.M6,
                                    M7 = x.M7,
                                    M8 = x.M8,
                                    M9 = x.M9,
                                    M10 = x.M10,
                                    M11 = x.M11,
                                    M12 = x.M12,
                                    DataLanc = x.DataLanc,

                                }).ToList();

                    }
                case 8:
                    {
                        return (from x in lista
                                select new EstoqueHistoricoFiltrado()
                                {
                                    EmpresaID = x.EmpresaID,
                                    MaterialID = x.MaterialID,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialUM = x.MaterialUM,
                                    MaterialClasse = x.MaterialClasse,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    FamiliaNome = x.FamiliaNome,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    UserName = x.UserName,
                                    TipoDaInfo = x.TipoDaInfo,
                                    Acumulado = (x.M12 + x.M11 + x.M10 + x.M9 + x.M8 + x.M7 + x.M6),
                                    Media = (x.M12 + x.M11 + x.M10 + x.M9 + x.M8 + x.M7 + x.M6) / 7,
                                    M1 = x.M1,
                                    M2 = x.M2,
                                    M3 = x.M3,
                                    M4 = x.M4,
                                    M5 = x.M5,
                                    M6 = x.M6,
                                    M7 = x.M7,
                                    M8 = x.M8,
                                    M9 = x.M9,
                                    M10 = x.M10,
                                    M11 = x.M11,
                                    M12 = x.M12,
                                    DataLanc = x.DataLanc,

                                }).ToList();

                    }
                case 9:
                    {
                        return (from x in lista
                                select new EstoqueHistoricoFiltrado()
                                {
                                    EmpresaID = x.EmpresaID,
                                    MaterialID = x.MaterialID,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialUM = x.MaterialUM,
                                    MaterialClasse = x.MaterialClasse,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    FamiliaNome = x.FamiliaNome,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    UserName = x.UserName,
                                    TipoDaInfo = x.TipoDaInfo,
                                    Acumulado = (x.M12 + x.M11 + x.M10 + x.M9 + x.M8 + x.M7 + x.M6 + x.M5),
                                    Media = (x.M12 + x.M11 + x.M10 + x.M9 + x.M8 + x.M7 + x.M6 + x.M5) / 8,
                                    M1 = x.M1,
                                    M2 = x.M2,
                                    M3 = x.M3,
                                    M4 = x.M4,
                                    M5 = x.M5,
                                    M6 = x.M6,
                                    M7 = x.M7,
                                    M8 = x.M8,
                                    M9 = x.M9,
                                    M10 = x.M10,
                                    M11 = x.M11,
                                    M12 = x.M12,
                                    DataLanc = x.DataLanc,

                                }).ToList();

                    }
                case 10:
                    {
                        return (from x in lista
                                select new EstoqueHistoricoFiltrado()
                                {
                                    EmpresaID = x.EmpresaID,
                                    MaterialID = x.MaterialID,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialUM = x.MaterialUM,
                                    MaterialClasse = x.MaterialClasse,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    FamiliaNome = x.FamiliaNome,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    UserName = x.UserName,
                                    TipoDaInfo = x.TipoDaInfo,
                                    Acumulado = (x.M12 + x.M11 + x.M10 + x.M9 + x.M8 + x.M7 + x.M6 + x.M5 + x.M4),
                                    Media = (x.M12 + x.M11 + x.M10 + x.M9 + x.M8 + x.M7 + x.M6 + x.M5 + x.M4) / 9,
                                    M1 = x.M1,
                                    M2 = x.M2,
                                    M3 = x.M3,
                                    M4 = x.M4,
                                    M5 = x.M5,
                                    M6 = x.M6,
                                    M7 = x.M7,
                                    M8 = x.M8,
                                    M9 = x.M9,
                                    M10 = x.M10,
                                    M11 = x.M11,
                                    M12 = x.M12,
                                    DataLanc = x.DataLanc,

                                }).ToList();

                    }
                case 11:
                    {
                        return (from x in lista
                                select new EstoqueHistoricoFiltrado()
                                {
                                    EmpresaID = x.EmpresaID,
                                    MaterialID = x.MaterialID,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialUM = x.MaterialUM,
                                    MaterialClasse = x.MaterialClasse,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    FamiliaNome = x.FamiliaNome,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    UserName = x.UserName,
                                    TipoDaInfo = x.TipoDaInfo,
                                    Acumulado = (x.M12 + x.M11 + x.M10 + x.M9 + x.M8 + x.M7 + x.M6 + x.M5 + x.M4 + x.M3),
                                    Media = (x.M12 + x.M11 + x.M10 + x.M9 + x.M8 + x.M7 + x.M6 + x.M5 + x.M4 + x.M3) / 10,
                                    M1 = x.M1,
                                    M2 = x.M2,
                                    M3 = x.M3,
                                    M4 = x.M4,
                                    M5 = x.M5,
                                    M6 = x.M6,
                                    M7 = x.M7,
                                    M8 = x.M8,
                                    M9 = x.M9,
                                    M10 = x.M10,
                                    M11 = x.M11,
                                    M12 = x.M12,
                                    DataLanc = x.DataLanc,

                                }).ToList();

                    }

                default:
                    {
                        return (from x in lista
                                select new EstoqueHistoricoFiltrado()
                                {
                                    EmpresaID = x.EmpresaID,
                                    MaterialID = x.MaterialID,
                                    EmpresaNome = x.EmpresaNome,
                                    CentroLogisticoCodSap = x.CentroLogisticoCodSap,
                                    MaterialCodSap = x.MaterialCodSap,
                                    MaterialDescricao = x.MaterialDescricao,
                                    MaterialUM = x.MaterialUM,
                                    MaterialClasse = x.MaterialClasse,
                                    ClassificacaoNome = x.ClassificacaoNome,
                                    FamiliaNome = x.FamiliaNome,
                                    MGCodeCodigoSap = x.MGCodeCodigoSap,
                                    MGCodeDescricao = x.MGCodeDescricao,
                                    UserName = x.UserName,
                                    TipoDaInfo = x.TipoDaInfo,
                                    Acumulado = (x.M12 + x.M11 + x.M10 + x.M9 + x.M8 + x.M7 + x.M6 + x.M5 + x.M4 + x.M3 + x.M2),
                                    Media = (x.M12 + x.M11 + x.M10 + x.M9 + x.M8 + x.M7 + x.M6 + x.M5 + x.M4 + x.M3 + x.M2) / 11,
                                    M1 = x.M1,
                                    M2 = x.M2,
                                    M3 = x.M3,
                                    M4 = x.M4,
                                    M5 = x.M5,
                                    M6 = x.M6,
                                    M7 = x.M7,
                                    M8 = x.M8,
                                    M9 = x.M9,
                                    M10 = x.M10,
                                    M11 = x.M11,
                                    M12 = x.M12,
                                    DataLanc = x.DataLanc,

                                }).ToList();

                    }

            }
        }
        

    }

  


    public class PlmMensalizadoFiltrado
    {
        public Guid Id { get; set; }
        public int MaterialId { get; set; }
        public string EmpresaNome { get; set; }
        [StringLength(4)]
        public string CentroLogisticoCodSap { get; set; }
        [StringLength(10)]
        public string MaterialCodSap { get; set; }
        //[StringLength(1)]
        //public string Appia             { get; set; }
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
        public decimal? ValorDeReferencia { get; set; }
        public decimal? Mes1 { get; set; }
        public decimal? Mes2 { get; set; }
        public decimal? Mes3 { get; set; }
        public decimal? Mes4 { get; set; }
        public decimal? Mes5 { get; set; }
        public decimal? Mes6 { get; set; }
        public decimal? Mes7 { get; set; }
        public decimal? Mes8 { get; set; }
        public decimal? Mes9 { get; set; }
        public decimal? Mes10 { get; set; }
        public decimal? Mes11 { get; set; }
        public decimal? Mes12 { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalEmReal { get; set; }
        public decimal? Media { get; set; }
        public decimal? MediaEmReal { get; set; }
        public bool MaterialBloqueado { get; set; }
        public string MaterialSubstituto { get; set; }

    }


    public class EstoqueHistoricoFiltrado
    {
        public Guid Id { get; set; }
        public long EmpresaID { get; set; }
        public int MaterialID { get; set; }
        public string EmpresaNome { get; set; }
        [StringLength(5)]
        public string CentroLogisticoCodSap { get; set; }
        [StringLength(10)]
        public string MaterialCodSap { get; set; }
        public string MaterialDescricao { get; set; }
        [StringLength(5)]
        public string MaterialUM { get; set; }
        [StringLength(2)]
        public string MaterialClasse { get; set; }
        [StringLength(30)]
        public string ClassificacaoNome { get; set; }
        public string FamiliaNome { get; set; }
        [StringLength(10)]
        public string MGCodeCodigoSap { get; set; }
        public string MGCodeDescricao { get; set; }
        public string UserName { get; set; }
        public TipoDaInfo TipoDaInfo { get; set; }
        public decimal Acumulado { get; set; }
        public decimal Media { get; set; }
        public decimal M1 { get; set; }
        public decimal M2 { get; set; }
        public decimal M3 { get; set; }
        public decimal M4 { get; set; }
        public decimal M5 { get; set; }
        public decimal M6 { get; set; }
        public decimal M7 { get; set; }
        public decimal M8 { get; set; }
        public decimal M9 { get; set; }
        public decimal M10 { get; set; }
        public decimal M11 { get; set; }
        public decimal M12 { get; set; }
        public DateTime DataLanc { get; set; }
        public bool MaterialBloqueado { get; set; }
        public string MaterialSubstituto { get; set; }
    }
}