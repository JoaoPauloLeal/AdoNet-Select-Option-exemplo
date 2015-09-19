using AdoNet_Select_Option_exemplo.Models.Entity;
using AdoNet_Select_Option_exemplo.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoNet_Select_Option_exemplo.Controllers
{
    public class HomeController : Controller
    {

        AutorRepository Autor = new AutorRepository();
        
        // GET: Home
        public ActionResult Index()
        {
            return View(Autor.Get());
        }

        /// <summary>
        /// Action para criar um novo autor
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            //carrega as cidades numa viewbag para carregar a select option
            ViewBag.Cidades = CidadeRepository.Get();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Autor pAutor)
        {
            //recebe o autor com o objeto cidade, mas somente com o id da cidade.
            Autor.Create(pAutor);
            return RedirectToAction("Index");
        }

    }
}