using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAQOblig.Models
{
    /// <summary>
    /// Each Answer-object represent an answer to a specific Question.
    /// Each Answer-object is linked to a Question with the AID key
    /// </summary>
    public class Answer
    {
        [Key]
        public int AID { get; set; }
        [Required]
        public string Answers { get; set; }
    }
}
