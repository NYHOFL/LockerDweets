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
            {"What is your name?", "Any", "String", ""},
            {"What is your age?", "Any", "Int", ""},
            {"Is the computer turning on?", "Any", "Bool", "" },
            {"Can you get to the desktop?", "Any", "Bool", ""},
            {"What type of OS are you troubleshooting?", "Any", "", ""},
            ///boot issues branch///
            {"Is the monitor turned on? (Lit up on button)", "Any", "Bool", ""},
            {"Is the computer on with the screen brightness very low? (Lit up on button)", "Any", "Bool", ""},
            {"Is the monitor on the correct input (Try pressing the Source button)", "Any", "Bool", ""},
            /// If the computer will not start///
            {"Are all the cables plugged in correctly?", "Any", "Bool", ""},
            {"Is the switch on the wall set to on? (Switch should be pushed down, or with an orange dot on the switch)", "Any", "Bool", ""},
            {"Is the switch on the power supply unit set to on? (Check the back of the computer for a switch that should be on)", "Any", "Bool", ""},
            {"Are you pressing the correct power button? (Make sure the power button is being pressed, not the restart button)", "Any", "Bool", ""},
            /// init issues///
            {"Has the operating system logo shown up? (Apple for Apple, Four squares for Windows, Penguin for Linux)", "Any", "Bool", ""},
            {"Has the user login screen shown up? (Should ask for your user password)", "Any", "Bool", ""},
            {"Are you entering the password correctly? (Will be saying incorrect password)", "Any", "Bool", ""},
            /// computer boots correctly ///
            /// internet branch ///
            {"Are all cables plugged in correctly? (Lights on modem on, lights on internet port on)", "Any", "Bool", ""},
            {"Is the modem set up correctly? (If not, contact your Internet Service Provider)", "Any", "Bool", ""},
            {"If you are not using cables, ensure that you have selected the correct Wi-Fi network and are inputting the correct password.", "Any", "Bool", ""},
            /// Blue Screens of death ///
            {"Restart the computer", "Any", "Bool", ""},
            {"If you suspect a virus is on your computer, the best course of action is to run any anti virus software you have installed. If this fails to catch the issue, take it to a PC repair shop.", "Any", "Bool", ""},
            /// Apple OS (They're Screwed) ///
            {"Is the device is stuck in a boot loop (constantly restarting)? (if no, move on, if yes try unplugging all devices such as the keyboard and mouse, then restart.)", "Mac", "Bool", ""},
            {"If the computer is crashing, try starting in safe mode. Hold the Left Shift key as the Apple logo shows up. This starts the computer with minimal software loading and checks the hard drive. ", "Mac", "Bool", ""},
            {"Is the spinning beach ball of death locked in animation? This means the device is overloaded.", "Mac", "Bool", ""},
            {"Is the device running slowly? Try the following: Empty trash can. Offload photos to a USB drive. Delete non essential files and programs. Perform a virus check. ", "Mac", "Bool", ""},
            {"If a scary black screen has appeared, restart your computer.", "Mac", "Bool", ""},
            {"If the screen has majorly glitched out, it may be a damaged graphics card. You can also try boot in safe mode and update driver files. If this is not the case, take to a PC shop. ", "Mac", "Bool", ""},
            {"Try using the Apple Hardware Fix tool, hold down the d key while the computer is booting. This is not foolproof but should solve most problems.", "Mac", "Bool", ""},
            {"", "", "", ""}
        };

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
                    Convert.ToInt16(inputArray[count]);
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
            string output;

            if (input.ToLower()[1] == 'y') //If thre is a y, it's most likely a yes
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
            Menu();
        }



        public static void Menu()
        {
            Console.Clear();
            string[] menuOptions = { "PC/Windows", "Linux", "Mac" };

            Console.WriteLine("Welcome to the IT Support AI Version 1.0");//Basic menu system, will change once core concepts are completed
            Console.WriteLine("What operating system are you using");
            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.Write((i + 1).ToString().PadRight(5));
                Console.WriteLine((menuOptions[i]));
            }
            Console.Write("0".PadRight(5));
            Console.WriteLine("Exit IT Support AI system.");

            //This is for printing the menu system to the screen, 1 to access windows questions, 2 for linux questions and 3 for mac questions

            bool choiceLoop = true; 
            int menuChoice = 0;
            while (choiceLoop == true)
            {
                try
                {
                    menuChoice = Convert.ToInt32(Console.ReadLine());
                    if (menuChoice == 0)
                    {
                        Environment.Exit(0);
                    }

                    if (menuChoice > 4 || menuChoice < 0) // Making sure the number entered is valid
                    {
                        Console.WriteLine("Please enter the number relating to the operating system you are using");
                    }
                    else
                    {
                        choiceLoop = false;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter the number relating to the operating system you are using");
                }
                

            }
            //If numbers are not entered it will continue to loop. Basic error checking

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

                
                //Basic menu system to navigate through questionaire

            }
            Console.Clear();
            QuestionAsking(operatingSystem);
        }

        public static string answer;

        public static void QuestionAsking(string OS)
        {


            for (int i = 0; i < Questions.Length/4; i++)
            {
                if ((Questions[i, 1] == OS)|| (Questions[i, 1] == "Any")) //Determaining the OS
                {

                    Console.Clear();
                    Console.WriteLine(Questions[i, 0]); 
                    answer = Console.ReadLine(); 

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
                    //Will put the answer into the 2D array depending on the type (int, bool, or string)
                }
            }
        }
    }
}
