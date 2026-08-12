using Terminal.Logic.Executors;
using Terminal.Logic.Interfaces;

namespace Terminal.Logic.Commands
{
    internal class LsCommand : ICommand
    {
        private string[] _args = Array.Empty<string>();

        public void SetArgs(string[] args)
        {
            _args = args;
        }

        public string[] Execute()
        {
            var executor = new LsCommandExecutor();
            return executor.Execute();
        }
    }
}