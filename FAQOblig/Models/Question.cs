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
    /// The Questions class is used for the FAQ on the frontend.
    /// This doesnt need to be validated, but Its not possible to
    /// send a POST request with these fields.
    /// Only CustomerQuestions are allowed to be sent.
    /// JsonConverter is used to convert enum to string.
    /// If JsonConverter is not there, it will send the Enum as 
    /// integers, which is not optimal.
    /// </summary>
    public class Questions
    {
        [Key]
        public int QID { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public QEnumType Qtype { get; set; }
        [Required]
        public Answer Answer { get; set; }
        [Required]
        public int Upvotes { get; set; }
        [Required]
        public int Downvotes { get; set; }
    }
}
