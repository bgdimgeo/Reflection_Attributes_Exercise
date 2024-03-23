using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Steal_lab.Objects
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields) 
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance|BindingFlags.Public
                |BindingFlags.Static | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType,new object[] { });
            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name))) 
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }
        public string AnalyzeAcessModifiers(string investigatedClass)
        {

            Assembly assembly = Assembly.GetCallingAssembly();

            Type classType = assembly?.GetTypes().FirstOrDefault(t => t.FullName == $"{investigatedClass}");

            //Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classPrivateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (FieldInfo field in classFields) 
            {
                stringBuilder.AppendLine($"{field.Name} must be private");
            }
            
            foreach (MethodInfo method in classPrivateMethods.Where(m => m.Name.StartsWith("get"))) 
            {
                stringBuilder.AppendLine($"{method.Name} have to be public");
            }
            foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be private");
            }
            return stringBuilder.ToString().Trim();
        }

        public string RevalPrivateMethods(string className) 
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type classType = assembly?.GetTypes().FirstOrDefault(t => t.FullName == className);

            MethodInfo[] classPrivateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            foreach(MethodInfo method in classPrivateMethods) 
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }
        public string CollectGettersAndSetters(string className) 
        {
            Type classType = Type.GetType(className);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();
            foreach (MethodInfo method in classMethods.Where(n => n.Name.StartsWith("get"))) 
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (MethodInfo method in classMethods.Where(n => n.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }

        public string CollectInterfaces(string className) 
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type classType = assembly.GetTypes().FirstOrDefault(n => n.FullName == className);
            Type[] interfaces = classType.GetInterfaces();

            StringBuilder sb = new StringBuilder();

            foreach(Type inte in interfaces)
            {
                sb.AppendLine($"{classType.Name} got interface with {inte.Name}");
            }
            return sb.ToString().Trim();
        }

        public string ChangeValues(string className) 
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type classType = assembly.GetTypes().FirstOrDefault(n=>n.FullName == className);
            Object classInstance = Activator.CreateInstance(classType);

            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic);

            string result = string.Empty;

            foreach (FieldInfo field in fields.Where(m=>m.Name == "password")) 
            {
                field.SetValue(classInstance, "Pesho");
                result = (string)field.GetValue(classInstance);
            }
            return result;
        }
    }
}
