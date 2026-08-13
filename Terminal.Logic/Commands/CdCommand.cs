using Terminal.Logic.Executors;
using Terminal.Logic.Interfaces;

namespace Terminal.Logic.Commands
{
    internal class CdCommand : ICommand
    {
        private string _path = string.Empty;

        public void SetArgs(string[] args)
        {
            _path = args[0];
        }

        public string[] Execute()
        {
            var executor = new CdCommandExecutor(_path);
            return executor.Execute();
        }
    }
}
