namespace lab3_library
{
    public class Class1
    {
        static TupleTree[]? tree;
        static bool draw = false;

        public static void DoTask()
        {
            try
            {
                GetInputData();
                using (StreamWriter writer = new StreamWriter("OUTPUT.txt"))
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
                WriteError("An unexpected error occurred: " + ex.Message);
            }
        }

        static bool Travel(int head, int begin, int move)
        {
            bool foundWinner = false;
            int leafNum = 0;
            int winnerNum = 0;
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
                    else if (tree[i].Item3 == "+1")
                    {
                        if (move % 2 == 1)
                            foundWinner = true;
                        winnerNum++;
                        leafNum++;
                    }
                    else if (tree[i].Item3 == "0")
                    {
                        draw = true;
                        leafNum++;
                    }
                    else if (tree[i].Item3 == "-1")
                        leafNum++;
                    else
                        throw new IOException($"Unclear data in {i} row.");
                }
            }
            if (leafNum == winnerNum)
                foundWinner = true;
            return foundWinner;
        }

        static void GetInputData()
        {

            using (StreamReader reader = new StreamReader("INPUT.txt"))
            {
                string? n = reader.ReadLine();
                if (n is null)
                {
                    throw new IOException("File is empty.");
                }

                if (!IsNumeric(n))
                {
                    WriteError("Number of nodes must be numeric.");
                    return;
                }

                int nodesNum = int.Parse(n);
                tree = new TupleTree[nodesNum - 1];

                for (int i = 0; i < nodesNum - 1; i++)
                {
                    n = reader.ReadLine();
                    if (n is null)
                    {
                        throw new IOException("Number of nodes is not correct!");
                    }

                    string[] input = n.Split(' ');
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

        static bool IsNumeric(string input)
        {
            return input.All(char.IsDigit);
        }

        static void WriteError(string errorMessage)
        {
            Console.WriteLine("Error: " + errorMessage);
            using (StreamWriter errorWriter = new StreamWriter("OUTPUT.txt"))
            {
                errorWriter.WriteLine("Error: " + errorMessage);
            }
        }
    }
}
