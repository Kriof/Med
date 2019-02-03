using System.IO;
using System.Net;
using System.Text;
using AutoMapper;
using Newtonsoft.Json;
using RestServices.Models;
using RestServices.Models.DTO;
using RestServices.Models.Interfaces;
using RestSharp;
namespace RestServices.Services
{
    public class TagReaderService : ITagReaderService
    {
        public TagResultDTO GetTag()
        {
            string stackOverFlowTagUrl = "https://api.stackexchange.com/2.2/tags?order=desc&sort=popular&site=stackoverflow";
            string jsonData = string.Empty;

            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(stackOverFlowTagUrl);
            hwr.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            hwr.ContentType = "application/json; charset=utf-8";
            HttpWebResponse response = hwr.GetResponse() as HttpWebResponse;

            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                jsonData = reader.ReadToEnd();
            }

            var popularTag = JsonConvert.DeserializeObject<TagResult>(jsonData);
            var popularTagDTO = Mapper.Map<TagResult, TagResultDTO>(popularTag);
            return popularTagDTO;
        }

        public TagResultDTO GetTag(int pageNumber, int pageSize, string order = "desc")
        {
            var stackOverflowDomainUrl = "https://api.stackexchange.com";

            var client = new RestClient(stackOverflowDomainUrl);
            
            var request = new RestRequest("2.2/tags?", Method.GET);
            request.AddParameter("page", pageNumber); // adds to POST or URL querystring based on Method
            request.AddParameter("pageSize", pageSize); // adds to POST or URL querystring based on Method
            request.AddParameter("order", order); // adds to POST or URL querystring based on Method
            request.AddParameter("sort", "popular"); // adds to POST or URL querystring based on Method
            request.AddParameter("site", "stackoverflow"); // adds to POST or URL querystring based on Method

            var tags = client.Execute<TagResultDTO>(request).Data;
            return tags;
        }
    }
}
