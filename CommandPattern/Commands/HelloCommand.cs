using CommandPattern.Core.Contracts;
using System;


namespace CommandPattern.Core
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            string name = args[0];
            return $"Hello, {name}";
        }
    }
}
