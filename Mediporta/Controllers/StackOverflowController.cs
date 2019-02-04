using System.Web.Mvc;
using Mediporta.Controllers.Service;

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
