using Terminal.Logic.Interfaces;

namespace Terminal.Logic.Executors
{
    internal class CdCommandExecutor : ICommandExecutor
    {
        private readonly string _path;

        public CdCommandExecutor(string path)
        {
            _path = path;
        }

        public string[] Execute()
        {
            if (Path.IsPathRooted(_path))
            {
                if (Directory.Exists(_path))
                    Globals.CurrentDirectory = _path;
                else
                    throw new DirectoryNotFoundException($"The directory '{_path}' does not exist.");
            }
            else
            {
                string combinedPath = Path.GetFullPath(Path.Combine(Globals.CurrentDirectory, _path));
                if (Directory.Exists(combinedPath))
                    Globals.CurrentDirectory = combinedPath;
                else
                    throw new DirectoryNotFoundException($"The directory '{combinedPath}' does not exist.");
            }

            return [Globals.CurrentDirectory];
        }
    }
}
