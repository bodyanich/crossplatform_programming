using System;
using System.IO;

namespace lab123
{
    static public class lab3
    {
        static TupleTree[] tree;
        static bool draw = false;
        static public void DoTask(string input, string output)
        {
            try
            {
                GetInputData(input);
                using (StreamWriter writer = new StreamWriter(output))
                {
                    if (Travel(1, 0, 1))
                    {
                        writer.WriteLine("+1");
                        Console.WriteLine("+1");
                    }
                    else if (draw)
                    {
                        writer.WriteLine("0");
                        Console.WriteLine("0");
                    }
                    else
                    {
                        writer.WriteLine("-1");
                        Console.WriteLine("-1");
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

        static bool Travel(int head, int begin, int move)
        {
            bool foundWinner = false;
            for (int i = begin; i < tree.Length; i++)
            {
                if (foundWinner)
                    return true;
                if (tree[i].Item2 == head)
                {
                    if (tree[i].Item1 == "N" && Travel(i + 2, begin + 1, move + 1))
                    {
                        foundWinner = true;
                    }
                    else if (tree[i].Item3 == "+1" && move % 2 == 1)
                    {
                        foundWinner = true;
                    }
                    else if (tree[i].Item3 == "0")
                    {
                        draw = true;
                    }
                }
            }
            return foundWinner;
        }

        static void GetInputData(string input_)
        {

            using (StreamReader reader = new StreamReader(input_))
            {
                string? n = reader.ReadLine();
                if (n is null)
                {
                    throw new IOException("File is empty.");
                }

                tree = new TupleTree[int.Parse(n) - 1];

                for (int i = 0; i < int.Parse(n) - 1; i++)
                {
                    string[] input = reader.ReadLine().Split(' ');
                    if (input[0] == "N")
                    {
                        tree[i] = new TupleTree(input[0], int.Parse(input[1]));
                    }
                    else if (input[0] == "L")
                    {
                        tree[i] = new TupleTree(input[0], int.Parse(input[1]), input[2]);
                    }
                    else { throw new IOException("Unclear data in file."); }
                }
            }
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

