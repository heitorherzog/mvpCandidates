using Microsoft.EntityFrameworkCore;
using StoreCandidates.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreCandidates.Infra
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        public JobRepository(StoreCandidatesContext context) : base(context) { }

    }
}
