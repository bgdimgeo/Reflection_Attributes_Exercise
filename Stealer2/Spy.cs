using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields) 
        {
            Type classType = Type.GetType(investigatedClass);

            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | 
                BindingFlags.Instance | BindingFlags.NonPublic
                | BindingFlags.Instance | BindingFlags.Static);

            StringBuilder stringBuilder = new StringBuilder();


            return null;
        }
    }
}
