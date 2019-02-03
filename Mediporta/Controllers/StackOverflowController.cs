using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Mediporta.Controllers.Service;
using RestServices.Controllers;

namespace Mediporta.Controllers
{
    public class StackOverflowController : Controller
    {
        public ActionResult Index()
        {
            var _popular = GetDataFromTagService.GetTags(1, 25); 

            return View(_popular);
        }
    }
}
