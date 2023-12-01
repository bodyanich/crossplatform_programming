using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab123
{
    public class Lab2 : Executor
    {
        public Lab2(string inputPath, string outputPath) : base(inputPath, outputPath) { }
        public override void OnExecute()
        {
            try
            {
                using (StreamReader reader = new StreamReader(input))
                {
                    string? str = reader.ReadLine();

                    if (str is null)
                    {
                        WriteError("Line is null (end of file).", output);
                        return;
                    }

                    if (!IsNumeric(str))
                    {
                        WriteError("Input line should contain only numeric characters.", output);
                        return;
                    }

                    using (StreamWriter writer = new StreamWriter(output))
                    {
                        writer.Write(CountBeautifulPairs(int.Parse(str)));
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while reading/writing the file: " + ex.Message);
            }
            catch (Exception ex)
            {
                WriteError("An unexpected error occurred: " + ex.Message, output);
            }
        }

        static bool IsBeautiful(int num)
        {
            string numStr = num.ToString();
            for (int i = 1; i < numStr.Length; i++)
            {
                if (numStr[i] == numStr[i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        static int CountBeautifulPairs(int c)
        {
            int count = 0;
            string cStr = c.ToString();

            for (int a = (int)Math.Pow(10, cStr.Length - 1); a < c; a++)
            {
                int b = c - a;
                if (b < (int)Math.Pow(10, cStr.Length - 1))
                    return count;
                if (IsBeautiful(a) && IsBeautiful(b))
                {
                    count++;
                }
            }
            return count;
        }

        static bool IsNumeric(string input)
        {
            return input.All(char.IsDigit) && input[0] != '0';
        }

        static void WriteError(string errorMessage, string output)
        {
            Console.WriteLine("Error: " + errorMessage);
            using (StreamWriter errorWriter = new StreamWriter(output))
            {
                errorWriter.WriteLine("Error: " + errorMessage);
            }
        }
    }
}

