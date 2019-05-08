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

        static string answerText(string input)
        {
            string output;

            output = input;
            return output;
        }
        static string answerNum(string input)
        {
            string output;

            output = input;
            return output;
        }
        static string answerBool(string input)
        {
            string output;

            if (input.ToLower()[1] == 'y')
            {

            }
            
            return output;
        }

        static void Main()
        {           

            Console.ReadLine();
        }


    }
}
