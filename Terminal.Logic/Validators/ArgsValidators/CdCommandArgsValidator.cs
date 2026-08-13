using Terminal.Logic.Interfaces;

namespace Terminal.Logic.Validators.ArgsValidators
{
    internal class CdCommandArgsValidator : IArgsValidator
    {
        public bool ValidateArgs(string[] args)
        {
            return args.Length == 1;
        }
    }
}