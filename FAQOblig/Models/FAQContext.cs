using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace FAQOblig.Models
{
    public class FAQContext : DbContext
    {
        public FAQContext()
        {

        }
        //Uses entityframework that comes with CORE 2.1
        public FAQContext(DbContextOptions<FAQContext> options) : base(options) {
            
        }
        //The DbSets in the database
        //This is a relation-database where Question and CustomerQuestion
        //are related with answers. 
        public DbSet<Questions> Questions { get; set; }
        public DbSet<CustomerQuestion> CustomerQuestions { get; set; }
        public DbSet<Answer> Answers { get; set; }

       


    }
}
