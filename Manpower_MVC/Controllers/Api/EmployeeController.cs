using DataTables;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using Manpower_MVC.Models;

namespace Manpower_MVC.Controllers.Api
{
    public class EmployeeController : BaseApiController
    {
        private ManpowerDBEntities db = new ManpowerDBEntities();

        public IHttpActionResult Rest(HttpRequest request)
        {
            //var settings = Properties.Settings.Default;

            using (var db = new Database("sqlserver", System.Configuration.ConfigurationManager.ConnectionStrings["ManpowerDBEntities"].ConnectionString))
            {
                var response = new Editor(db, "Employee", "Id")
                    .Model<Employee>()
                    .Field(new Field("EmpID").Validator(Validation.NotEmpty()))
                    .Field(new Field("EmpName").Validator(Validation.NotEmpty()).Xss(false))
                    .Field(new Field("Tel").Validator(Validation.Basic()))
                    .Field(new Field("Phone").Validator(Validation.Basic()))
                    .Field(new Field("ConPerson").Validator(Validation.Basic()).Xss(false))
                    .Field(new Field("ConPersonTel").Validator(Validation.Basic()).Xss(false))
                    .Field(new Field("CreateDate").Validator(Validation.Basic()).Xss(false))
                    .Process(request)
                    .Data();

                return Json(response);
            }
        }

        [Route("api/employee/get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }
        [Route("api/employee/create")]
        [HttpPost]
        public IHttpActionResult Create()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("api/employee/edit")]
        [HttpPut]
        public IHttpActionResult Edit()
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }

        [Route("api/employee/remove")]
        [HttpPost]
        public IHttpActionResult Remove([FromBody] FormDataCollection formData)
        {
            var request = HttpContext.Current.Request;
            return Rest(request);
        }
    }
}