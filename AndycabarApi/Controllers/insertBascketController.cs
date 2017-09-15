using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndycabarApi.Controllers
{
    public class insertBascketController : ApiController
    {
        public string Post([FromBody] AllClass.Barcode barcode)
        {
            string[] data = barcode.barcode.Split(',');
            Models.AndycabarDB db = new Models.AndycabarDB();
            foreach (var item in data)
            {
               // var product =db.
            }
            return null;
        }
    }
}
