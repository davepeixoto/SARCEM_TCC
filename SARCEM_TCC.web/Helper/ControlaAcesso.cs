using SARCEM_TCC.web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace SARCEM_TCC.web.Helper
{
    public static class ControlaAcesso
    {
        public static IEnumerable<string> TrazSubDiretoria(IPrincipal User)
        {
            var temp = new List<string>();
            if (User.IsInRole(RoleName.ManutencaoAT))
                temp.Add( "Manutenção AT");

            if (User.IsInRole(RoleName.ObrasAT))
                temp.Add("Obras AT");


            if (User.IsInRole(RoleName.ObrasMT))
                temp.Add("Obras MT/BT");

            if (User.IsInRole(RoleName.ManutencaoMT))
                temp.Add("Operação e Manutenção MT/BT");

            if (User.IsInRole(RoleName.Comercial))
                temp.Add("Operações Comerciais");

            if (User.IsInRole(RoleName.SistemasAT))
                temp.Add("Sistemas AT");

            return temp;

        }

        public static string TrazEmpresa(IPrincipal User)
        {
            #region RioDeJaneiro
            if (User.IsInRole(RoleName.RioDeJaneiro))
            {
                return "Enel Rio de Janeiro";                       
            }
            #endregion

            #region Ceara
            if (User.IsInRole(RoleName.Ceara))
            {
                return "Enel Ceará";
            }
            #endregion

            #region Goias
            if (User.IsInRole(RoleName.Goias))
            {
                return "Enel Goiás";
            }
            #endregion

            if(User.IsInRole(RoleName.Brazil))
            {
                return "brasil";
            }

            return "";
        }

        public static string TrazDropDown(IPrincipal User)
        {
            if (User.IsInRole(RoleName.Cliente))
            {
                if (TrazSubDiretoria(User).ToList().Count() > 1)
                {

                    return "_DropDowns";
                }
                else
                {
                    return "_DropDownsCliente";
                }

            }
            else
            {

                if (User.IsInRole(RoleName.Brazil))
                {
                    return "_DropDownsBrazil";
                }
                else
                {

                    return "_DropDowns";
                }
            }


        }
    }
}