using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Model
{
   
    public class CPersonFunc
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public static void BornedYear(List<CPersonFunc> listPeople, Func<CPersonFunc, bool> condition)
        {
            foreach (CPersonFunc p in listPeople)
            {
                if (condition(p))
                    Console.WriteLine("Person's name who meets the condition: " + p.Name);
            }
        }
    }
}
