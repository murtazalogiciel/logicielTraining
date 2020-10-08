
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;



namespace BusinessLogicLayer.CRUDOperations
{
    public class RepositoryModel: IRepositoryModel
    { 
       
        private EmployeeDbContext _dbContext;
      


        public RepositoryModel(EmployeeDbContext context)
        {
            _dbContext = context;
            //_dbentity = _dbContext.Set<T>();

        }
       

        public void deleteModel<T>(int modelId) where T : class
        {
            T model = _dbContext.Set<T>().Find(modelId);
            _dbContext.Set<T>().Remove(model);
        }

        

        public IEnumerable<T> getModel<T>() where T : class
        {
            return _dbContext.Set<T>().ToList();
        }

       

        public T getModelById<T>(int modelId) where T : class
        {
            return _dbContext.Set<T>().Find(modelId);
        }

      

        public void insertModel<T>(T model) where T : class
        {
           _dbContext.Set<T>().Add(model);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }


        public void updateModel<T>(T model) where T : class
        {
            _dbContext.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }
    }
}