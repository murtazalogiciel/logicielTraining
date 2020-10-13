using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer.CRUDOperations
{
     public interface IRepositoryModel
    {
        IEnumerable<T> getModel<T>() where T : class;
        T getModelById<T>(int modelId) where T : class;
        void insertModel<T>(T model) where T : class;
        Task deleteModel<T>(int modelId) where T : class;
        void updateModel<T>(T model) where T : class;
        void Save();
    }
}
