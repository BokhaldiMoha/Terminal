using Terminal.Logic.Interfaces;

namespace Terminal.Logic.Executors
{
    internal class LsCommandExecutor : ICommandExecutor
    {
        private readonly bool _showHidden;

        public LsCommandExecutor(bool showHidden)
        {
            _showHidden = showHidden;
        }

        public string[] Execute()
        {
            var entries = Directory.EnumerateFileSystemEntries(Globals.CurrentDirectory);
            if (!_showHidden)
                entries = entries.Where(e => !File.GetAttributes(e).HasFlag(FileAttributes.Hidden));
            return entries.ToArray();
        }
    }
}