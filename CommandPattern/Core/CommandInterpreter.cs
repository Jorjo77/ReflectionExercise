using CommandPattern.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string PostFix = "Command";
        public string Read(string args)
        {
            string[] splittesArgs = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = (splittesArgs[0] + "Command");
            string commandTypeName = commandName + PostFix;
            string[] commandArgs = splittesArgs.Skip(1).ToArray();

            //Намираме типа, като филтрираме и за интерфейса (стъпка 1)
            Type commandType = Assembly.GetCallingAssembly()
                .GetTypes()
                .Where(t=>t.GetInterfaces()
                .Any(i=>i.Name == nameof(ICommand)))
                .FirstOrDefault(n => n.Name == commandName);

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type");
            }
            //Правим му инстанция (стъпка 2)
            ICommand instanceType = Activator.CreateInstance(commandType) as ICommand;//Тук в скобата след commandType можем да подадем параметри на конструктора изброени със запетая, ако има такива!!!

            //Тук е стандартното познато решение, а горе е с рефлекшън!
            //string result = string.Empty;
            //ICommand command = null;
            //switch (commandName)
            //{
            //    case "Hello":
            //        command = new HelloCommand();
            //        break;
            //    case "Exit":
            //        command = new ExitCommand();
            //        break;
            //    case "Open":
            //        command = new OpenCommand();
            //        break;
            //    default:
            //        throw new ArgumentException("Invalid command type!");
            //}

            if (instanceType == null)
            {
                throw new ArgumentException("Invalid command type");
            }
            //Викаме му метода (стъпка 3)
            string result = instanceType.Execute(commandArgs);

            return result;
        }
    }
}
