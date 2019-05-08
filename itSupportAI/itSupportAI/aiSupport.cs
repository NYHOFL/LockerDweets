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
            string output;
            bool loop = true;
            int count = 0;
            string[] inputArray = input.Split(' ');
            while (loop == true)
            {
                Console.WriteLine(count);
                try
                {
                    Convert.ToInt16(inputArray[0].Trim());
                    loop = false;
                }
                catch (System.FormatException)
                {
                    count++;
                }                
            }



            output = input;
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
            string x;
            Console.WriteLine("How old are you");
            x = answerNum(Console.ReadLine());
            Console.WriteLine($"I got {x}");
            Console.ReadLine();
        }


    }
}
