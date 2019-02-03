using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediporta_Services.Models
{
    public class Item
    {
        public bool Has_synonyms { get; set; }

        public bool Is_moderator_only { get; set; }
        public bool Is_required { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
    }
}
