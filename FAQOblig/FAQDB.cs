using FAQOblig.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAQOblig
{
    /// <summary>
    /// FAQDB is the class with all the methods used to interract with the
    /// database.
    /// </summary>
    public class FAQDB
    {
        private readonly FAQContext _context;
        public FAQDB(FAQContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Getting all the Questions and Answers
        /// </summary>
        /// <returns>List of Questions</returns>
        public List<Questions> getquestionsFAQ()
        {
            try
            {
                var data = _context.Questions.Include("Answer").ToList();

                return data;
            } catch(Exception e)
            {
                //Exception should be logged.
                return null;
            }
        }

        /// <summary>
        /// Getting all the Top rated Customer Questions
        /// </summary>
        /// <returns>List of CustomerQuestions</returns>
        public List<CustomerQuestion> getTopRatedQuestionFAQ()
        {
            try
            {
                var QueryableData = _context.CustomerQuestions.Include("Answer").OrderByDescending(q => q.Upvotes).Take(5);

                var data = QueryableData.ToList();

                return data;

            }catch(Exception e)
            {
                //Exception should be logged
                return null;
            }
            
        }
        /// <summary>
        /// Getting all the CustomerQuestions
        /// </summary>
        /// <returns>A list of CustomerQuestions</returns>
        public List<CustomerQuestion> getCustomerQuestionsFAQ()
        {
            try
            {
                var data = _context.CustomerQuestions.Include("Answer").ToList();

                return data;
            }
            catch(Exception e)
            {
                //Exception should be logged. 
                Console.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Incrementing votes in the database, either Upvotes or Downvotes
        /// </summary>
        /// <param name="increment"></param>
        /// <param name="id"></param>
        /// <returns>True if OK, or false if catching a exception</returns>
        public bool incrementVotes(string increment, int id)
        {
            try
            {
                var question = _context.CustomerQuestions.FirstOrDefault(q => q.CQID == id);

                if (increment == "True")
                {
                    question.Upvotes += 1;
                }
                else
                {
                    question.Downvotes += 1;
                }

                _context.SaveChanges();
                return true;
            }catch(Exception e)
            {
                //Exception should be logged
                Console.WriteLine(e);
                return false;
            }
            
        }

        //This method was intended for the FAQController calls
        //But I removed this feature. 
        public bool incrementVotes_(string increment, int id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.QID == id);

            if (increment == "True")
            {
                question.Upvotes += 1;
            }
            else
            {
                question.Downvotes += 1;
            }

            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Adds a customerQuestion to the database
        /// </summary>
        /// <param name="question">CustomerQuestion paramter</param>
        /// <returns>A bool</returns>
        public bool addCustomerQuestion(CustomerQuestion question)
        {
            try
            {
                var newQ = new CustomerQuestion()
                {
                    Question = question.Question,
                    Downvotes = question.Downvotes,
                    Upvotes = question.Upvotes,
                    Email = question.Email,
                    Answer = new Answer()
                    {
                        Answers = ""
                    },
                };


                _context.Add(newQ);
                _context.SaveChanges();

                return true;
            }catch(Exception e)
            {
                //Exception should be logged
                Console.WriteLine(e);
                return false;
            }
            

           
            
        }

    }
}
