using Terminal.Logic.Interfaces;

namespace Terminal.Logic.Validators.ArgsValidators
{
    internal class LsCommandArgsValidator : IArgsValidator
    {
        private readonly string[] _validArgs = { "-a" };

        public bool ValidateArgs(string[] args)
        {
            return args.All(arg => _validArgs.Contains(arg));
        }
    }
}