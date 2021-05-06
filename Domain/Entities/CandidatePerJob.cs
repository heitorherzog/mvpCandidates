
namespace StoreCandidates.Domain.Entities
{
    public class CandidatePerJob
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
