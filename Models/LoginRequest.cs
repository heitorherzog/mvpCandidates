using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StoreCandidates.Model
{

    public class LoginRequest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <example>admin</example>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>securePassword</example>
        [Required]
        public string Password { get; set; }
    }

}
