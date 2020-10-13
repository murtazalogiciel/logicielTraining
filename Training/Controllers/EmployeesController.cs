using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Context;
using BusinessLogicLayer.CRUDOperations;
using Microsoft.Extensions.Logging;

namespace Training.Controllers
{
    public class EmployeesController : Controller
    {
        private IRepositoryModel _irepositoryModel;
        private ILogger<EmployeesController> _Logging;
        public EmployeesController(IRepositoryModel irm, ILogger<EmployeesController> il)
        {
            _irepositoryModel = irm;
            _Logging = il;
        }

        // GET: Employees
        public IActionResult Index()
        {
            return View(_irepositoryModel.getModel<Employee>().ToList());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {

                throw new Exception("DETAILS NOT FOUND");
                if (id == null)
                {
                    return NotFound();
                }

                var employee = _irepositoryModel.getModelById<Employee>(id);
                if (employee == null)
                {
                    return NotFound();
                }

                return View(employee);
                    }
            catch(Exception ex)
            {
                _Logging.LogError($"There was a error related to {ex.Message}");
                ViewBag.Title = ex.Message;
                return View("Error");
            }
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("employeeId,employeeName,employeeContact")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _irepositoryModel.insertModel<Employee>(employee);
                _irepositoryModel.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           

            var employee = _irepositoryModel.getModelById<Employee>(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("employeeId,employeeName,employeeContact")] Employee employee)
        {
            if (id != employee.employeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _irepositoryModel.updateModel<Employee>(employee);
                    _irepositoryModel.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.employeeId))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int id)
        {
            

            var employee =  _irepositoryModel.getModelById<Employee>(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _irepositoryModel.deleteModel<Employee>(id);
            _irepositoryModel.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return true;
        }
    }
}
