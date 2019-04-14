using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARCEM_TCC.web.Models.Domain.DataMass
{
    [Table("Me2ms")]
    public class Me2m
    {
        public long Me2mID { get; set; }
        public int? Me2mItem { get; set; }
        public DateTime? Me2mDataDoc { get; set; }
        public string Me2mDocCompra { get; set; }
       
        public int? MaterialID { get; set; }
        public string Me2mRegInfo { get; set; }
        public int? Me2mCentroOrigem { get; set; }
        public long? FornecedorID { get; set; }
        public string Me2mE { get; set; }
        public int? Me2mCentroRecebedor { get; set; }
        public int? Me2mDep { get; set; }
        public decimal? Me2mQtdPedida { get; set; }
        public decimal? Me2mQtdeAfornecer { get; set; }
        public decimal? Me2mPrecoLiq { get; set; }
        public string Me2mMoeda { get; set; }
        public string Me2mTipo { get; set; }

        public virtual CentroLogistico CentroLogisticosOrig { get; set; }
        public virtual CentroLogistico CentroLogisticosRec { get; set; }
        public virtual Material Material { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}