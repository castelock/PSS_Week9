using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Model
{
    // Delegate method
    public delegate bool ExprCond(CPersonLambda person);
    public sealed class CPersonLambda
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public static void BornedYear(List<CPersonLambda> listPeople, ExprCond condition)
        {
            foreach(CPersonLambda p in listPeople)
            {
                if (condition(p))
                    Console.WriteLine("Person's name who meets the condition: " + p.Name);
            }
        }
    }
}
