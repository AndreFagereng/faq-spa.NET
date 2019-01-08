using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAQOblig.Models
{
    /// <summary>
    /// CustomerQuestion model for database.
    /// The variables that needs to be validates and is used in
    /// POST requests is validated
    /// Email and Answer is NOT validated because email is optional
    /// and answer is not coming as POST request from the user.
    /// </summary>
    public class CustomerQuestion
    {
        [Key]
        public int CQID { get; set; }
        [Required]
        public string Question { get; set; }
        public string Email { get; set; }
        public Answer Answer { get; set; }
        [Required]
        public int Upvotes { get; set; }
        [Required]
        public int Downvotes { get; set; }
    }
}
