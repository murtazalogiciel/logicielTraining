using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Training.DAL;
using Training.Models;
using Training.Context;
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
        public string Get(int id)
        {
            return Trader.categories[id];
        }

       
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Trader.categories.Add(value);
        }

       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Trader.categories.Insert(id, value);
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Trader.categories.RemoveAt(id);
        }
    }
}
