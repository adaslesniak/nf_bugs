using System.Threading;
using SourceLibrary;


namespace TestProject
{

    class Implementation : BaseClass, IInterface { }

    class ImplmentationByInheritance : Implementation { }
      

    public class Program
    {

        public static void Main()
        {

            //this bug is not replicable if base class and interface are defined in executed project
            //it happens when they are defined in separate library

            var asImplementationByInheritance = new ImplmentationByInheritance();
            Print(asImplementationByInheritance is IInterface, "ImplmentationByInheritance");
            var asBaseClass = asImplementationByInheritance as BaseClass;
            Print(asBaseClass is IInterface, "BaseClass");
            

            Thread.Sleep(Timeout.Infinite);

            void Print(bool isTrue, string objectType)
            {
                var header = $"[{isTrue}]";
                System.Console.WriteLine($"{header} the same object as {objectType} is IInterface");
            }
        }
    }
}
