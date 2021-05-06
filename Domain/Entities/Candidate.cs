using StoreCandidates.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreCandidates.Domain.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime DateInclusion { get; set; }
        public float DisiredRemunaration { get; set; }
        public ICollection<CandidatePerJob> CandidatePerJobs { get; set; }

        public Candidate()
        {
            DateInclusion = DateTime.UtcNow;
        }
    }
}
