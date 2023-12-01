namespace lab123
{
    public abstract class Executor
    {
        protected string input { get; set; }
        protected string output { get; set; }

        public Executor(string inputPath, string outputPath)
        {
            UpdateInputPath(inputPath);
            UpdateOutputPath(outputPath);
        }

        public void UpdateInputPath(string inputPath)
        {
            input = inputPath;
        }

        public void UpdateOutputPath(string outputPath)
        {
            output = outputPath;
        }

        public abstract void OnExecute();
    }
}