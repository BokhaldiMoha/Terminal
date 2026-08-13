using Terminal.Logic.Interfaces;

namespace Terminal.Logic.Validators
{
    internal class CommandValidator
    {
        private const string _commandNamespace = "Terminal.Logic.Commands";
        private const string _argsValidatorNamespace = "Terminal.Logic.Validators.ArgsValidators";
        private const string _argsValidatorSufix = "ArgsValidator";

        public static Dictionary<string, string> ValidCommands = new()
        {
            { "ls", "LsCommand" },
            { "cd", "CdCommand" },
            { "pwd", "PwdCommand" },
        };

        private string _command;

        public CommandValidator(string command)
        {
            _command = command;
        }

        public bool ValidateCommand() => ValidCommands.ContainsKey(_command);

        public bool ValidateArgs(string[] args)
        {
            Type? argsValidatorType = Type.GetType(BuildArgsVaildatorTypeName());

            if (argsValidatorType == null || !argsValidatorType.IsAssignableTo(typeof(IArgsValidator)))
                throw new InvalidOperationException("Internal error: Failed to create args validator instance.");

            object? instance = Activator.CreateInstance(argsValidatorType);

            if (instance is not IArgsValidator argsValidator)
                throw new InvalidOperationException("Internal error: Failed to create args validator instance.");

            return argsValidator.ValidateArgs(args);
        }

        public ICommand GetCommand()
        {
            Type? commandType = Type.GetType(BuildCommandTypeName());

            if (commandType == null || !commandType.IsAssignableTo(typeof(ICommand)))
                throw new InvalidOperationException("Internal error: Failed to create command instance.");

            object? instance = Activator.CreateInstance(commandType);

            if (instance is not ICommand command)
                throw new InvalidOperationException("Internal error: Failed to create command instance.");

            return command;
        }

        private string BuildArgsVaildatorTypeName()
        {
            return $"{_argsValidatorNamespace}.{ValidCommands[_command]}{_argsValidatorSufix}";
        }

        private string BuildCommandTypeName()
        {
            return $"{_commandNamespace}.{ValidCommands[_command]}";
        }
    }
}