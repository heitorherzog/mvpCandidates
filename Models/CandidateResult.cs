using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StoreCandidates.Model
{
    public class CandidateResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <example>Pablo</example>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <example>pablo@gmail.com.br</example>
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime DateInclusion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <example>1000</example>
        public float DisiredRemunaration { get; set; }
    }
}
