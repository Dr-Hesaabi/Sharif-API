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
        public string Post(AllClass.CheckPhone checkPhone)
        {
            Models.AndycabarDB db = new Models.AndycabarDB();
            var data = db.Users.Where(x => x.Mobile == checkPhone.phone && x.VerificationCode == int.Parse(checkPhone.VerificationCode)).ToList();
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
