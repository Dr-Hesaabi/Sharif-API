using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndycabarApi.AllClass
{
    public class Product
    {
        public string barcode { get; set; }
        public string description { get; set; }
        public string salePrice { get; set; }
        public string detailedName { get; set; }
        public string companyCost { get; set; }
        public string groupId { get; set; }
        public string pic { get; set; }
    }
}