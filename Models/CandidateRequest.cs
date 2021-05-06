using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StoreCandidates.Model
{
    public class CandidateRequest
    {
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <example>Pablo</example>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <example>pablo@gmail.com.br</example>
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DateBirth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <example>1000</example>
        [Required]
        public float DisiredRemunaration { get; set; }

    }
}
