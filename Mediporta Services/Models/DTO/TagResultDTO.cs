using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RestServices.Models.DTO
{
    [DataContract]
    public class TagResultDTO
    {
        [DataMember]
        public List<Item> Items { get; set; }
    }
}
