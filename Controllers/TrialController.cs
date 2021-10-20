using College_Management_System.DBContext;
using College_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace College_Management_System.Controllers
{
    [Route("api/[controller]")]
    public class TrialController : ApiController
    {
        public IHttpActionResult Index()
        {
            return Ok();
        }
    }
}
