using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itSupportAI
{
    class aiSupport
    {

        public static string[] Questions = { "What is your name?", "What is your age?", "What type of OS are you troubleshooting?", "Is the computer turning on? (Fans are spinning)", "If yes, can you get to the desktop? (See all of your icons)" };
        public static string[] Answers = { };
        public static string[] Type = { };
        public static string[] System = { };

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
            int[] menuOptionsNo = { 1, 2, 3};
            string[] menuOptions = { "PC/Windows", "Linux", "Mac" };
            Console.WriteLine(Questions[3]);

            foreach (int i in menuOptionsNo)
            {
                Console.Write(i.ToString().PadLeft(2));
                Console.WriteLine((menuOptions[i]).PadLeft(10));
            }
            Console.Write("0".PadLeft(2));
            Console.WriteLine("Exit IT Support AI system.");

            int menuChoice = Convert.ToInt32(Console.ReadLine());
            switch (menuChoice)
            {
                case 1:
                    Console.Clear();
                    MacQuestions();
                    break;
                case 2:
                    Console.Clear();
                    PCQuestions();
                    break;
                case 3:
                    Console.Clear();
                    LinuxQuestions();
                    break;
                default:
                    break;

                
                //Basic menu system to navigate through questionaires

            }
        }

        public static void LinuxQuestions()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.Write(Questions[i]);
                Answers[i] = Console.ReadLine();

            }
        }

        public static void PCQuestions()
        {

        }

        public static void MacQuestions()
        {

        }

    }
}
