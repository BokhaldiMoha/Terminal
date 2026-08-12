using Terminal.Logic.Interfaces;

namespace Terminal.Logic.Validators
{
    internal class RawInputValidator
    {
        private string? _rawInput;

        public RawInputValidator(string? rawInput) => _rawInput = rawInput;

        public bool Validate(out ICommand? command)
        {
            if (string.IsNullOrWhiteSpace(_rawInput))
            {
                command = null;
                return false;
            }

            string[] tmpArgs = _rawInput.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            string commandName = tmpArgs[0];
            return TryGetCommand(commandName, tmpArgs.Skip(1).ToArray(), out command);
        }

        private static bool TryGetCommand(string commandName, string[] args, out ICommand? command)
        {
            var commandValidator = new CommandValidator(commandName);
            bool isValid = commandValidator.ValidateCommand() && commandValidator.ValidateArgs(args);

            command = isValid ? commandValidator.GetCommand() : null;
            return isValid;
        }
    }
}