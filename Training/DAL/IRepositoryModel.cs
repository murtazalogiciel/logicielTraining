using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.DAL
{
    interface IRepositoryModel<T> where T : class
    {
        IEnumerable<T> getModel();
        T getModelById(int modelId);
        void insertModel(T model);
        void deleteModel(int modelId);
        void updateModel(T model);
        void Save();
    }
}
