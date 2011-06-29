using System.Collections.Generic;

namespace RudeBuildAddIn
{
    public class CommandRegistry
    {
        private IDictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();

        public void Register(ICommand command)
        {
            if (_commands.ContainsKey(command.Name))
                throw new System.ArgumentException("The command " + command.Name + " is already registered.");

            _commands.Add(command.Name, command);
        }

        public ICommand Get(string commandName)
        {
            ICommand result = null;
            _commands.TryGetValue(commandName, out result);
            return result;
        }
    }
}