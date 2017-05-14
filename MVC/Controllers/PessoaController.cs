using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using Service.Implementations;

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
        public ActionResult Create(Pessoa pessoa)
        {
            ModelState.Remove("Codigo");
            List<Pessoa> lista = new List<Pessoa>();

            if(ModelState.IsValid)
            {
                PessoaService.Salvar(pessoa);
                return View("List", PessoaService.Listar());
            }
            else
                return View(pessoa);

        }

        public ActionResult List()
        {
            return View(PessoaService.Listar());
        }

        public ActionResult Edit(int id)
        {
            return View("Create", PessoaService.Obter(id));
        }

        [HttpPost]
        public ActionResult Edit(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                PessoaService.Salvar(pessoa);
                return View("List", PessoaService.Listar());
            }
            else
                return View("Create", pessoa);
        }

        public ActionResult Delete(int id)
        {
            PessoaService.Deletar(id);
            return View("List", PessoaService.Listar());
        }
    }
}