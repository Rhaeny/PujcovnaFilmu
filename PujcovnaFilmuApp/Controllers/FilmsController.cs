using System.Linq;
using System.Net;
using System.Web.Mvc;
using BL.ClassesBL;
using BL.ModelsBL;

namespace PujcovnaFilmuApp.Controllers
{
    public class FilmsController : Controller
    {
        // GET: Films
        public ActionResult Index()
        {
            FilmBL filmDB = new FilmBL();
            return View(filmDB.Select().ToList());
        }

        // GET: Films/Details/5
        public ActionResult Details(int id)
        {
            FilmBL filmDB = new FilmBL();
            FilmModel film = filmDB.Detail(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Films/Create
        /*public ActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
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
        }*/

        // GET: Films/Edit/5
        public ActionResult Edit(int id)
        {
            FilmBL filmDB = new FilmBL();
            FilmModel film = filmDB.Detail(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Films/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FilmModel film)
        {
            try
            {
                FilmBL filmDB = new FilmBL();
                filmDB.Update(film);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(film);
            }
        }

        // GET: Films/Delete/5
        /*public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Films/Delete/5
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
        }*/
    }
}
