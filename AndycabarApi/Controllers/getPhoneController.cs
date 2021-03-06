﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndycabarApi.Controllers
{
    public class getPhoneController : ApiController
    {
        /// <summary>
        /// api/getPhone
        /// دریافت sms
        /// </summary>
        /// <param name="phone">شماره تماس</param>
        /// <returns>کد احراز هویت</returns>
        public string Post([FromBody] AllClass.Phone phone)
        {
            Models.AndycabarDB db = new Models.AndycabarDB();
            Models.User tb = new Models.User();
            tb.Mobile = phone.phone;
            tb.Type = "Customer";
            tb.Name = "";
            tb.VerificationCode = new Random().Next(1000, 9999);
            
            var data = db.Users.Where(x => x.Mobile == phone.phone).ToList();
            if (data.Count()>0)
            {
                var user = db.Users.Where(x => x.Mobile == phone.phone).FirstOrDefault();
                user.VerificationCode = tb.VerificationCode;
                db.SaveChanges();
                tb.Type = user.Type;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(" http://api.smsapp.ir/v2/sms/send/simple");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("apikey", "HHweSCQ4jCniM2KYKNSTOgmTepEkjXiJOQP4uIcLNi4");

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"receptor\":\"" + phone.phone + "\"," +
                                  "\"message\":\"" + "اندیکابار \n کد تایید شماره شما : \n" + tb.VerificationCode + "\"," +
                                 "\"sender\":\"30006703451451\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                return tb.VerificationCode.ToString();

            }
            else
            {
                db.Users.Add(tb);
                db.SaveChanges();
                var userId = db.Users.Where(x => x.Mobile == phone.phone).FirstOrDefault();
                int userid = userId.Id;
                Models.Customer tb1 = new Models.Customer();
                tb1.UserId = userid;
                tb1.Email = "";
                db.Customers.Add(tb1);
                db.SaveChanges();
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(" http://api.smsapp.ir/v2/sms/send/simple");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("apikey", "HHweSCQ4jCniM2KYKNSTOgmTepEkjXiJOQP4uIcLNi4");

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"receptor\":\"" + phone.phone + "\"," +
                                  "\"message\":\"" + "اندیکابار \n کد تایید شماره شما : \n" + tb.VerificationCode + "\"," +
                                 "\"sender\":\"30006703451451\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                return tb.VerificationCode.ToString();
            }
            
            
            

        }

    }
}
