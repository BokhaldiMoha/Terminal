namespace Terminal.Logic.Executors
{
    internal class LsCommandExecutor
    {
        public LsCommandExecutor() { }

        public string[] Execute()
        {
            return ["file1.txt", "file2.txt"];
        }
    }
}
