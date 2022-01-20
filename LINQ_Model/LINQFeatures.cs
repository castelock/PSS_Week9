using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace LINQ_Model
{
    public class LINQFeatures
    {
        // Declaring implicit local variable
        public void declareLocalVariable()
        {
            var e = 0;
            Console.WriteLine("The full name is: " + e.GetType().FullName);
        }

        // Creating arrays of implicitly defined types
        public void createArrays()
        {
            var m = new[] { 1, 2, 3 };

            foreach (var a in m)
                Console.WriteLine(a);

            Console.WriteLine(m.GetType().FullName);
        }

        // Anonymous types
        public void createAnonymousTypes()
        {
            var person = new { Name = "Elena", Age = 24 };
            Console.WriteLine(person.Name);
            Console.WriteLine(person.GetType().FullName);
        }

        // Self-implementing properties
        public void selfImplementProperties()
        {
            CPerson person = new CPerson();
            person.Name = "Ramón";
            Console.WriteLine("The person's name is: " + person.Name);

            CPerson2 person2 = new CPerson2();
            person2.Name = "Elena";
            Console.WriteLine("The person's name is: " + person2.Name);
        }

        // Object and collection launchers
        public void createPerson()
        {
            var person = new CPersonSeal { Name = "Elena", BirthDate = new DateTime(1990, 6, 25) };
        }

        public void createPersonCollection()
        {
            List<CPersonSeal> listPerson = new List<CPersonSeal>
            {
                new CPersonSeal{Name = "Eva", BirthDate = new DateTime(1988, 4, 12)},
                new CPersonSeal{Name = "Pedro", BirthDate = new DateTime(1995, 2, 20)},
            };

            foreach (var p in listPerson)
            {
                Console.WriteLine("Person data: " + p.Name + " " + p.BirthDate);
            }
        }

        // Extender methods
        public void extendMethods()
        {
            List<CPersonSeal> listPerson = new List<CPersonSeal>
            {
                new CPersonSeal{Name = "Eva", BirthDate = new DateTime(1988, 4, 12)},
                new CPersonSeal{Name = "Pedro", BirthDate = new DateTime(1995, 2, 20)},
            };

            Console.WriteLine("This person's age is: " + listPerson[1].Age());
        }

        // Lambda expression
        public delegate void sum(double x, double y);
        public void createLambdaExpr()
        {
            sum sumLambda = (a, b) => { var s = a + b; 
                Console.WriteLine("The result of the sum with lambda expression is: "+s); };
            sumLambda(10, 7);
        }
            
        public void testLambdaExpr()
        {
            List<CPersonLambda> listPerson = new List<CPersonLambda>
            {
                new CPersonLambda{Name = "Eva", BirthDate = new DateTime(1988, 4, 12)},
                new CPersonLambda{Name = "Pedro", BirthDate = new DateTime(1995, 2, 20)},
            };

            CPersonLambda.BornedYear(listPerson, (CPersonLambda p) => p.BirthDate.Year==1995);

            //CPersonLambda.BornedYear(listPerson, delegate (CPersonLambda p)
            //{
            //    return p.BirthDate.Year == 1995;
            //});
        }

        // The delegate Func

        public bool tryFunc()
        {
            Func<int, bool> esPar = n => n % 2 == 0;
            return esPar(11);
        }

        public void testFuncYear()
        {
            List<CPersonFunc> listPerson = new List<CPersonFunc>
            {
                new CPersonFunc{Name = "Eva", BirthDate = new DateTime(1988, 4, 12)},
                new CPersonFunc{Name = "Pedro", BirthDate = new DateTime(1995, 2, 20)},
            };

            CPersonFunc.BornedYear(listPerson, (CPersonFunc p) => p.BirthDate.Year == 1995);
        }

        public void testFuncYear2Param()
        {
            List<CPersonFunc> listPerson = new List<CPersonFunc>
            {
                new CPersonFunc{Name = "Eva", BirthDate = new DateTime(1988, 4, 12)},
                new CPersonFunc{Name = "Pedro", BirthDate = new DateTime(1995, 2, 20)},
            };

            Func<CPersonFunc, int,  bool> isBornedYear = (p, year) => p.BirthDate.Year == year;

            foreach(CPersonFunc p in listPerson)
            {
                if(isBornedYear(p, 1995))
                    Console.WriteLine("Person's name who meets the condition: " + p.Name);
            }
        }

        // Query operators
        public void queryCount()
        {
            //IEnumerable<int> numbers = new List<int>{ 6, 7, 11, 9, 8, 5, 4, 1, 3, 2 };
            int[] numbers = { 6, 7, 11, 9, 8, 5, 4, 1, 3, 2 };
            int evenNumbers = numbers.Count(n => n % 2 == 0);
            Console.WriteLine("Total even numbers: " + evenNumbers);
        }

        public void queryTakeWhile()
        {
            int[] numbers = { 6, 7, 11, 9, 8, 5, 4, 1, 3, 2 };
            var numsLessThan9 = numbers.TakeWhile((int n) => n < 9);

            Console.Write("Numbers less than 9: ");
            foreach (int n in numsLessThan9)
                Console.Write(n+ " ");
            Console.WriteLine();
        }

        public void queryOrdered()
        {
            int[] numbers = { 6, 7, 11, 9, 8, 5, 4, 1, 3, 2 };
            var numsOddOrdered = numbers.Where(n => n % 2 != 0).OrderBy(n => n).Select(n => n);
            
            Console.Write("Numbers ordered: ");
            foreach (int n in numsOddOrdered)
                Console.Write(n + " ");
            Console.WriteLine();
        }

        // Lambda Expression Trees
        public void createExprTree()
        {
            List<CPersonFunc> listPerson = new List<CPersonFunc>
            {
                new CPersonFunc{Name = "Eva", BirthDate = new DateTime(1988, 4, 12)},
                new CPersonFunc{Name = "Pedro", BirthDate = new DateTime(1995, 2, 20)},
            };

            string people1995 = "";
            Expression<Func<CPersonFunc, bool>> exprBornedYear = (p) => p.BirthDate.Year == 1995;

            foreach(CPersonFunc p in listPerson)
            {
                bool isBorned = exprBornedYear.Compile().Invoke(p);
                if (isBorned)
                    people1995 += p.Name + Environment.NewLine;
            }

            Console.WriteLine("Expression tree result: " + people1995);
        }
    }
}
