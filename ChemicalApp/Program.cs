//imports
using System;
using System.Collections.Generic;

namespace ChemicalApp
{
    class Program
    {
        //global variables
        static List<string> allChemicals = new List<string>() { "White Vinegar", "Baking Soda", "Bleach", "Ethanol", "Hydrogen peroxide", "Lemon", "Detergent", 
            "Eucalyptus Oil", "Peppermint Oil", "Lavender Oil" };
        static List<int> testedChemicals = new List<int>();
        static List<float> efficienciesList = new List<float>();
        static int topChemical = 0;
        static float topEfficiency = -1;
        static int lowChemical = 0;
        static float lowestEfficiency = 17;


        //methods and/or functions

        static void SortEfficiency()
        {
            //Creates outer pointer to point to first efficiency value
            
            for (int outerPointer = 0; outerPointer < efficienciesList.Count; outerPointer++)
            {
                //Creates inner pointer to point to second efficiency value
                for (int innerPointer = outerPointer+1; innerPointer < efficienciesList.Count; innerPointer++)
                {
                    //Compare first efficiency < second efficiency
                    if (efficienciesList[outerPointer] < efficienciesList[innerPointer])
                    {
                        //Swap list values
                        float tempEfficiency = efficienciesList[outerPointer];
                        efficienciesList[outerPointer] = efficienciesList[innerPointer];
                        efficienciesList[innerPointer] = tempEfficiency;


                        int tempChemical = testedChemicals[outerPointer];
                        testedChemicals[outerPointer] = testedChemicals[innerPointer];
                        testedChemicals[innerPointer] = tempChemical;

                    }
                }
            }
        }

        static string TestedChemicals()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string testedChemicalsOutput = "Efficiency of each chemical:\n";
            
            for (int chemicalIndex = 0; chemicalIndex < efficienciesList.Count; chemicalIndex++)
            {
                testedChemicalsOutput += $"{chemicalIndex + 1}. {allChemicals[testedChemicals[chemicalIndex]]} {efficienciesList[chemicalIndex]}\n";
            }

            return testedChemicalsOutput;
        }

