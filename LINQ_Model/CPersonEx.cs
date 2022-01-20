using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Model
{
    public static class CPersonEx
    {
        public static int Age(this CPersonSeal person)
        {
            int edad = DateTime.Today.Year - person.BirthDate.Year;

            if (DateTime.Today.Month > person.BirthDate.Month || DateTime.Today.Month == person.BirthDate.Month
                && DateTime.Today.Day >= person.BirthDate.Day)
                return edad;
            return edad - 1;
        }
    }
}
