using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.CRUDOperations
{
   public class RepositoryModelReadOnly : IRepositoryModel
    {
        protected readonly EmployeeDbContext _contextReadOnly;
        public RepositoryModelReadOnly(EmployeeDbContext context)
        {
            _contextReadOnly = context;
        }
        public void deleteModel<T>(int modelId) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> getModel<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public T getModelById<T>(int modelId) where T : class
        {
            throw new NotImplementedException();
        }

        public void insertModel<T>(T model) where T : class
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void updateModel<T>(T model) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
