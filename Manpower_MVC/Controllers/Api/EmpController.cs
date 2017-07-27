using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using DataTables;
using Manpower_MVC.Models;

namespace Manpower_MVC.Controllers.Api
{
    public class EmpController : System.Web.Http.ApiController
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
                            Format.DATE_ISO_8601,
                            new ValidationOpts { Message = "Please enter a date in the format yyyy-mm-dd" }
                            ))
                        .GetFormatter(Format.DateSqlToFormat(Format.DATE_ISO_8601))
                        .SetFormatter(Format.DateFormatToSql(Format.DATE_ISO_8601))
                    )
                    .Process(request)
                    .Data();

                return Json(response);
            }
        }

        [Route("api/rest/get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("api/rest/create")]
        [HttpPost]
        public IHttpActionResult Create()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("api/rest/edit")]
        [HttpPut]
        public IHttpActionResult Edit()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("api/rest/remove")]
        [HttpDelete]
        public IHttpActionResult Remove([FromBody] FormDataCollection formData)
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }
    }
}