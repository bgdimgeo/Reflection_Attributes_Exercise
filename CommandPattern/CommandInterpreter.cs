
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArgs1 = args.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string cmdName = cmdArgs1[0];
            string[] cmdArgs = cmdArgs1.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type cmdType = assembly?.GetTypes().FirstOrDefault(t => t.Name == $"{cmdName}Command"
                                            && t.GetInterfaces().Any(i => i == typeof(ICommand)));
            if (cmdType == null) 
            {
                throw new InvalidOperationException("Invalid command");
            }
            object cmdInstance = Activator.CreateInstance(cmdType);

            MethodInfo executeMethod = cmdType.GetMethods().First(m => m.Name == "Execute");

            string result = (string)executeMethod.Invoke(cmdInstance, new object[] { cmdArgs });

            return result;
        }
    }
}
