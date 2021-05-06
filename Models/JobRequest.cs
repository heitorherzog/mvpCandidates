using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreCandidates.Models
{
    public class JobRequest
    {
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <example>Developer</example>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <example>work doing magic</example>
        [Required]
        public string Description { get; set; }
    }
}
