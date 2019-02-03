using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RestServices.Models.DTO
{
    [DataContract]
    public class TagResultDTO
    {
        [DataMember]
        public List<Item> Items { get; set; }
    }
}
