using LINQ_Model;
using System;
using System.Linq;

namespace LINQ_Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The options for this program are: {0} 1- Declaring implicit local variable. {0} " +
                "2- Creating arrays of implicitly defined types. {0} " +
                "3-  Anonymous types. {0} 4- Self-implementing properties. {0} " +
                "5- Object and collection launchers. {0} 6- Extender methods. {0} " +
                "7- Lambda expression. {0} 8- The delegate Func. {0} " +
                "9- The delegate Func with 2 params. {0} 10- Query operators. {0} " +
                "11- Lambda Expression Trees. {0}", Environment.NewLine);
            Console.WriteLine("Insert one of the previous options: ");
            String option = Console.ReadLine();

            LINQFeatures linq_features = new LINQFeatures();
            switch (option)
            {
                case "1":
                    // Declaring implicit local variable
                    linq_features.declareLocalVariable();
                    break;
                case "2":
                    // Creating arrays of implicitly defined types
                    linq_features.createArrays();
                    break;
                case "3":
                    // Anonymous types
                    linq_features.createAnonymousTypes();
                    break;
                case "4":
                    // Self-implementing properties
                    linq_features.selfImplementProperties();
                    break;
                case "5":
                    // Object and collection launchers
                    linq_features.createPerson();
                    linq_features.createPersonCollection();
                    break;
                case "6":
                    // Extender methods
                    linq_features.extendMethods();
                    break;
                case "7":
                    // Lambda expression
                    linq_features.createLambdaExpr();
                    linq_features.testLambdaExpr();
                    break;
                case "8":
                    // The delegate Func
                    bool result = linq_features.tryFunc();
                    Console.WriteLine("The result of the delegate Func is: " + result);
                    linq_features.testFuncYear();
                    break;
                case "9":
                    // The delegate Func with 2 params
                    linq_features.testFuncYear2Param();
                    break;
                case "10":
                    // Query operators
                    linq_features.queryCount();
                    linq_features.queryTakeWhile();
                    linq_features.queryOrdered();
                    break;
                case "11":
                    // Lambda Expression Trees
                    linq_features.createExprTree();
                    break;
                default:
                    Console.WriteLine("The option is not valid.");
                    break;
            }
            



            

            // This should be deleted
            string[] digitos = { "dos", "uno", "cero", "tres", "cuatro",
                "cinco", "seis", "siete", "ocho", "nueve" };
            double longitudMenor = digitos.Min(w => w.Length);
            Console.WriteLine("The minimum is: " + longitudMenor);
        }
    }
}
