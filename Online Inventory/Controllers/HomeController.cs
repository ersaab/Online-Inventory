using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Inventory.Models;

namespace Online_Inventory.Controllers
{
    public class HomeController : Controller
    {
        GiftsOnlineDBEntities db = new GiftsOnlineDBEntities();

        //Home Page
        public ActionResult HomePage()
        {
            return View();
        }



        //Category Page
        public ActionResult Categories()
        {
            return View();
        }


        //Main Page Category Table
        public PartialViewResult CatResult()
        {
            return PartialView(db.CategoryTables.ToList());
        }

        //Main Page CategoryAdd Model
        public PartialViewResult CatModelDataFetch()
        {
            return PartialView();
        }

        //Table View in Category Page
        public PartialViewResult CatTable()
        {
            return PartialView(db.CategoryTables.ToList());
        }

        //Adding Categories through Model from Home Page


        public ActionResult Categoriespost(CategoryTable catadd)
        {
            db.CategoryTables.Add(catadd);
            db.SaveChanges();
            return RedirectToAction("Categories", "Home");
        }

        //Editing A Category
        [HttpGet]
        public ActionResult EditCategory(int id = 0)
        {
            var check = db.CategoryTables.Where(x => x.categoryID == id).FirstOrDefault();
            return View(check);
        }

        [HttpPost]
        public ActionResult EditCategory(CategoryTable check)
        {
            if (ModelState.IsValid)
            {
                db.Entry(check).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Categories");
            }
            return View(check);
        }

        //Deleting A Category
        public ActionResult DeleteCategory(int id = 0)
        {
            var check = db.CategoryTables.Where(x => x.categoryID == id).FirstOrDefault();
            db.CategoryTables.Remove(check);
            db.SaveChanges();
            return RedirectToAction("Categories");
        }

        ///
        ///
        /// ///// ///// /////// /////// //////// //////// ///////// ///////// ////////// //////// //////// /////// //////////////////////////////////////
        /// 
        /// 

        //Product Page
        public ActionResult Products()
        {
            return View();
        }

        //Adding Products through Model from Home Page Products
        public ActionResult Productspost(ProductTable proadd)
        {
            db.ProductTables.Add(proadd);
            db.SaveChanges();
            return RedirectToAction("Products", "Home");
        }

        //Home Page Products Table
        public PartialViewResult ProResult()
        {
            return PartialView(db.ProductTables.ToList());
        }
        //Main Page Products Add Model
        public PartialViewResult ProModelDataFetch()
        {
            return PartialView();
        }
        //Table View in Products Page 
        public PartialViewResult ProTable()
        {
            return PartialView(db.ProductTables.ToList());
        }

        //Editing A Product
        [HttpGet]
        public ActionResult EditProduct(int id = 0)
        {
            var checkp = db.ProductTables.Where(x => x.productId == id).FirstOrDefault();
            return View(checkp);
        }

        [HttpPost]
        public ActionResult EditProduct(ProductTable checkp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Products");
            }
            return View(checkp);
        }
        //Deleting A Product
        public ActionResult DeleteProduct(int id = 0)
        {
            var checkp = db.ProductTables.Where(x => x.productId == id).FirstOrDefault();
            db.ProductTables.Remove(checkp);
            db.SaveChanges();
            return RedirectToAction("Products");
        }
        
        //Contact Page
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Feed(Feedback addq)
        {
            if (addq.email != null && addq.subject != null && addq.message != null)
            {
                db.Feedbacks.Add(addq);
                db.SaveChanges();
                return RedirectToAction("Contact", "Home");
            }
            else if (addq.email == null && addq.subject == null && addq.message == null)
            {
                addq.ErrorMessage = "Empty Input Values";
                return RedirectToAction("Contact", "Home");

            }

            return View(addq);
               
        }

        //About Page
        public ActionResult About()
        {
            return View();
        }
        
    }
}