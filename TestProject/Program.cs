using System;
using System.Reflection;
using System.Threading;
using SourceLibrary;


namespace TestProject
{

    class Implementation : BaseClass, IInterface {
        public void anyMethod(int withIntParam) { }
    }


    class ImplmentationByInheritance : Implementation { }
    
    enum AnyEnum {  One, Two, Three }
      

    public class Program
    {

        public static void Main()
        {
            var testObject = new ImplmentationByInheritance();
            try {
                TestOne(testObject);
                Console.WriteLine("Test 1 passed");
            } catch(Exception error) {
                Console.WriteLine("Test 1 failed: " + error.Message);
            }
            try {
                TestTwo(testObject);
                Console.WriteLine("Test 2 passed");
            } catch(Exception error) {
                Console.WriteLine("Test 2 failed: " + error.Message);
            }
            Thread.Sleep(Timeout.Infinite);
        }

        static void TestOne(ImplmentationByInheritance testObject)
        {

            //this bug is not replicable if base class and interface are defined in executed project
            //it happens when they are defined in separate library

            var isFirstCase = testObject is IInterface;
            var asBaseClass = testObject as BaseClass;
            var isSecondCase = asBaseClass is IInterface;
            if(isFirstCase && isSecondCase == false)
            {
                throw new System.Exception($"[{isFirstCase}] & [{isSecondCase}] Something is wrong " + 
                    "checking for interface implementation works differently " +
                    "depending how object is referenced. ");
                //looks like "is" is checking for target.GetTypeOfReferenceNotOfReferenced() but only for Interfaces
            }
        }

        static void TestTwo(ImplmentationByInheritance testObject)
        {
            var isFirstCase = testObject is ImplmentationByInheritance;
            var asBaseClass = testObject as BaseClass;
            var isSecondCase = asBaseClass is ImplmentationByInheritance;
            if(isFirstCase && isSecondCase == false)
            {
                throw new System.Exception("[{isFirstCase}] & [{isSecondCase}] Something is wrong " +
                    "checking for interface implementation works differently " +
                    "depending how object is referenced. ");
            }
        }
    }
}
