using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndycabarApi.Controllers
{
    public class getVerificationCodeController : ApiController
    {
        /// <summary>
        /// api/getVerificationCode
        /// تایید کد ارسال شده
        /// </summary>
        /// <param name="checkPhone">شماره تلفن
        /// کد احراز</param>
        /// <returns>
        /// true
        /// false
        /// </returns>
        public string Post([FromBody]AllClass.CheckPhone checkPhone)
        {
            Models.AndycabarDB db = new Models.AndycabarDB();
            int code = int.Parse(checkPhone.VerificationCode);
            var data = db.Users
                .Where(x => x.Mobile == checkPhone.phone && 
                            x.VerificationCode == code).ToList();
            if (data.Count>0)
            {
                return data[0].Type;
            }
            else
            {
                return null;
            }
        }
    }
}
