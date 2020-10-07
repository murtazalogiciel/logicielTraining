using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.CRUDOperations
{
    public class RepositoryModelReadOnly
    {
        protected readonly EmployeeDbContext _contextReadOnly;
        public RepositoryModelReadOnly(EmployeeDbContext context)
        {
            _contextReadOnly = context;
        }
       
    }
}
