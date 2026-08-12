using Terminal.Logic.Interfaces;

namespace Terminal.Logic.Validators.ArgsValidators
{
    internal class LsCommandArgsValidator : IArgsValidator
    {
        public bool ValidateArgs(string[] args)
        {
            return true;
        }
    }
}
