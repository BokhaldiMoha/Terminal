using Terminal.Logic.Interfaces;
using Terminal.Logic.Validators;

namespace Terminal.Logic
{
    public class Command
    {
        private ICommand _command;

        public Command(string? rawInput)
        {
            RawInputValidator rawInputValidator = new(rawInput);
            
            if (!rawInputValidator.Validate(out ICommand? command) || command is null)
                throw new ArgumentException("Invalid command or arguments.");

            _command = command;
        }

        public string[] Execute()
        {
            return _command.Execute();
        }
    }
}