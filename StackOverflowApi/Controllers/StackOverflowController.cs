using System.Web.Mvc;
using Mediporta.Controllers.Service;

namespace Mediporta.Controllers
{
    public class StackOverflowController : Controller
    {
        public ActionResult Index()
        {
            var popular = GetDataFromTagService.GetTags(1, 25); 

            return View(popular);
        }
    }
}
