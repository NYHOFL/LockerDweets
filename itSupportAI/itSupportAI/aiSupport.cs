﻿using System;
using System.Threading;
namespace itSupportAI
{
    class aiSupport
    {

        public static string[,] Questions =
        {
            {"What is your name?", "Any", "String", ""}, 
            {"What is your age?", "Any", "Int", ""},
            {"Can you get to the desktop?", "Any", "Bool", "" },
            {"Is the computer turning on?", "Any", "Bool", ""},
            ///boot issues branch///
            {"Is the monitor turned on? (Lit up on button)", "Any", "Bool", ""}, //4
            {"Is the computer on with the screen brightness very low? (Lit up on button)", "Any", "Bool", ""}, //Thing 1 [5,0]
            {"Is the monitor on the correct input (Try pressing the Source button)", "Any", "Bool", ""},
            /// If the computer will not start///
            {"Are all the cables plugged in correctly?", "Any", "Bool", ""},
            {"Is the switch on the wall set to on? (Switch should be pushed down, or with an orange dot on the switch)", "Any", "Bool", ""}, //Thing 2 [8,0]
            {"Is the switch on the power supply unit set to on? (Check the back of the computer for a switch that should be on)", "Any", "Bool", ""}, //9 
            {"Are you pressing the correct power button? (Make sure the power button is being pressed, not the restart button)", "Any", "Bool", ""},
            /// init issues///
            {"Has the operating system logo shown up? (Apple for Apple, Four squares for Windows, Penguin for Linux)", "Any", "Bool", ""},
            {"Has the user login screen shown up? (Should ask for your username and password)", "Any", "Bool", ""},
            {"Are you entering the password correctly? (Will be saying incorrect password)", "Any", "Bool", ""},
            /// computer boots correctly ///
            /// internet branch ///
            {"Is the issue related to your internet connection?", "Any", "Bool", ""},
            {"Are all cables plugged in correctly? (Lights on modem on, lights on internet port on)", "Any", "Bool", ""}, //15
            {"Is the modem set up correctly? (If not, contact your Internet Service Provider)", "Any", "Bool", ""},
            {"If you are not using cables, ensure that you have selected the correct Wi-Fi network and are inputting the correct password.", "Any", "Bool", ""},
            /// Blue Screens of Death ///
            {"Did you restart the computer", "Any", "Bool", ""},
            {"If you suspect a virus is on your computer, the best course of action is to run any anti virus software you have installed. If this fails to catch the issue, take it to a PC repair shop.", "Any", "Bool", ""},
            /// Apple OS (They're Screwed) ///
            {"Is the device is stuck in a boot loop (constantly restarting)? (if no, move on, if yes try unplugging all devices such as the keyboard and mouse, then restart.)", "Mac", "Bool", ""},
            {"If the computer is crashing, try starting in safe mode. Hold the Left Shift key as the Apple logo shows up. This starts the computer with minimal software loading and checks the hard drive. ", "Mac", "Bool", ""}, //20
            {"Is the spinning beach ball of death locked in animation? This means the device is overloaded.", "Mac", "Bool", ""},
            {"Is the device running slowly? Try the following: Empty trash can. Offload photos to a USB drive. Delete non essential files and programs. Perform a virus check. ", "Mac", "Bool", ""},
            {"If a scary black screen has appeared, restart your computer.", "Mac", "Bool", ""},
            {"If the screen has majorly glitched out, it may be a damaged graphics card. You can also try boot in safe mode and update driver files. If this is not the case, take to a PC shop. ", "Mac", "Bool", ""},
            {"Try using the Apple Hardware Fix tool, hold down the d key while the computer is booting. This is not foolproof but should solve most problems.", "Mac", "Bool", ""}, //25
            //{"", "", "", ""}
        };

        public static string answer, operatingSystem = "Any";

        static string answerNum(string input) //Get the answer if it expected to be a number
        {
            string output = "";
            bool loop = true;
            int count = 0;
            string[] inputArray = input.Split(' ');

            do
            {
                try //Test to see if the current word can be converted to a number, if it can, then exit the loop
                {
                    Convert.ToInt32(inputArray[count]);
                    output = inputArray[count];
                    loop = false;

                }
                catch (IndexOutOfRangeException) //If the code gets through the sentance and finds no numbers, ask the user to enter their age again
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: No age found.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Try entering the number using digits instead of writing out the word.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("What is your age?");
                    inputArray = Console.ReadLine().Split(' ');
                    count = 0;
                }
                catch (System.FormatException) //If the current word that the code is looking at isnt a number, move onto the next word
                {
                    count++;
                }
            } while (loop == true);
            return output;

        } //Number Answer Close

        static string answerBool(string input) //Getting the answer if it is expected to be a yes or a no
        {
            bool loop = true;
            string output="";
            string[] inputArray = input.Split(' ');
            do
            {
                for (int i = 0; i < inputArray.Length; i++)
                {
                    if (inputArray[i].ToLower() == "yes")
                    {
                        output = "yes";
                        loop = false;
                    }
                    else if (inputArray[i].ToLower() == "no")
                    {
                        output = "no";
                        loop = false;
                    }
                    else
                    {
                        loop = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: No answer found");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Try entering a yes or a no");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        inputArray = Console.ReadLine().Split(' ');
                    }
                }
            } while (loop == true);

