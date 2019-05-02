using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] answers = { "", "" };
            string[] userAnswers = new string[10];
            string[] questions = { "test", "" };

            for (int i = 0; i < answers.Length; i++)
            {
                userAnswers[i] = Console.ReadLine();
                Console.Write(questions[i]);
            }
            Console.ReadLine();
        }
    }
}
