using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NimapProjectUsingADO.net.Models;

namespace NimapProjectUsingADO.net.Controllers
{
    public class CategoryController : Controller
    {
        //private readonly IConfiguration configuration;
        //private CategoryyCrud db;

        private readonly ICategoryyService db;

        public CategoryController(ICategoryyService db)
        {
            this.db=db;
        }
        public ActionResult Index(int pg)
        {
            var m = db.GetCategory();
           
            const int pagesize = 10;
            if (pg < 1)
            {
                pg = 1;
            }

            int recscount = m.Count();

            var pager = new Pager(recscount, pg, pagesize);

            int recskip = (pg - 1) * pagesize;

            var data = m.Skip(recskip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            return View(m);
        
       
        }

       
        public ActionResult Details(int id)
        {
            var t =db.GetCategoryyById(id);
            return View(t);
        }

      
       
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoryy c)
        {
            try
            {
                int result = db.AddCategory(c);
                if (result >= 1)
                    return RedirectToAction(nameof(Index));
                else
                    TempData["message"] = "not able to add";
                return View();
            }
            catch(Exception ex)
            {
                TempData["exp"] = ex.Message;
                return View();
            }
        }

       
        public ActionResult Edit(int id)
        {
            var v = db.GetCategoryyById(id);
            return View(v);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoryy c)
        {
            try
            {
                int result = db.UpdtateCategory(c);
                if(result>=1)
                return RedirectToAction(nameof(Index));
                else
                    TempData["message"] = "not able to add";
                return View();

            }
            catch(Exception ex)
            {
                TempData["exp"] = ex.Message;
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            var d = db.DeleteCategory(id);
            if(d==null)
            {
                return NotFound();
            }
            return View(d);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Deletec(int id)
        {
            try
            {
                int result = db.DeleteCategory(id);
                if(result>=1)
                return RedirectToAction(nameof(Index));
                else
                TempData["message"] = "not able to add";
                return View();

            }
            catch (Exception ex)
            {
                TempData["exp"] = ex.Message;
                return View();
            }
        }
    }
}
