using System;
using System.Collections.Generic;

namespace ATSCADAWebApp.Designer.Command
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IDictionary<Type, ICommand> commands;

        public CommandFactory()
        {
            this.commands = new Dictionary<Type, ICommand>();
        }

        public void Register(params object[] commands)
        {
            foreach (var command in commands)
                Register(command);
        }

        public void Register(object command)
        {
            if (command is ICommand commandRes)
                this.commands[command.GetType()] = commandRes;
        }

        public ICommand Get<T>() where T : class, ICommand
        {
            if (this.commands.TryGetValue(typeof(T), out ICommand command))
                return command;
            return default;
        }

        public IEnumerable<ICommand> GetAll()
        {
            return this.commands.Values;
        }
    }
}
