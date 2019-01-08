using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAQOblig.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FAQOblig.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFAQController : Controller
    {
        private readonly FAQContext _context;

        public CustomerFAQController(FAQContext context)
        {
            _context = context;
        }

        //Get method for getting all top rated CustomerQuestions
        //by Upvotes
        [HttpGet("GetTopRated")]
        public IActionResult GetTopRated()
        {
            var db = new FAQDB(_context);

            var ListData = db.getTopRatedQuestionFAQ();
            var JsonData = JsonConvert.SerializeObject(ListData);

            return Ok(JsonData);
        }

        //Get method for getting all the CustomerQuestions
        [HttpGet]
        public IActionResult Get()
        {
            var db = new FAQDB(_context);

            var ListData = db.getCustomerQuestionsFAQ();
            var JsonData = JsonConvert.SerializeObject(ListData);

            return Ok(JsonData);
        }

        //Put method for increasing the Upvotes or Downvotes 
        //in database.
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string increment)
        {
            
            var db = new FAQDB(_context);
            bool success = db.incrementVotes(increment, id);

            if (success)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }

        //Post method for getting questions as JSON data.
        //Validates backend validation.
        //Adds the question to the CustomerQuestions table in database.
        [HttpPost]
        public IActionResult Post([FromBody]CustomerQuestion question)
        {
            Console.WriteLine(ModelState);
            if (ModelState.IsValid)
            {
                var db = new FAQDB(_context);
                bool success = db.addCustomerQuestion(question);

                if (success)
                {
                    return Ok();
                }
            }
            
            return BadRequest("Something went wrong! Couldn't add the question");
        }
    }
}