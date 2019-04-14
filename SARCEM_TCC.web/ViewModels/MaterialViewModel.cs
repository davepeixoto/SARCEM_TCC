using SARCEM_TCC.web.Models.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SARCEM_TCC.web.ViewModels
{
    public class MaterialViewModel
    {
        
        public int MaterialID { get; set; }

        public long EmpresaID { get; set; }
        public string EmpresaNome { get; set; }

        [Display(Name = "Material: ")]
        public string MaterialCodSap { get; set; }


        [Required(ErrorMessage = "É necessário informar a Descrição.")]
        [Display(Name = "Descrição: ")]
        public string MaterialDescricao { get; set; }


        [Required(ErrorMessage = "É necessário informar a Classe.")]
        [StringLength(2)]
        [Display(Name = "Classe: ")]
        public string MaterialClasse { get; set; }

        [Required(ErrorMessage = "É necessário informar a Classificação.")]
        [Display(Name = "Unidade de Medida: ")]
        [StringLength(3)]
        public string MaterialUM { get; set; }

        [Required(ErrorMessage = "É necessário informar a Classificação.")]
        [Display(Name = "Classificação: ")]
        public int ClassificacaoID { get; set; }

        [Required(ErrorMessage = "É necessário informar a Família.")]
        [Display(Name = "Família: ")]
        public int FamiliaID { get; set; }

        [Required(ErrorMessage = "É necessário informar o MG Code.")]
        [Display(Name = "MG Code: ")]
        public int MGCodeID { get; set; }


        [Display(Name = "Marque para bloquear o material.")]
        public bool MaterialBloqueado { get; set; }


        [Display(Name = "Selecione caso haja algum material substituto.")]
        public int? MaterialSubId { get; set; }


        //[DataType(DataType.Currency)]
        [Display(Name = "Valor de Referência.")]
       // [Range(0, float.MaxValue, ErrorMessage = "É necessário informar um tipo numérico")]          
        public string ValorDeReferencia { get; set; }


        [Required(ErrorMessage = "Você deve informar o motivo da alterção.")]
        [Display(Name = "Informe o motivo da alteração.")]
        public string MaterialObservacoes { get; set; }



        public virtual List<Material> Materiais { get; set; }
        public virtual List<Classificacao> Classificacoes { get; set; }
        public virtual List<Familia> Familias { get; set; }
        public virtual List<MGCode> MGCodes { get; set; }
       // public virtual ValorReferencia ValorReferencia { get; set; }



        //[Display(Name = "Selecione a Atividade")]
        //public int UsuarioLogisticaAtividadeID { get; set; }

        //public virtual List<Empresa> Empresas { get; set; }
        //// public virtual List<UsuarioLogisticaAtividade> UsuarioLogisticaAtividades { get; set; }
    }

    //public partial class MGCodesComp: MGCode
    //{


    //    public string MgSelect { get; set; }
    //}

}