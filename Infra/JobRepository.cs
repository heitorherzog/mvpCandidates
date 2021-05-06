using Microsoft.EntityFrameworkCore;
using StoreCandidates.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreCandidates.Infra
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(StoreCandidatesContext context) : base(context) { }

    }
}
