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
            { "ls", "LsCommand" }
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

            if (argsValidatorType == null || !argsValidatorType.IsInstanceOfType(typeof(IArgsValidator)))
                throw new InvalidOperationException(nameof(argsValidatorType));

            object? instance = Activator.CreateInstance(argsValidatorType);

            if (instance is not IArgsValidator argsValidator)
                throw new InvalidOperationException(nameof(argsValidatorType));

            return argsValidator.ValidateArgs(args);
        }

        public ICommand GetCommand()
        {
            Type? commandType = Type.GetType(BuildCommandTypeName());

            if (commandType == null || !commandType.IsInstanceOfType(typeof(IArgsValidator)))
                throw new InvalidOperationException(nameof(commandType));

            object? instance = Activator.CreateInstance(commandType);

            if (instance is not ICommand command)
                throw new InvalidOperationException(nameof(commandType));

            return command;
        }

        private string BuildArgsVaildatorTypeName()
        {
            return $"{_argsValidatorNamespace}.{_command}{_argsValidatorSufix}";
        }

        private string BuildCommandTypeName()
        {
            return $"{_commandNamespace}.{_command}";
        }
    }
}