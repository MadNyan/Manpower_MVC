using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using DataTables;
using Manpower_MVC.Models;

namespace Manpower_MVC.REST.Controllers
{
    public class InsController : ApiController
    {
        // GET: Emp
        public IHttpActionResult Rest(HttpRequest request)
        {

            using (var db = new Database("sqlserver", System.Configuration.ConfigurationManager.ConnectionStrings["ManpowerDBEntitiesEditor"].ConnectionString))
            {
                var response = new Editor(db, "EmpInsurance", "ID")
                    .Model<EmpInsurance>()
                    .Field(new Field("Price").Validator(Validation.NotEmpty()))
                    .Field(new Field("InsID").Validator(Validation.NotEmpty()))
                    .Field(new Field("EmpID").Validator(Validation.NotEmpty()))
                    .Field(new Field("Remark").Validator(Validation.Basic()))
                    .Process(request)
                    .Data();

                return Json(response);
            }
        }

        [Route("ins/get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("ins/create")]
        [HttpPost]
        public IHttpActionResult Create()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("ins/edit")]
        [HttpPut]
        public IHttpActionResult Edit()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("ins/remove")]
        [HttpPost]
        public IHttpActionResult Remove([FromBody] FormDataCollection formData)
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }
    }
}