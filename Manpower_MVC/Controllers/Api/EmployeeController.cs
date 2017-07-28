using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using DataTables;
using Manpower_MVC.Models;

namespace Manpower_MVC.Controllers.Api
{
    public class EmployeeController : System.Web.Http.ApiController
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
                        .GetFormatter(Format.DateSqlToFormat("yyyy-MM-dd"))
                        .SetFormatter(Format.DateFormatToSql("yyyy-MM-dd"))
                    )
                    .Process(request)
                    .Data();

                return Json(response);
            }
        }

        [Route("api/emp/get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("api/emp/create")]
        [HttpPost]
        public IHttpActionResult Create()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("api/emp/edit")]
        [HttpPut]
        public IHttpActionResult Edit()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("api/emp/remove")]
        [HttpPost]
        public IHttpActionResult Remove([FromBody] FormDataCollection formData)
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }
    }
}