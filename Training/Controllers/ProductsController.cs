using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Context;
using BusinessLogicLayer.CRUDOperations;

namespace Training.Controllers
{
    public class ProductsController : Controller
    {
        private IRepositoryModel _irepositoryModel;
        public ProductsController(IRepositoryModel irm)
        {
            _irepositoryModel = irm;
        }

        // GET: Products
        public IActionResult Index()
        {
           
            var sql_grp_list_of_products = from product in _irepositoryModel.getModel<Product>()

                                           group product by product.productCategoryName;

          
            return View(_irepositoryModel.getModel<Product>().ToList());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = _irepositoryModel.getModelById<Product>(id);
            if (Product == null)
            {
                return NotFound();
            }

            return View(Product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("productId,productName,productCategoryName,productContact")] Product Product)
        {
            if (ModelState.IsValid)
            {
                _irepositoryModel.insertModel<Product>(Product);
                _irepositoryModel.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(Product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int id)
        {


            var Product = _irepositoryModel.getModelById<Product>(id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("productId,productName,productCategoryName,productContact")] Product Product)
        {
            if (id != Product.productId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _irepositoryModel.updateModel<Product>(Product);
                    _irepositoryModel.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(Product.productId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int id)
        {


            var Product = _irepositoryModel.getModelById<Product>(id);
            if (Product == null)
            {
                return NotFound();
            }

            return View(Product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _irepositoryModel.deleteModel<Product>(id);
            _irepositoryModel.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return true;
        }
    }
}
