namespace Terminal.Interfaces
{
    public interface ICommand
    {
        public bool ValidateParams();
        public void Execute();
    }
}