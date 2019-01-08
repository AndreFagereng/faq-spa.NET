using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAQOblig.Models
{
    //QEnumType used to abstract the FAQ questions(Not CustomerQuestions)
    public enum QEnumType
    {
        Account,
        Payments,
        Delivery,
        Customer
    }
}
