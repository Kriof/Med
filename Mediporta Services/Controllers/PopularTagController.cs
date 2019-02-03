using System.Runtime.Serialization;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Mediporta_Services.Models.DTO;
using Mediporta_Services.Models.Interfaces;
using Mediporta_Services.Services;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Newtonsoft.Json;

namespace Mediporta_Services.Controllers
{

    public class PopularTagController : ApiController
    {
        private ITagReaderService _tagReaderService;

        public PopularTagController(ITagReaderService tagReaderService)
        {
            _tagReaderService = tagReaderService;
        }
        //[System.Web.Http.HttpGet]
        //public TagResultDTO Get()
        //{
        //    var getTagData = _tagReaderService.GetTag();

        //    return getTagData;
        //}

        //public JsonResult GetJSon()
        //{
        //    var getTagData = _tagReaderService.GetTag();
        //    return new JsonResult()
        //    {
        //        Data = getTagData.Items,
        //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //    };
        //}

        public JsonResult GetTags(int pageNumber, int pageSize, string order)
        {
            var getTagData = _tagReaderService.GetTag(pageNumber, pageSize, order);

            return new JsonResult()
            {
                Data = getTagData.Items,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

    }
}
