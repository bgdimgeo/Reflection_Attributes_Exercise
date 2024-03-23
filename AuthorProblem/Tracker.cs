using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProblem
{
    public class Tracker
    {
        private Type type;
        public Tracker(Type type)
        {
            this.type = type;
        }

        public void PrintMethodsByAuthor() 
        {

            MethodInfo[] methods = this.type.GetMethods(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            foreach (MethodInfo method in methods) 
            {
                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute))) 
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attr in attributes) 
                    {
                        Console.WriteLine("{0} is written by {1}",method.Name, attr.Name);
                    }
                }
            }
            var attr2 = this.type.GetCustomAttributes(false);
            Console.WriteLine("OK");

        }
        
    }
}
