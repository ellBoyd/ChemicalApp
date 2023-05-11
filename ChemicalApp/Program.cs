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
                    Console.WriteLine("Choose a chemical from the list below by entering its corrosponding number:");
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
                Console.Write($"\nPress {Console.ForegroundColor = ConsoleColor.Yellow}<ENTER> {Console.ResetColor()} to add another chemical or type 'X'to quit\n");
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
            string flag = "";
            while (!flag.Equals("X"))
            {
                //Loop OneChemical() until user enters "X"

                OneChemical();

                flag = CheckFlag();

                Console.Clear();
            }

            Console.WriteLine($"\nHere are the results!\n");

            Console.WriteLine(TestedChemicals());

            //Determine most and least efficient chemicals
            Console.WriteLine($"{allChemicals[topChemical -1]} has the highest efficiency rating of {topEfficiency}, " +
                $"and {allChemicals[lowChemical -1]} has the lowest efficiency rating of {lowestEfficiency}!");
        }
    }
}
