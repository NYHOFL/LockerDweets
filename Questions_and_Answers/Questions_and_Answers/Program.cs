using System;

namespace Questions_and_Answers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] answers = { "", "" }; 
            string[] userAnswers = new string[10];
            string[] questions = { "", ""};
            
            for(int i = 0; i < answers.Length; i++)
            {
                userAnswers[i] = Console.ReadLine();
                Console.Write(questions[i]);                
            }
            Console.ReadLine();
            
        }
    }
}
