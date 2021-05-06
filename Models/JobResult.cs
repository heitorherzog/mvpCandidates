using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreCandidates.Models
{
    public class JobResult
    {
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <example>Developer</example>

        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <example>work doing magic</example>

        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <example>OPEN</example>
        public string Status { get; set; }
        public DateTime DateInclusion { get; set; }
    }
}
