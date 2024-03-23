using System;
using System.Reflection;

namespace AuthorProblem
{
    [Author("Pesho")]
    public class StartUp
    {
        [Author("Gosho")]
        static void Main(string[] args)
        {
            Type type = MethodBase.GetCurrentMethod().DeclaringType;
            var tracker = new Tracker(type);

           
            tracker.PrintMethodsByAuthor();

        }
    }
}
