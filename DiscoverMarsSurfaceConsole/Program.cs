using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoverMarsSurface.App
{
    /// <summary>
    /// Entry point for console run
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            // print greeting
            var sb = new StringBuilder();
            sb.AppendLine("Welcome to Mars Discovery team Main Machine cockpit!");
            sb.AppendLine("You have given a crucial mission to discover some platues on Mars surface");
            sb.AppendLine("--------------- instructions ---------------------------------------------------------------------------------");
            sb.AppendLine(" - The first line of input is the upper-right coordinates of the plateau, e.g: 5 5");
            sb.AppendLine(" - The rest of the input is information for rovers (one line for firs position, and another line for movement)");
            sb.AppendLine(" - Type EXIT to exit mission");
            sb.AppendLine(" - Type RESULT to get results");
            sb.AppendLine("---------------------------- ----------------------------------------------------------------------------------");
            Console.WriteLine(sb.ToString());

            var conterolCenter = new MissionCenter();

            Console.WriteLine("Now, type coordinates of the plateau and press Enter");
            string inputLine = Console.ReadLine();

            while (!IsExit(inputLine))
            {
                if (inputLine?.Trim()?.Split(' ').Length == 2)
                {
                    conterolCenter.CreatePlatue(inputLine);
                    break;
                }
                else
                {
                    Console.WriteLine($"Invalid coordinates: {inputLine}. Plase type coordinates x y and press Enter");
                    inputLine = Console.ReadLine();
                }
            }

            
            do
            {
                Console.WriteLine("Type coordinates for the next rover in x y D format and press Enter or type Result to print results");
                inputLine = Console.ReadLine();
                if (inputLine?.ToUpper() == "RESULT")
                {
                    Console.WriteLine("======= Last Locations of Rovers =======");
                    Console.WriteLine(conterolCenter.GetLastLocatsionsOfRovers());
                    continue;
                }

                if (inputLine?.Trim()?.Split(' ').Length == 3)
                {
                    string coordinates = inputLine;
                    Console.WriteLine("Type instructions for the new rover in any MLRRLMM format and press Enter");
                    inputLine = Console.ReadLine();
                    string instructions = inputLine;

                    Console.WriteLine("Reover deployed successfully");
                    conterolCenter.DeployRover(coordinates, instructions);

                }
                else
                    Console.WriteLine($"Invalid coordinates: {inputLine}");

            } while (!IsExit(inputLine));
        }

        static bool IsExit(string text)
        {
            return text?.ToUpper() == "EXIT";
        }
    }
}
