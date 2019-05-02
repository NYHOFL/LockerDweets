using System;

namespace Questions_and_Answers
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] answers = new string[10];
            string[] questions = { "", ""};
            
            for(int i = 0; i < answers.Length; i++)
            {
                Console.Write(questions[i]);
                answers[i] = Console.ReadLine();
            }
            Console.ReadLine();
            
        }
    }
}
