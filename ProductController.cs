using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NimapProjectUsingADO.net.Models;

namespace NimapProjectUsingADO.net.Controllers
{
   
        public class ProductController : Controller
        {
            private readonly IConfiguration configuration;
            private ProducttCrud pcrud;
            private CategoryyCrud ccrud;

            public ProductController(IConfiguration configuration)
            {
                this.configuration = configuration;
                pcrud = new ProducttCrud(this.configuration);
                ccrud = new CategoryyCrud(this.configuration);
            }
            public IActionResult Index(int pg)
            {
                var products = pcrud.GetProducts();
                const int pagesize = 10;
                if (pg < 1)
                {
                    pg = 1;
                }
                int recscount = products.Count();
                var pager = new Pager(recscount, pg, pagesize);
                int recskip = (pg - 1) * pagesize;
                var data = products.Skip(recskip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;
                return View(data);
                var product = pcrud.GetProducts();
                return View(product);
            }


            public IActionResult Details(int id)
            {
                var product = pcrud.GetProductById(id);
                return View(product);
            }
            [HttpGet]
            public IActionResult Create()
            {
            //ViewBag.clist = ccrud.GetCategory();
            //return View();
            var cat = ccrud.GetCategory();
            ViewData["CategoryId"]=new SelectList(cat,"CategoryId","CategoryName");
            return View(cat);
            }
            [HttpPost]
            public IActionResult Create(Productt p)
            {
                try
                {
                    int result = pcrud.AddProduct(p);
                    if (result >= 1)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        TempData["message"] = "Not Able to Add Data";
                        return View();
                    }
                }
                catch (Exception ex)
                {
                    TempData["exp"] = ex.Message;
                    return View();
                }

            }
            public IActionResult Edit(int id)
            {
                var p = pcrud.GetProductById(id);
                ViewBag.clist = ccrud.GetCategory();
                return View(p);

            }
            [HttpPost]
            public IActionResult Edit(Productt p)
            {
                int result = 0;
                result = pcrud.UpdtateProduct(p);
                if (result >= 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["message"] = "Product Not Update";
                    return View();
                }

            }

            [HttpGet]
            public IActionResult Delete(int id)
            {
                var p = pcrud.GetProductById(id);
                return View(p);

            }

            [HttpPost]
            [ActionName("Delete")]
            public IActionResult DeleteConfirm(int id)
            {
                try
                {
                    int result = pcrud.DeleteProduct(id);
                    if (result >= 1)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["message"] = "Not Able to Update Data";
                        return View();
                    }
                }
                catch (Exception ex)
                {
                    TempData["exp"] = ex.Message;
                    return View();
                }

            }
        }
    }
   