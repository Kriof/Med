using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestServices.Models
{
    public class TagResult
    {
        public List<Item> Items { get; set; }
        public Boolean Has_More { get; set; }
        public int Quota_Max { get; set; }
        public int Quota_Remaining { get; set; }
    }
}
