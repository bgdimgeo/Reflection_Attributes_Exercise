using Steal_lab.Objects;
using System;

namespace Steal_lab
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Steal_lab.Hacker", "username", "password");
            Console.WriteLine(result);
            string result2 = spy.AnalyzeAcessModifiers("Steal_lab.Hacker");
            Console.WriteLine(result2);
            string result3 = spy.RevalPrivateMethods("Steal_lab.Hacker");
            Console.WriteLine(result3);
            string result4 = spy.CollectGettersAndSetters("Steal_lab.Hacker");
            Console.WriteLine(result4);
            string result5 = spy.CollectInterfaces("Steal_lab.Hacker");
            Console.WriteLine(result5);
            string result6 = spy.ChangeValues("Steal_lab.Hacker");
            Console.WriteLine(result6);
        }
    }
}
