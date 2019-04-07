using System;
using System.Configuration;
using RestServices.Models.DTO;
using RestSharp;

namespace Mediporta.Controllers.Service
{
    public static class GetDataFromTagService
    {
        public static TagResultDTO GetTags(int pageNumber, int pageSize)
        {
            if (ConfigurationManager.AppSettings["RestServicesUrl"].Length == 0)
            {
                throw new NotImplementedException("Add key RestServicesUrl to config");
            }

            var restServicesUrl = ConfigurationManager.AppSettings["RestServicesUrl"];
            var client = new RestClient(restServicesUrl);
            var request = new RestRequest("api/PopularTag/GetTags", Method.GET);

            request.AddParameter("pageNumber", pageNumber);
            request.AddParameter("pageSize", pageSize);

            var tags = client.Execute<TagResultDTO>(request).Data;
           
            return tags;
        }
    }
}
