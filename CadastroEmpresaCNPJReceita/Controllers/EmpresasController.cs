using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CadastroEmpresaCNPJReceita.Models;
using Newtonsoft.Json;

namespace CadastroEmpresaCNPJReceita.Controllers
{
    public class EmpresasController : Controller
    {
        private CadastroEmpresaCNPJReceitaContext db = new CadastroEmpresaCNPJReceitaContext();

        // GET: Empresas
        public ActionResult Index()
        {
            var viewModel = new EmpresaPesquisaViewModel();
            viewModel.Resultados = db.Empresas.ToList();
            return View(viewModel);                       
        }
       
        // GET: Empresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            var resultado = new EmpresaPesquisaViewModel();
            
            if (!db.Empresas.Any())
            {
                var lista_empresas = new List<Empresa>();
                resultado.Resultados = lista_empresas;
                return View(resultado);
            }

            resultado.Resultados = db.Empresas.ToList();
            return View(resultado);
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpresaPesquisaViewModel viewModel)
        {
            if (viewModel.CNPJ != string.Empty && viewModel.CNPJ != null)
            {
                String url = "https://www.receitaws.com.br/v1/cnpj/" + viewModel.CNPJ;

                String json = JSONHelper.GetJSONString(url);

                var empresa_resultado = JsonConvert.DeserializeObject<Empresa>(json);

                if(empresa_resultado.Status != "ERROR")
                {                   
                    db.Empresas.Add(empresa_resultado);
                    db.SaveChanges();
                }
                else
                {
                    viewModel.Status = empresa_resultado.StatusMensagem;
                }
            }
            
            viewModel.Resultados = db.Empresas.ToList();
            return View(viewModel);
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpresaId,Cnpj,Tipo,Abertura,Nome,Fantasia")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empresa empresa = db.Empresas.Find(id);
            db.Empresas.Remove(empresa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
