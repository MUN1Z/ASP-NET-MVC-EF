using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class PessoaController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Menssagem = "Minha view";
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PessoaModels pessoa)
        {
            ModelState.Remove("Codigo");
            List<PessoaModels> lista = new List<PessoaModels>();

            if(ModelState.IsValid)
            {
                if (Session["ListaPessoas"] != null)
                    lista.AddRange((List<PessoaModels>) Session["ListaPessoas"]);

                pessoa.Codigo = lista.Count + 1;

                lista.Add(pessoa);
            
                Session["ListaPessoas"] = lista;

                return View("List", lista);
            }
            else
                return View(pessoa);

        }

        public ActionResult List()
        {

            if (Session["ListaPessoas"] != null)
                return View((List<PessoaModels>)Session["ListaPessoas"]);

            return View();
        }

        public ActionResult Edit(int id)
        {
            if (((List<PessoaModels>) Session["ListaPessoas"]).Where(c => c.Codigo.Equals(id)).Any())
            {
                var model = ((List<PessoaModels>)Session["ListaPessoas"]).Where(c => c.Codigo.Equals(id)).FirstOrDefault();
                return View("Create", model);
            }

            return View("Create");
        }

        [HttpPost]
        public ActionResult Edit(PessoaModels model)
        {
            if (((List<PessoaModels>) Session["ListaPessoas"]).Where(c => c.Codigo.Equals(model.Codigo)).Any())
            {
                var modelBase = ((List<PessoaModels>)Session["ListaPessoas"]).Where(c => c.Codigo.Equals(model.Codigo)).FirstOrDefault();
                ((List<PessoaModels>)Session["ListaPessoas"])[modelBase.Codigo - 1] = model;
            }
            
            var lista = ((List<PessoaModels>)Session["ListaPessoas"]);

            return View("List", lista);
        }

        public ActionResult Delete(int id)
        {
            if (((List<PessoaModels>)Session["ListaPessoas"]).Where(c => c.Codigo.Equals(id)).Any())
            {
                var modelBase = ((List<PessoaModels>)Session["ListaPessoas"]).Where(c => c.Codigo.Equals(id)).FirstOrDefault();
                var lista = ((List<PessoaModels>)Session["ListaPessoas"]);
                lista.Remove(modelBase);
                Session["ListaPessoas"] = lista;
                return View("List", lista);
            }

            return View("List", ((List<PessoaModels>)Session["ListaPessoas"]));
        }
    }
}