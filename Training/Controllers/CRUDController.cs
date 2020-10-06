using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.CRUDOperations;
using DataLayer.Context;
using Training.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Training.Controllers
{
  
    public class CRUDController : ControllerBase
    {

        private IRepositoryModel<Employee> _irepositoryModel;
        public CRUDController()
        {
            _irepositoryModel = new Repositorymodel<Employee>();
        }
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _irepositoryModel.getModel();
        }

      
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _irepositoryModel.getModelById(id);
        }

       
        [HttpPost]
        public void Post([FromBody] Employee value)
        {
            _irepositoryModel.insertModel(value);
            _irepositoryModel.Save();
        }

       
        [HttpPut("{id}")]
        public void Put( [FromBody] Employee value)
        {

            _irepositoryModel.updateModel(value);
            _irepositoryModel.Save();
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _irepositoryModel.deleteModel(id);
            _irepositoryModel.Save();
            
        }
    }
}