            return output;
        } //Bool Answer Close

        public static void AnswerType(int i) //Deciding what type the answer is and putting it through the answer type methods
        {
            Console.Clear();
            if (i < 26)
            {
                Console.WriteLine(Questions[i, 0]); 
                answer = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Thank you for using the AI assistant, if issues persist, visit an IT retailer or support organization");
                Console.ReadLine();
                Menu();
            }

            if (Questions[i, 2] == "Int")
            {
                Questions[i, 3] = answerNum(answer);
            }
            else if (Questions[i, 2] == "Bool")
            {
                Questions[i, 3] = answerBool(answer);
            }
            else
            {
                Questions[i, 3] = answer;
            }
            if ((i > 4) && (i != 14))
            {
                Console.WriteLine("Does the problem still persist?");
                string Solved = Console.ReadLine();
                if (Solved.ToLower()[0] == 'n')
                {
                    Console.WriteLine("Since you have marked the system resolved, the program will now return to the menu");
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(".");
                        Thread.Sleep(1000);
                    }
                    Menu();
                }
            }
        }


        public static void Menu()
        {
            Console.Clear();
            string[] menuOptions = { "PC/Windows", "Linux", "Mac" };

            Console.WriteLine("Welcome to the IT Support AI Version 1.0"); //Basic menu system, will change once core concepts are completed
            Console.WriteLine("What operating system are you using");


            for (int i = 0; i < menuOptions.Length; i++) //This is for printing the menu system to the screen, 1 to access windows questions, 2 for linux questions and 3 for mac questions
            {
                Console.Write((i + 1).ToString().PadRight(5));
                Console.WriteLine((menuOptions[i]));
            }
            Console.Write("0".PadRight(5));
            Console.WriteLine("Exit IT Support AI system.");


            bool ChoiceInput = true, testForNum;
            int menuChoice = 0;
            while (ChoiceInput == true)
            {
                testForNum = true;
                while (testForNum == true) //Keep doing this until the user enters a number
                {
                    try
                    {
                        menuChoice = Convert.ToInt32(Console.ReadLine());
                        testForNum = false;
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Please enter a valid option");
                    }
                }

                if (menuChoice <= menuOptions.Length && menuChoice >= 0) //Now checking if the number entered relates to one of the menu options
                {
                    ChoiceInput = false;
                }
                else
                {
                    Console.WriteLine($"Please type a number from 0 to {menuOptions.Length}");
                }
            }



            switch (menuChoice) //Basic menu system to navigate through questionaire
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
                case 0:
                    Environment.Exit(1);
                    break;
                default:
                    break;                    
            }
            Console.Clear();
            QuestionAsking(operatingSystem);
        }

        public static void QuestionAsking(string OS)
        {
            bool loop = true;
            int count = 0;   
            while (loop == true)
            {
                if (Questions[2, 3] == "yes" || Questions[3, 3] == "yes")
                {
                    loop = false;
                }
                else if (count == 20)
                {
                    loop = false;
                }

                
                else
                {
                    AnswerType(count);
                    count++;
                }
            } // Exit the loop if it finds a sub group such as start up issues or program issues


            if (Questions[3, 3] == "yes") //If PC turns on
            {
                for (int j = 15; j < 18; j++)
                {
                    AnswerType(j);

                }
            }
            if (Questions[2, 3] == "yes") // If PC boots to desktop
            {
                    AnswerType(14);

                    if (Questions[14, 3] == "yes")
                    {
                        for (int j = 15; j < 18; j++)
                        {
                            AnswerType(j);
                        }
                }
                    else
                    {
                        for (int j = 18; j < 20; j++)
                        {
                            AnswerType(j);
                        }
                    }
            }




            if (Questions[9, 3] == "yes")
            {
                Console.WriteLine("You entered that your computer was on but the brightness was low, this CONTRADICTS your answer to the previous question, would you like to change it?");
                string restart = Console.ReadLine();
                while (loop == true)
                {
                    if (restart.ToLower() == "yes")
                    {
                        loop = false;
                        count = 6;
                    }
                    else if (restart.ToLower() == "no")
                    {
                        loop = false;
                    }
                    else
                    {
                        loop = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: No answer found");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Try entering a yes or a no");
                        Console.ForegroundColor = ConsoleColor.Gray;

                    }

                }
            }

            if (Questions[14, 3] == "yes") // Read Internet Questions
            {
                for (int j = 20; j < 25; j++)
                {
                    AnswerType(j);
                }
            }
            if (operatingSystem == "Mac") // If the user is on a mac
            {
                for (int j = 20; j < 25; j++)
                {
                    AnswerType(j);
                }
            }
        } 


        static void Main()
        {
            Menu();
            Console.WriteLine("Thanks for utilizing the Virtual IT assistant,\n if you haven't found a solution to your problem,\n consider visiting your local retailer or IT support org");
        }
    }
}