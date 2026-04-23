using System;
using System.Collections.Generic;
using System.Text;

namespace ManGnurt.DataAccessNetcore.DataObject
{
    public class ProductDTO
    {

        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        //public string   ProductPrice{get;set;}
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
    }
}
