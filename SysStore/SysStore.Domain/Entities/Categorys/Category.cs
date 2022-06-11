using System;
using System.Collections.Generic;
using SysStore.Domain.Base;
namespace SysStore.Domain.Entities.Categorys
{
    public class Category: BaseEntity
    {        
        public int Categoryid { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
                
    }

    

    


}
