using System;
using System.Collections.Generic;
using RestServices.Models;

namespace Mediporta_Services.Models
{
    public class TagResult
    {
        public List<Item> Items { get; set; }
        public Boolean Has_More { get; set; }
        public int Quota_Max { get; set; }
        public int Quota_Remaining { get; set; }
    }
}
