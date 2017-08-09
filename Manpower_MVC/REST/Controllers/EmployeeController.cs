using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using DataTables;
using Manpower_MVC.Models;

namespace Manpower_MVC.REST.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: Emp
        public IHttpActionResult Rest(HttpRequest request)
        {

            using (var db = new Database("sqlserver", System.Configuration.ConfigurationManager.ConnectionStrings["ManpowerDBEntitiesEditor"].ConnectionString))
            {
                var response = new Editor(db, "Employee", "ID")
                    .Model<Employee>()
                    .Field(new Field("EmpID").Validator(Validation.NotEmpty()))
                    .Field(new Field("EmpName").Validator(Validation.NotEmpty()))
                    .Field(new Field("Tel").Validator(Validation.Basic()))
                    .Field(new Field("Phone").Validator(Validation.Basic()))
                    .Field(new Field("ConPerson").Validator(Validation.Basic()))
                    .Field(new Field("ConPersonTel").Validator(Validation.Basic()))
                    .Field(new Field("CreateDate")
                        .Validator(Validation.DateFormat(
                            "yyyy-MM-dd",
                            new ValidationOpts { Message = "Please enter a date in the format yyyy-mm-dd" }
                            ))
                        .GetFormatter(Format.DateTime("yyyy-MM-dd"))
                        .SetFormatter(Format.DateTime("yyyy-MM-dd"))
                    )
                    .Process(request)
                    .Data();

                return Json(response);
            }
        }

        [Route("emp/get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("emp/create")]
        [HttpPost]
        public IHttpActionResult Create()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("emp/edit")]
        [HttpPut]
        public IHttpActionResult Edit()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("emp/remove")]
        [HttpPost]
        public IHttpActionResult Remove([FromBody] FormDataCollection formData)
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }
    }
}