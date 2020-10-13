using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.CRUDOperations;
using DataAccessLayer.Context;
using Training.Models;
using DataAccessLayer.Context;
using BusinessLogicLayer.CRUDOperations;
using DataAccessLayer.DbModels;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Training.Controllers
{
   

    public class CRUDController : ControllerBase
    {

        private IRepositoryModel _irepositoryModel;
        public CRUDController( IRepositoryModel irm)
        {
            _irepositoryModel = irm;
        }
        [HttpGet]
        public IEnumerable<ProCat> Get()
        {
         
            var list = from listOfemployees in _irepositoryModel.getModel<Employee>()
                       select listOfemployees;
            var grp_list_of_products = _irepositoryModel.getModel<Product>()
             .GroupBy(x => x.productCategoryName).ToDictionary(g => g.Key+"  Count:" +g.Count().ToString(), g => g.ToList());

            var grp_list_of_products1 = _irepositoryModel.getModel<Product>()
            .GroupBy(x => x.productCategoryName).
            Select(group =>
                        new ProCat
                        {
                            ProductCatName = group.Key,
                            count = group.Count(),
                            ProductList = group.ToList()
                           
                        });
            return grp_list_of_products1;
                //(/*from m in _irepositoryModel.getModel() select m);*/
        }

      
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _irepositoryModel.getModelById<Employee>(id);
        }

       
        [HttpPost]
        public void Post([FromBody] Employee value)
        {
            _irepositoryModel.insertModel<Employee>(value);
            _irepositoryModel.Save();
        }

       
        [HttpPut("{id}")]
        public void Put( [FromBody] Employee value)
        {

            _irepositoryModel.updateModel<Employee>(value);
            _irepositoryModel.Save();
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _irepositoryModel.deleteModel<Employee>(id);
            _irepositoryModel.Save();
            
        }
    }
}
