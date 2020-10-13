using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DbModels
{
   public class ProCat
    {
        public string ProductCatName { get; set; }
        public List<Product> ProductList { get; set; }
        public int count { get; set; }
    }
}
