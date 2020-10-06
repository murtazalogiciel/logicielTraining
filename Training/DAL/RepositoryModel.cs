using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Context;


namespace Training.DAL
{
    public class Repositorymodel<T> : IRepositoryModel<T> where T : class
    {

        private EmployeeDbContext _dbContext;
        private DbSet<T> _dbentity;
       public Repositorymodel()
        {
            _dbContext = new EmployeeDbContext();
            _dbentity = _dbContext.Set<T>();

        }
        public void deleteModel(int modelId)
        {
            T model = _dbentity.Find(modelId);
            _dbentity.Remove(model);
            
        }

        public IEnumerable<T> getModel()
        {
            return _dbentity.ToList();
        }

        public T getModelById(int modelId)
        {
            return _dbentity.Find(modelId);
        }

        public void insertModel(T model)
        {
            _dbentity.Add(model);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void updateModel(T model)
        {
       
        }
    }
}