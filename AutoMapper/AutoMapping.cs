using AutoMapper;
using StoreCandidates.Domain.Entities;
using StoreCandidates.Model;
using StoreCandidates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreCandidates.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CandidateRequest, Candidate>();
            CreateMap<Candidate, CandidateResult>();

            CreateMap<JobRequest, Job>();
            CreateMap<Job, JobRequest>();
        }

    }
}
