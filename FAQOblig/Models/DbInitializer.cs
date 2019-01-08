using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAQOblig.Models
{
    public class DbInitializer
    {
        /// <summary>
        /// Initializer method for seeding the database with pre-made 
        /// Questions and Answers for the FAQ-frontend.
        /// </summary>
        /// <param name="context">Gets the context-object via parameter</param>
        public static void Initialize(FAQContext context)
        {

            //If already seeded, just return.
            if (context.Questions.Any())
            {
                return;
            }
            var questions = new Questions[] {
            new Questions
            {

                Question = "Hvordan endrer jeg passord?",
                Answer = new Answer
                {

                    Answers = "Kontakt brukerstøtte"
                },
                Downvotes = 0,
                Upvotes = 0,
                Qtype = QEnumType.Account
            },
            new Questions
            {

                Question = "Kan min bror også lage bruker?",
                Answer = new Answer
                {

                    Answers = "Alle er velkommen til å lage bruker"
                },
                Downvotes = 0,
                Upvotes = 0,
                Qtype = QEnumType.Account
            },
            new Questions
            {

                Question = "Kan jeg endre email til min bruker?",
                Answer = new Answer
                {

                    Answers = "For å endre email må du kontakte brukerstøtte"
                },
                Downvotes = 0,
                Upvotes = 0,
                Qtype = QEnumType.Account
            },
            new Questions
            {

                Question = "Kan jeg kjøpe så mange filmer jeg vil?",
                Answer = new Answer
                {

                    Answers = "Du kan kjøpe så mange filmer du vil"
                },
                Downvotes = 0,
                Upvotes = 0,
                Qtype = QEnumType.Customer
            },
            new Questions
            {

                Question = "Har dere gavekort jeg kan gi bort?",
                Answer = new Answer
                {

                    Answers = "Vi tilbyr ikke per dags dato gavekort, men det kommer"
                },
                Downvotes = 0,
                Upvotes = 0,
                Qtype = QEnumType.Customer
            },
            new Questions
            {

                Question = "Hvordan kontakter jeg brukerstøtte?",
                Answer = new Answer
                {

                    Answers = "Du kan kontakte brukerstøtte via mail bruker@støtte.no"
                },
                Downvotes = 0,
                Upvotes = 0,
                Qtype = QEnumType.Customer
            },
            new Questions
            {

                Question = "Hvor finner jeg filmene etter kjøp?",
                Answer = new Answer
                {

                    Answers = "Du finner filmene dine ved å trykke på 'Mine Filmer'"
                },
                Downvotes = 0,
                Upvotes = 0,
                Qtype = QEnumType.Delivery
            },
            new Questions
            {

                Question = "Er det mulighet å få filmene i dvd?",
                Answer = new Answer
                {

                    Answers = "Foreløpig kan det bare streames via din bruker"
                },
                Downvotes = 0,
                Upvotes = 0,
                Qtype = QEnumType.Delivery
            },
            new Questions
            {

                Question = "Jeg vil ikke se mer på filmen, hva gjør jeg?",
                Answer = new Answer
                {

                    Answers = "Da trykker du bare stopp, så stopper filmen"
                },
                Downvotes = 0,
                Upvotes = 0,
                Qtype = QEnumType.Delivery
            },
            new Questions
            {

                Question = "Er det mulig å betalte kontant?",
                Answer = new Answer
                {

                    Answers = "Betaling gjøres kun via kort"
                },
                Downvotes = 0,
                Upvotes = 0,
                Qtype = QEnumType.Payments
            },
            new Questions
            {

                Question = "Filmen var dårlig og jeg vil ha tilbake pengene",
                Answer = new Answer
                {

                    Answers = "I spesielle tilfeller må du kontakte brukerstøtte"
                },
                Downvotes = 0,
                Upvotes = 0,
                Qtype = QEnumType.Payments
            },
            new Questions
            {

                Question = "Jeg har lyst å betale dere siden dere er så flinke! Hvor gjør jeg det?",
                Answer = new Answer
                {

                    Answers = "Du kan sende meg penger personlig. Tar kun kontant. "
                },
                Downvotes = 0,
                Upvotes = 0,
                Qtype = QEnumType.Payments
            },

        };
            foreach(Questions q in questions)
            {
                context.Add(q);
            }
            context.SaveChanges();
        }
    }
}
