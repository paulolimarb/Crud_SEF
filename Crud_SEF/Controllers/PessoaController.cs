using Crud_SEF.DAL;
using Crud_SEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Crud_SEF.Controllers
{
    public class PessoaController : Controller
    {
        PessoaDal db = new PessoaDal();

        // GET: Pessoa
        public ActionResult Index()
        {
            List<Pessoa> lst = db.list();

            return View(lst);
        }

        [HttpGet]
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(Pessoa ps)
        {
            db.create(ps);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult edit(int id)
        {
            Pessoa ps = db.getID(id);

            return View(ps);
        }

        [HttpPost]
        public ActionResult edit(Pessoa ps)
        {
            db.edit(ps);

            return RedirectToAction("Index");

        }
        
        public ActionResult details(int id)
        {
            Pessoa ps = db.getID(id);

            return View(ps);
        }

        [HttpGet]
        public ActionResult delete(int id)
        {
            Pessoa ps = db.getID(id);

            return View(ps);
        }

        [HttpPost]
        public ActionResult delete(Pessoa ps)
        {
            db.delete(ps.id);

            return RedirectToAction("Index");
        }



    }
}