using Terminal.Logic.Executors;
using Terminal.Logic.Interfaces;

namespace Terminal.Logic.Commands
{
    internal class PwdCommand : ICommand
    {
        public void SetArgs(string[] args)
        {
        }

        public string[] Execute()
        {
            var executor = new PwdCommandExecutor();
            return executor.Execute();
        }
    }
}
