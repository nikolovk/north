using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities.Models;
using Services.Products;
using Services.Suppliers;
using Services.Categories;

namespace MVC.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private IProductsService productsService;
        private ICategoriesService categoriesService;
        private ISuppliersService suppliersService;

        public ProductsController(IProductsService productsService, ICategoriesService categoriesService,
            ISuppliersService suppliersService)
        {
            this.productsService = productsService;
            this.suppliersService = suppliersService;
            this.categoriesService = categoriesService;
        }

        private NorthContext db = new NorthContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = this.productsService.GetProducts();
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = this.productsService.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(this.categoriesService.GetCategories(), "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(this.suppliersService.GetSuppliers(), "SupplierID", "CompanyName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                this.productsService.AddProduct(product);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(this.categoriesService.GetCategories(), "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(this.suppliersService.GetSuppliers(), "SupplierID", "CompanyName", product.SupplierID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = this.productsService.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(this.categoriesService.GetCategories(), "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(this.suppliersService.GetSuppliers(), "SupplierID", "CompanyName", product.SupplierID);

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                this.productsService.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(this.categoriesService.GetCategories(), "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(this.suppliersService.GetSuppliers(), "SupplierID", "CompanyName", product.SupplierID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = this.productsService.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = this.productsService.GetById(id);
            this.productsService.DeleteProduct(product.ProductID);

            return RedirectToAction("Index");
        }
    }
}
