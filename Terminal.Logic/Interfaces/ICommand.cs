namespace Terminal.Logic.Interfaces
{
    internal interface ICommand
    {
        public bool ValidateParams();
        public void Execute();
    }
}