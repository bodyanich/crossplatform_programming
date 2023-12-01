using lab123;

namespace cross_lab5.Data
{
    public class Lab123Executor
    {
        private static readonly string INPUT = "input.txt";
        private static readonly string OUTPUT = "output.txt";

        private void WriteToInput(string input)
        {
            using (StreamWriter writer = new StreamWriter(INPUT))
            {
                writer.Write(input);
            }
        }

        private string ReadFromOutput()
        {
            var result = "";
            using (StreamReader reader = new StreamReader(OUTPUT))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        private string ExecuteLab(Executor executor, string input)
        {
            try
            {
                WriteToInput(input);
                executor.OnExecute();
                return ReadFromOutput();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public string ExecuteLab1(string input)
        {
            return ExecuteLab(new lab123.Lab1(INPUT, OUTPUT), input);
        }

        public string ExecuteLab2(string input)
        {
            return ExecuteLab(new lab123.Lab2(INPUT, OUTPUT), input);
        }

        public string ExecuteLab3(string input)
        {
            return ExecuteLab(new lab123.lab3(INPUT, OUTPUT), input);
        }
    }
}

