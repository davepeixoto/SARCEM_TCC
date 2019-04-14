using SARCEM_TCC.web.Helper;
using SARCEM_TCC.web.Data.Context;
using SARCEM_TCC.web.Models;
using SARCEM_TCC.web.Models.Domain;
using SARCEM_TCC.web.Models.Domain.DataMass;
using SARCEM_TCC.web.ViewModels;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace SARCEM_TCC.web.Controllers
{
    public class MaterialController : Controller
    {
        private ApplicationDbContext _context;
        public MaterialController()
        {
            
        }
        // GET: Materiais
        public ActionResult Index()
        {
            return View();
        }



        // GET: Materiais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Materiais/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Materiais/Edit/5
        [Authorize(Roles=RoleName.Logistica)]
        public ActionResult Edit(int id)

        {
            _context = new ApplicationDbContext();


            var valorReferencia = _context.ValorReferencias.Where(c => c.MaterialID == id).First();
            var viewModel = new MaterialViewModel
            {
                EmpresaID = valorReferencia.EmpresaID,
                EmpresaNome = valorReferencia.EmpresaNome,
                MaterialID = valorReferencia.MaterialID,
                MaterialCodSap = valorReferencia.MaterialCodSap,
                MaterialDescricao = valorReferencia.MaterialDescricao,
                MaterialClasse = valorReferencia.MaterialClasse,
                MaterialUM = valorReferencia.MaterialUM,
                ClassificacaoID = valorReferencia.ClassificacaoID,
                FamiliaID = valorReferencia.FamiliaID,
                MGCodeID = valorReferencia.MGCodeID,
                MaterialBloqueado =valorReferencia.MaterialBloqueado ,
                MaterialSubId = valorReferencia.MaterialSubId ==null? 0 : valorReferencia.MaterialSubId,
                ValorDeReferencia = string.Format("{0:N}",valorReferencia.ValorDeReferencia),
                //ValorDeReferencia = valorReferencia.ValorDeReferencia,


                Familias = _context.Familias.Where(c => c.EmpresaID == valorReferencia.EmpresaID).ToList(),
                Classificacoes = _context.Classificacoes.ToList(),
                MGCodes = _context.MGCodes.ToList(),
                Materiais = _context.Materiais.Where(c => c.Familia.EmpresaID == valorReferencia.EmpresaID).ToList(),
                


            };

            viewModel.Materiais.Add(_context.Materiais.Find(0));


            return View(viewModel);
            
        }

        // POST: Materiais/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MaterialViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                _context = new ApplicationDbContext();
            try
            {
                    var rst = _context.Materiais.FirstOrDefault(c => c.MaterialID == id);

                    rst.MaterialDescricao = viewModel.MaterialDescricao;
                    rst.MaterialClasse = viewModel.MaterialClasse;
                    rst.MaterialUM = viewModel.MaterialUM;
                    rst.FamiliaID = viewModel.FamiliaID;
                    rst.MGCodeID = viewModel.MGCodeID;
                    rst.ClassificacaoID = viewModel.ClassificacaoID;
                    rst.MaterialBloqueado = viewModel.MaterialBloqueado;
                    rst.MaterialSubId = viewModel.MaterialSubId;

                    _context.Materiais.Attach(rst);
                    _context.Entry(rst).State = System.Data.Entity.EntityState.Modified;
                    
                    var usuario = _context.Usuarios.FirstOrDefault(c => c.UserName == User.Identity.Name);


                    var comp = new HistoricoMaterial
                    {
                        MaterialID = rst.MaterialID,
                        UsuarioLogisticaID = usuario.Id,
                        HistMatDataLanc = DateTime.Now,
                        HistMatInformacoes = viewModel.MaterialObservacoes
                    };

                    
                    _context.HistoricoMateriais.Add(comp);
                    _context.Entry(comp).State = EntityState.Added;
                    _context.SaveChanges();

                 
                    var val = Conversor.StringToDecimal(viewModel.ValorDeReferencia);

                   if( _context.ValorReferencias.Where(c => c.MaterialID== id).FirstOrDefault().ValorDeReferencia != val)
                    {
                        try {
                            var prec = _context.ReferenciaDePrecos.Where(c => c.MaterialID == id).FirstOrDefault();
                            
                            prec.PrecoValor = val;
                            prec.PrecoDataLanc = DateTime.Now;
                            prec.UsuarioId = usuario.Id;

                            _context.ReferenciaDePrecos.Add(prec);
                            _context.Entry(prec).State = EntityState.Modified;
                            _context.SaveChanges();

                        }
                        catch(Exception)
                        {

                       var refPrec = new ReferenciaDePreco
                        {
                            MaterialID =     id,
                            PrecoValor =    val,
                            PrecoDataLanc = DateTime.Now,
                            UsuarioId = usuario.Id
                            
                        };
                        _context.ReferenciaDePrecos.Add(refPrec);
                        _context.Entry(refPrec).State = EntityState.Added;
                        _context.SaveChanges();
                        }


                       // _context.Dispose();

                        //AtualizaBase();

                    }

                  //  Task.Run(()=>AtualizaBase());

                  //  var i = AtualizaBase();
                  // await AtualizaBase();
                    return RedirectToAction("Index");
            }
            catch 
            {
                   
                return View("Edit/"+id);
            }
            }
            else
                return View();
        }

     

        // GET: Materiais/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Materiais/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
