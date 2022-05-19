using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class Status : CategoryStatuses
    {
        public int StatusId { get; set; }
        public string Description { get; set; }
        public string IdCategory { get; set; }
    }
}
