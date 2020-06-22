using System;
using System.Threading;
using System.Diagnostics;

namespace asTest
{
    class Base { }
    interface ISomeInterface { }

    class Implementing : Base, ISomeInterface { }

    class ImplementingByInheritance : Implementing { }
      

    public class Program
    {

        static bool isImplementing(Base target)
        {
            if(target is ISomeInterface)
            {
                return true;
            }
            if(target as ISomeInterface != null)
            {
                return true;
            }
            return false;
        }


        public static void Main()
        {

            var testObject = new ImplementingByInheritance();

            var testObjeAsSI = testObject as ISomeInterface;
            System.Console.WriteLine($"[{testObjeAsSI != null}] testObject is ISomeInterface");

            var hereIsBug = isImplementing(testObject);
            System.Console.WriteLine($"[{hereIsBug}] testObject is ISomeInterface");

            Thread.Sleep(Timeout.Infinite);

            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T
        }
    }
}