        static int CheckChemical()
        {
            while (true)
            {
                try
                {
                    //get user to enter a chemical
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Choose a chemical from the list below by entering its corrosponding number:");
                    Console.ResetColor();
                    Console.WriteLine("\n1. White Vinegar\n2. Baking Soda\n3. Bleach\n4. Ethanol" +
                        "\n5. Hydrogen Peroxide\n6. Lemon\n7. Detergent\n8. Eucalyptus oil\n9. Peppermint oil\n10. Lavender oil\n");

                    

                    //check if user has entered same chemical more than once
                    int chosenChemical = Convert.ToInt32(Console.ReadLine());
                    if (testedChemicals.Contains(chosenChemical))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Chemical has already been tested");
                        Console.ResetColor();
                    }

                    //check if user has entered a number within the range of choices, and hasn't entered a string
                    else if (chosenChemical >= 1 && chosenChemical <= 10)
                    {
                        return chosenChemical;
                    }
                    
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: You can only enter a number from 1-10");
                        Console.ResetColor();
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: You can only enter a number from 1-10");
                    Console.ResetColor();
                }
            }
        }

        static string CheckFlag()
        {
            while (true)
            {
                //get user's choice
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"\nPress <ENTER> to add another chemical or type 'X'to quit\n");
                Console.ResetColor();
                string userInput = Console.ReadLine();

                //Convert user input to uppercase
                userInput = userInput.ToUpper();

                if (userInput.Equals("X") || userInput.Equals(""))
                {
                    return userInput;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Please enter a correct choice.");
                Console.ResetColor();
            }
        }

        //method to test least and most efficient chemical
        static void TestResult(float finalEfficiency, int chemicalName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nResults are in!");
            Console.ResetColor();

            Console.WriteLine($"{allChemicals[chemicalName - 1]} has an efficiency rating of {finalEfficiency}.");
            
            if (finalEfficiency > topEfficiency)
            {
                topEfficiency = finalEfficiency;
                topChemical = chemicalName;

            }

            else if (finalEfficiency < lowestEfficiency)
            {
                lowestEfficiency = finalEfficiency;
                lowChemical = chemicalName;
            }
        }

        //Component 1
        static void OneChemical()
        {
            testedChemicals.Add(CheckChemical());

            float sumEfficiency = 0;

            Console.Clear();
            Console.WriteLine($"----- Test Results ------");

           
            //Loop 5 time (below)
            for (int test = 0; test < 5; test++)
            {
                //Randomly generate amount of live germs
                Random rndGerms = new Random();
                int intialGerms = rndGerms.Next(500, 1000);


                //Display amount of live germs
                Console.WriteLine($"\n\n{intialGerms} live germs are have been added.");

                //Randomly generate amount of time taken
                Random rndTime = new Random();
                int time = rndTime.Next(60, 300);

                //After an amount of time the number of live germs is again measured
                Random aftGerm = new Random();
                int afterGerm = aftGerm.Next(0, intialGerms);

                
                Console.WriteLine($"- After {time} secs, {afterGerm} live germs remained.");

                //Determine the efficiency rating of the chemical killed the germs

                int sumGerm = (intialGerms - afterGerm) / time;

                sumEfficiency += sumGerm;
                                
            }
            //Calculate efficiency rating

            efficienciesList.Add( sumEfficiency / 5);

            TestResult(efficienciesList[efficienciesList.Count-1], testedChemicals[testedChemicals.Count-1]);
        }


        //Component 2
        static void Main(string[] args)
        {
            Console.WriteLine(
        @"  ______     __  __     ______     __    __     __     ______     ______     __            ______     ______   ______" + "\n" +
        @" /\  ___\   /\ \_\ \   /\  ___\   /\ \._/  \   /\ \   /\  ___\   /\  __ \   /\ \          /\  __ \   /\  == \ /\  == \" + "\n" +
        @" \ \ \____  \ \  __ \  \ \  __\   \ \ \._/\ \  \ \ \  \ \ \____  \ \  __ \  \ \ \____     \ \  __ \  \ \  _-/ \ \  _-/" + "\n" +
        @"  \ \_____\  \ \_\ \_\  \ \_____\  \ \_\ \ \_\  \ \_\  \ \_____\  \ \_\ \_\  \ \_____\     \ \_\ \_\  \ \_\    \ \_\" + "\n" +
        @"   \/_____/   \/_/\/_/   \/_____/   \/_/  \/_/   \/_/   \/_____/   \/_/\/_/   \/_____/      \/_/\/_/   \/_/     \/_/" + "\n");
                 
            Console.WriteLine("INTRODUCTION\n\n" +
                "Welcome to the lab!\n" +
                "Cleaning chemical company Hi-Jean International, is looking into developing new,\n" +
                "revolutionary products for households internationally. As part of their research\n" +
                "division, you have been set the task to determine the least and most efficient\n" +
                "chemicals to be used in our products. This Chemical App program allows you to test\n" +
                "these chemicals.\n\n" +
                "Let's run down how this program works...");

            Console.WriteLine("Press <ENTER> to continue");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("" +
                             
                "----- How the program functions -----\n\n" +
                "By entering chemicals from the list, for example, 'Lemon', the program will add a\n" +
                "solution of 'Lemon' to an amount of live germs. A timer begins and will stop\n" +
                "after a randomly generated period of time. The remaining live germs will be counted,\n" +
                "and subtracted from the total live germs from the beginning of testing, divided by the time, to determine the trial's efficiency. This proccess\n" +
                "is repeated five times, and the results are then added together and divided by five,\n" +
                "to determine the efficieny of that chemical. You can continue to test more chemicals,\n" +
                "and at the end of testing, the progam will calculate and display the least and most\n" +
                "efficent chemicals.");
            Console.WriteLine("Press <ENTER> to begin testing!");
            Console.ReadLine();
            Console.Clear();


            string flag = "";
            while (!flag.Equals("X"))
            {
                //Loop OneChemical() until user enters "X"

                OneChemical();

                flag = CheckFlag();

                Console.Clear();
            }
            
            Console.WriteLine("----- Final Results -----");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nHere are the results!\n");
            Console.ResetColor();

            Console.WriteLine(TestedChemicals());

            //Determine most and least efficient chemicals
            Console.WriteLine($"{allChemicals[topChemical -1]} has the highest efficiency rating of {topEfficiency}, " +
                $"and {allChemicals[lowChemical -1]} has the lowest efficiency rating of {lowestEfficiency}!");
        }
    }
}
