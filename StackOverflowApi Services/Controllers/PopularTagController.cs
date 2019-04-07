using System.Web.Http;
using System.Web.Mvc;
using RestServices.Models.Interfaces;

namespace RestServices.Controllers
{

    public class PopularTagController : ApiController
    {
        private ITagReaderService _tagReaderService;

        public PopularTagController(ITagReaderService tagReaderService)
        {
            _tagReaderService = tagReaderService;
        }

        public JsonResult GetTags(int pageNumber, int pageSize)
        {
            var getTagData = _tagReaderService.GetTag(pageNumber, pageSize);

            return new JsonResult()
            {
                Data = getTagData.Items,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

    }
}
