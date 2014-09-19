using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace Rita_med_Asterisker__nivå_C
{
    class Program
    {
        private static ResourceManager RM = DrawWithAstericks_Strings.ResourceManager;
        //Maximum of the diamond is 79 
        private const byte MaxOfAsterisker = 79;
        static void Main(string[] args)
        {
            byte numOfOddasterisks;
            do
            {
                Console.Title = "Rita med asterisker- nivå C";
                numOfOddasterisks = ReadOddByte(String.Format(RM.GetString("Enter_Asterisker"), MaxOfAsterisker), MaxOfAsterisker);
                RenderDiamond(numOfOddasterisks);

            } while (IsContinuing());
    
        }

        //Presntera ett meddelande som uppmanar användaren att trycka på en tangent för att fortsätta!
        private static bool IsContinuing()
        {
            ShowMessage(RM.GetString("Continue_Prompt"));
            return Console.ReadKey(true).Key != ConsoleKey.Escape;
        }

        //Metodn ska säkerställa att inget felaktigt kan matas in d.v.s metoden ska kontroller att det inmatade talet är udda och ligger
        //i det slutna intervallet från 1 till det värde parametern maxValue har samt ta hand om eventuella undantag som kastas
        private static byte ReadOddByte(string prompt = null, byte maxValue = 255)
        {
            byte oddValue;
            //bool valid;
            do
            {
                //valid = false;
                Console.Write(prompt);
                try
                {
                    oddValue = Byte.Parse(Console.ReadLine());
                    if (oddValue > maxValue || oddValue % 2 == 0)
                    {
                        ShowMessage(String.Format(RM.GetString("Error_Message"), MaxOfAsterisker), error: true);

                    }
                    else
                    {
                        Console.WriteLine("The condition is false (result is true).");
                        break;
                    }
                }
                catch (FormatException)
                {
                    ShowMessage(String.Format(RM.GetString("Error_Message"), MaxOfAsterisker), error: true);
                }
                catch (StackOverflowException)
                {
                    ShowMessage(String.Format(RM.GetString("Error_Message"), MaxOfAsterisker), error: true);
                }

            } while (true);

            return oddValue;
        }
        //Metoden har parametern maxCount som ger antalet asterisker diamantens midja ska innehålla. 
        private static void RenderDiamond(byte maxCount)
        {
            for(byte i = 1; i <= maxCount; i ++)
            {
                RenderRow(maxCount, i);
            }
            for (int j = maxCount - 1; j >= 1; j --)
            {
                RenderRow(maxCount, j);
            } 
            
        }
        //Metoden ska rendera en rad med mellanslag och asterisker
        private static void RenderRow(int maxCount, int asteriskCount)
        {
            int j = (maxCount - asteriskCount) ;
            for(int row= 0; row < j; row++)
            {
                Console.Write(" ");
            }
            for (int row = 0; row < asteriskCount; row++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
        private static void ShowMessage(string message, bool error = false)
        {
            Console.WriteLine();
            if(error)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
