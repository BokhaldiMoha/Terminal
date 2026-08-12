namespace Terminal.Logic.Interfaces
{
    internal interface ICommand
    {
        public void SetArgs(string[] args);
        public string[] Execute();
    }
}