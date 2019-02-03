using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediporta_Services.Models.DTO;
using RestSharp;

namespace Mediporta.Controllers.Service
{
    public static class GetDataFromTagService
    {
        public static TagResultDTO GetTags(int pageNumber, int pageSize, string order = "desc")
        {
            var client = new RestClient("http://localhost/Mediporta_Services");
            var request = new RestRequest("api/PopularTag/Get", Method.GET);

            request.AddParameter("pageNumber", pageNumber);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("order", order);

            var tags = client.Execute<TagResultDTO>(request).Data;
           
            return tags;
        }
    }
}
