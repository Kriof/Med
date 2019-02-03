using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using RestServices.Models.DTO;

namespace RestServices.Models.Interfaces
{

    [ServiceContract]
    public interface ITagReaderService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",ResponseFormat = WebMessageFormat.Json)]
        TagResultDTO GetTag(int pageNumber, int pageSize, string order);
    }

}
