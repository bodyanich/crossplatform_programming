using McMaster.Extensions.CommandLineUtils;
using System;
using lab123;
using System.IO;

namespace lab4
{
    internal class Program
    {
        static CommandLineApplication app = new CommandLineApplication
        {
            Name = "lab4"
        };

        static int Main(string[] args)
        {

            app.HelpOption("-?|-h|--help");
            VersionCommand();
            RunCommand();
            SetPathCommand();

            app.OnExecute(() =>
            {
                app.ShowHelp();
                return 1;
            });

            try
            {
                return app.Execute(args);
            }
            catch (CommandParsingException ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }

        static public void VersionCommand()
        {
            app.Command("version", command =>
            {
                command.Description = "Displays author and version of the program.";
                command.HelpOption("-?|-h|--help");

                command.OnExecute(() =>
                {
                    Console.WriteLine("Author: Borodiy Bogdan IPZ-42/1.");
                    Console.WriteLine("Version: 1.0.3");
                    return 1;
                });
            });
        }

        static public void RunCommand()
        {
            app.Command("run", runCmd =>
            {
                runCmd.Description = "Runs the specified lab.";
                runCmd.HelpOption("-?|-h|--help");

                var labArgument = runCmd.Argument("Lab_name", "Lab name you want to run (lab1, lab2 or lab3).");
                var sourceOption = runCmd.Option("-i|--input",
                    "Input file", CommandOptionType.SingleOrNoValue);
                var destinationOption = runCmd.Option("-o|--output",
                    "Output file", CommandOptionType.SingleOrNoValue);

                runCmd.OnExecute(() =>
                {
                    string source = GetInputPath(sourceOption.Value());
                    string destination = GetOutputPath(destinationOption.Value());
                    if (string.IsNullOrEmpty(source))
                        return 0;
                    else
                        RunLab(labArgument.Value, source, destination);
                    return 1;
                });
            });
        }

        static public string GetInputPath(string? path)
        {
            if(!string.IsNullOrEmpty(path) && File.Exists(path))
                return path;
            else
            {
                string? labPath = Environment.GetEnvironmentVariable("LAB_PATH");
                Console.WriteLine(labPath);
                if (!string.IsNullOrEmpty(labPath) && File.Exists(Path.Combine(labPath, "input.txt")))
                    return Path.Combine(labPath, "input.txt");
                else
                {
                    string homePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "input.txt");
                    if (File.Exists(homePath))
                        return homePath;
                }
            }
            Console.Error.WriteLine("Error: Cannot find the input file.");
            return "";
        }

        static public string GetOutputPath(string? path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
                return path;
            else
            {
                string? labPath = Environment.GetEnvironmentVariable("LAB_PATH");
                if (!string.IsNullOrEmpty(labPath))
                    return Path.Combine(labPath, "output.txt");
                else
                {
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "output.txt");
                }
            }
        }

        static public void RunLab(string? labName, string input, string output)
        {
            switch (labName)
            {
                case "lab1":
                    Lab1.DoTask(input, output);
                    break;
                case "lab2":
                    lab2.DoTask(input, output);
                    break;
                case "lab3":
                    lab3.DoTask(input, output);
                    break;
                default:
                    Console.Error.WriteLine($"Error: Unknown lab {labName}.");
                    break;
            }
        }

        static public void SetPathCommand()
        {
            app.Command("set-path", command =>
            {
                command.Description = "Sets the path to the folder where input and output files are located.";
                command.HelpOption("-?|-h|--help");

                var pathOption = command.Option("-p|--path",
                    "The path to the folder with files.", CommandOptionType.SingleValue);

                command.OnExecute(() =>
                {
                    string? path = pathOption.Value();
                    if (path != null)
                    {
                        //PlatformID platform = Environment.OSVersion.Platform;
                        //if (platform == PlatformID.Unix)
                        //{
                        //    Environment.SetEnvironmentVariable("LAB_PATH", path, EnvironmentVariableTarget.Process);
                        //}
                        //else if (platform == PlatformID.Win32NT || platform == PlatformID.Win32S || platform == PlatformID.Win32Windows || platform == PlatformID.WinCE)
                        //{
                        //    Environment.SetEnvironmentVariable("LAB_PATH", path, EnvironmentVariableTarget.User);
                        //}
                        //else
                        //{
                        //    Console.Error.WriteLine("Error: Unknown OS.");
                        //}
                        Environment.SetEnvironmentVariable("LAB_PATH", path);
                    }
                    else
                    {
                        Console.Error.WriteLine("Error: no value is provided for -p (--path) command.");
                        return 0;
                    }
                    return 1;
                });
            });
        }
    }
}