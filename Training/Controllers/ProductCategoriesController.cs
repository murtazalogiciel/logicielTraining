using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Context;
using DataAccessLayer.DbModels;
using BusinessLogicLayer.CRUDOperations;

namespace Training.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private IRepositoryModel _irepositoryModel;
        public ProductCategoriesController(IRepositoryModel irm)
        {
            _irepositoryModel = irm;
        }

        // GET: ProductCategorys
        public IActionResult Index()
        {
            return View(_irepositoryModel.getModel<ProductCategory>().ToList());
        }

        // GET: ProductCategorys/Details/5
        public async Task<IActionResult> Details(int id)
        {
           

            var ProductCategory = _irepositoryModel.getModelById<ProductCategory>(id);
            if (ProductCategory == null)
            {
                return NotFound();
            }

            return View(ProductCategory);
        }

        // GET: ProductCategorys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductCategorys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("productCategoryId,productCategoryName,productCategoryContact")] ProductCategory ProductCategory)
        {
            if (ModelState.IsValid)
            {
                _irepositoryModel.insertModel<ProductCategory>(ProductCategory);
                _irepositoryModel.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(ProductCategory);
        }

        // GET: ProductCategorys/Edit/5
        public async Task<IActionResult> Edit(int id)
        {


            var ProductCategory = _irepositoryModel.getModelById<ProductCategory>(id);
            if (ProductCategory == null)
            {
                return NotFound();
            }
            return View(ProductCategory);
        }

        // POST: ProductCategorys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("productCategoryId,productCategoryName,productCategoryContact")] ProductCategory ProductCategory)
        {
            if (id != ProductCategory.productCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _irepositoryModel.updateModel<ProductCategory>(ProductCategory);
                    _irepositoryModel.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCategoryExists(ProductCategory.productCategoryId))
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
            return View(ProductCategory);
        }

        // GET: ProductCategorys/Delete/5
        public IActionResult Delete(int id)
        {


            var ProductCategory = _irepositoryModel.getModelById<ProductCategory>(id);
            if (ProductCategory == null)
            {
                return NotFound();
            }

            return View(ProductCategory);
        }

        // POST: ProductCategorys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _irepositoryModel.deleteModel<ProductCategory>(id);
            _irepositoryModel.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCategoryExists(int id)
        {
            return true;
        }
    }
}
