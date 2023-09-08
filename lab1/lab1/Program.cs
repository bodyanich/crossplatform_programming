namespace lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoTask();
        }

        static void DoTask()
        {
            try
            {
                using (StreamReader reader = new StreamReader("input.txt"))
                {
                    string? a = reader.ReadLine();
                    string? b = reader.ReadLine();

                    if (a is null || b is null)
                    {
                        WriteError("One or both lines are null (end of file).");
                        return;
                    }

                    if (!IsNumeric(a) || !IsNumeric(b))
                    {
                        WriteError("Input lines should contain only numeric characters.");
                        return;
                    }

                    int n = a.Length;
                    int m = b.Length;

                    int min_len = n + m;
                    for (int b_pos = -m; b_pos <= n; b_pos++)
                    {
                        int begin = Math.Min(b_pos, 0);
                        int end = Math.Max(b_pos + m - 1, n - 1);
                        bool state = true;
                        for (int j = begin; j <= end; j++)
                        {
                            int a_val;
                            if (j >= 0 && j < n)
                                a_val = a[j] - '0';
                            else
                                a_val = 1;

                            int b_val;
                            if (b_pos <= j && j < b_pos + m)
                                b_val = b[j - b_pos] - '0';
                            else
                                b_val = 1;

                            if (a_val + b_val > 3)
                            {
                                state = false;
                                break;
                            }
                        }
                        if (state)
                        {
                            int len = end - begin + 1;
                            if (len < min_len)
                                min_len = len;
                        }
                    }

                    using (StreamWriter writer = new StreamWriter("output.txt"))
                    {
                        writer.Write(min_len);
                    }

                    Console.WriteLine("Min length = " + min_len);
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

        static bool IsNumeric(string input)
        {
            return input.All(char.IsDigit);
        }

        static void WriteError(string errorMessage)
        {
            Console.WriteLine("Error: " + errorMessage);
            using (StreamWriter errorWriter = new StreamWriter("output.txt"))
            {
                errorWriter.WriteLine("Error: " + errorMessage);
            }
        }
    }
}
