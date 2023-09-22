namespace lab2
{
    internal class Program
    {
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

        static void WriteError(string errorMessage)
        {
            Console.WriteLine("Error: " + errorMessage);
            using (StreamWriter errorWriter = new StreamWriter("OUTPUT.txt"))
            {
                errorWriter.WriteLine("Error: " + errorMessage);
            }
        }

        static void DoTask()
        {
            try
            {
                using (StreamReader reader = new StreamReader("INPUT.txt"))
                {
                    string? str = reader.ReadLine();

                    if (str is null)
                    {
                        WriteError("Line is null (end of file).");
                        return;
                    }

                    if (!IsNumeric(str))
                    {
                        WriteError("Input line should contain only numeric characters.");
                        return;
                    }

                    using (StreamWriter writer = new StreamWriter("OUTPUT.txt"))
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
                WriteError("An unexpected error occurred: " + ex.Message);
            }
        }
        static void Main()
        {
            DoTask();
        }
    }
}