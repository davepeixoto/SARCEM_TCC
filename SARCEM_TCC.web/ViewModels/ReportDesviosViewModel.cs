using System.Collections;

namespace SARCEM_TCC.web.ViewModels
{
    public class ReportDesviosViewModel
    {
        public ReportDesviosViewModel()
        {
            estoque = new ArrayList();
            consumo = new ArrayList();
            entrada = new ArrayList();
            plm     = new ArrayList();
            appia   = new ArrayList();
            periodo = new ArrayList();
            
            
        }
        public ArrayList estoque { get; set; }
        public ArrayList consumo { get; set; }
        public ArrayList entrada { get; set; }
        public ArrayList plm     { get; set; }
        public ArrayList appia   { get; set; }
        public ArrayList periodo { get; set; }
    }
}