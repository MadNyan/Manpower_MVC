using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using DataTables;
using Manpower_MVC.REST.Models;

namespace Manpower_MVC.REST.Controllers
{
    public class InsCateController : ApiController
    {
        // GET: Emp
        public IHttpActionResult Rest(HttpRequest request)
        {

            using (var db = new Database("sqlserver", System.Configuration.ConfigurationManager.ConnectionStrings["ManpowerDBEntitiesEditor"].ConnectionString))
            {
                var response = new Editor(db, "InsCate", "ID")
                    .Model<InsCate>()
                    .Field(new Field("InsID").Validator(Validation.NotEmpty()))
                    .Field(new Field("InsName").Validator(Validation.Basic()))
                    .Field(new Field("PosOrNeg").Validator(Validation.Basic()))
                    .Process(request)
                    .Data();

                return Json(response);
            }
        }

        [Route("insCate/get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("insCate/create")]
        [HttpPost]
        public IHttpActionResult Create()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("insCate/edit")]
        [HttpPut]
        public IHttpActionResult Edit()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("insCate/remove")]
        [HttpPost]
        public IHttpActionResult Remove([FromBody] FormDataCollection formData)
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }
    }
}