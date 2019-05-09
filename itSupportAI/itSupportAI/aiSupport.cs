using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itSupportAI
{
    class aiSupport
    {

        public static string[,] Questions =
        {
            {"What is your name?", "", "", ""},
            {"What is your age?", "", "", ""},
            {"Is the computer turning on?", "any", "", "" },
            {"Can you get to the desktop?", "", "", ""}
        };

        static string answerNum(string input) //Get the answer if it expected to be a number
        {
            string output = "";
            bool loop = true;
            int count = 0;
            string[] inputArray = input.Split(' '); //Splitting the input into individual words

            while (loop == true) //Go through each word and check if it is a number
            {               
                try
                {
                    Convert.ToInt16(inputArray[count].Trim());
                    output = inputArray[count];
                    loop = false;
                }
                catch (System.FormatException)
                {
                }
                count++;
            }            
            return output; //Return the number
        } //Number Answer Close

        static string answerBool(string input) //Getting the answer if it is expected to be a yes or a no
        {
            string output;

            if (input.ToLower()[1] == 'y') //If there is a y, it's most likely a yes
            {
                output = "yes";
            }
            else //Anything else is probably a no
            {
                output = "no";
            }            
            return output;
        } //Bool Answer Close

        static void Main()
        {           
        
            Console.ReadLine();            

            Menu();
        }



        public static void Menu()
        {
            Console.Clear();
            string[] menuOptions = { "PC/Windows", "Linux", "Mac" };
            Console.WriteLine(Questions[3, 0]);

            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.Write((i + 1).ToString().PadRight(5));
                Console.WriteLine((menuOptions[i]));
            }
            Console.Write("0".PadRight(5));
            Console.WriteLine("Exit IT Support AI system.");

            //This is for printing the menu system to the screen, 1 to access windows questions, 2 for linux questions and 3 for mac questions

            int menuChoice = Convert.ToInt32(Console.ReadLine());
            string operatingSystem = "Any";
            switch (menuChoice)
            {
                case 1:
                    Console.Clear();
                    operatingSystem = "Windows";
                    break;
                case 2:
                    Console.Clear();
                    operatingSystem = "Linux";
                    break;
                case 3:
                    Console.Clear();
                    operatingSystem = "Mac";
                    break;
                default:
                    break;

                
                //Basic menu system to navigate through questionaires

            }
            QuestionAsking(operatingSystem);
        }

        public static void LinuxQuestions()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.Write(Questions[i, 0]);
                Questions[i, 1] = Console.ReadLine();                
            }
            
        }

        public static void PCQuestions()
        {

        }

        public static void QuestionAsking(string OS)
        {

        }

    }
}
