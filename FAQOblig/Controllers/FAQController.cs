using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FAQOblig.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;


namespace FAQOblig.Controllers
{
    [Route("api/[controller]")]
    public class FAQController : Controller
    {
        private readonly FAQContext _context;

        public FAQController(FAQContext context)
        {
            _context = context;
        }

        //Get method for getting all the questions in the Question table 
        //in database.
        [HttpGet]
        public IActionResult Get()
        {
            var db = new FAQDB(_context);

            var data = db.getquestionsFAQ();
            var JsonData = JsonConvert.SerializeObject(data);

            if(JsonData != null)
            {
                return Ok(JsonData);
            }
            else
            {
                return BadRequest("Something went wrong!");
            }
        }


        //This method is not used
        //It updates the Upvotes and Downvotes on the FAQ question in 
        //frontend. But I removed this feature. 
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string increment)
        {
            
            var db = new FAQDB(_context);
            bool success = db.incrementVotes_(increment, id);

            if (success)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }




    }
}
