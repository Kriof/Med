using System;
using System.Configuration;
using System.Linq;
using Mediporta_Services.Models;
using RestServices.Models.DTO;
using RestServices.Models.Interfaces;
using RestSharp;
namespace RestServices.Services
{
    public class TagReaderService : ITagReaderService
    {
        public TagResultDTO GetTag(int pageNumber, int pageSize)
        {
            if (ConfigurationManager.AppSettings["StackOverflowUrl"].Length == 0)
            {
                throw new NotImplementedException("Add key StackOverflowUrl to config");
            }
            
            var stackOverflowDomainUrl = ConfigurationManager.AppSettings["StackOverflowUrl"];

            var client = new RestClient(stackOverflowDomainUrl);
            
            var request = new RestRequest("2.2/tags?", Method.GET);
            request.AddParameter("page", pageNumber); 
            request.AddParameter("pageSize", pageSize); 
            request.AddParameter("order", "desc"); 
            request.AddParameter("sort", "popular"); 
            request.AddParameter("site", "stackoverflow"); 

            var tags = client.Execute<TagResult>(request).Data;
            var total = tags.Items.Sum(x => x.Count);
            foreach (var item in tags.Items)
            {
                item.Percentage = ((double)item.Count / total).ToString("0.00%");
            }

            var tagDTO = AutoMapper.Mapper.Map<TagResult, TagResultDTO>(tags);
            
            return tagDTO;
        }
    }
}
