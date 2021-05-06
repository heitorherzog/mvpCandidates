using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreCandidates.Domain.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DateInclusion { get; set; }

        public Job()
        {
            DateInclusion = DateTime.UtcNow;
            Status = "OPEN";
        }
    }
}
