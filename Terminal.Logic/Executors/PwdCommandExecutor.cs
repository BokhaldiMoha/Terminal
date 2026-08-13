using Terminal.Logic.Interfaces;

namespace Terminal.Logic.Executors
{
    internal class PwdCommandExecutor : ICommandExecutor
    {
        public string[] Execute()
        {
            return new string[] { Globals.CurrentDirectory };
        }
    }
}
