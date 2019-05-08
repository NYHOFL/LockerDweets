using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itSupportAI
{
    class aiSupport
    {

        public static string[] Questions = { };
        public static string[] Answers = { };
        public static string[] Type = { };
        public static string[] System = { };

        static string answerText(string input)
        {
            string output;

            output = input;
            return output;
        }
        static string answerNum(string input)
        {
            string output = "";
            bool loop = true;
            int count = 0;
            string[] inputArray = input.Split(' ');
            while (loop == true)
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
            return output;
        }
        static string answerBool(string input)
        {
            string output;

            if (input.ToLower()[1] == 'y')
            {
                output = "yes";
            }
            else
            {
                output = "no";
            }            
            return output;
        }

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
            Console.WriteLine("What Type of Computer do you have? ");

            foreach (int i in menuOptionsNo)
            {
                Console.Write(i.ToString().PadLeft(2));
                Console.WriteLine((menuOptions[i] + i).PadLeft(10));
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
