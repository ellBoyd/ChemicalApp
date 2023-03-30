//imports
using System;
using System.Collections.Generic;

namespace ChemicalApp
{
    class Program
    {
        //global variables
        static List<string> allChemicals = new List<string>() { "White vinegar", "Baking soda", "Bleach", "Ethanol", "Hydrogen peroxide", "Lemon", "Detergent", "Eucalyptus oil", "Peppermint oil", "Lavender Oil" };
        static int topChemical = 0;
        static float topEfficiency = -1;
        static int lowChemical = 0;
        static float lowestEfficiency = 17;

      
        //methods and/or functions
        
        static void TestResult(float finalEfficiency, int chemical)
        {
            Console.WriteLine($"\n\n{allChemicals[chemical-1]} has an efficiency rating of {finalEfficiency}.");


            if (finalEfficiency > topEfficiency)
            {
                topEfficiency = finalEfficiency;
                topChemical = chemical;

            }

            if (finalEfficiency < lowestEfficiency)
            {
                lowestEfficiency = finalEfficiency;
                lowChemical = chemical;
            }
        }


        static void OneChemical()
        {
            //User choose chemical and display

            Console.WriteLine("Choose a chemical from the list below by entering its corrosponding number:");
            Console.WriteLine("\n1. White vinegar\n2. Baking soda\n3. Bleach\n4. Ethanol\n5. Hydrogen Peroxide\n6. Lemon\n7. Detergent\n8. Eucalyptus oil\n9. Peppermint oil\n10. Lavender oil\n");

            int chemical = Convert.ToInt32(Console.ReadLine());

            float sumEfficiency = 0;

            //Loop 5 time (below)
            for (int test = 0; test < 5; test++)
            {
                //Randomly generate amount of live germs
                Random rndGerms = new Random();
                int intialGerms = rndGerms.Next(500, 1000);


                //Display amount of live germs
                Console.WriteLine($"\n{intialGerms} live germs are being used to test the chemical.");

                //Randomly generate amount of time taken
                Random rndTime = new Random();
                int time = rndTime.Next(60, 300);

                //After an amount of time the number of live germs is again measured
                Random aftGerm = new Random();
                int afterGerm = aftGerm.Next(0, intialGerms);

                Console.WriteLine($"After {time} secs, {afterGerm} germs remained.");

                //Determine the efficiency rating of the chemical killed the germs

                int sumGerm = (intialGerms - afterGerm) / time;

                sumEfficiency += sumGerm;
                                
            }
            //Calculate efficiency rating

            float finalEffciency = sumEfficiency / 5;

            TestResult(finalEffciency, chemical);
        }



        static void Main(string[] args)
        {
            string flag = "";
            while (!flag.Equals("X"))
            {
                //Loop OneChemical() until user enters "X"

                OneChemical();

                Console.WriteLine("\nPress <ENTER> to add new chemical or enter 'X' to end program");
                flag = Console.ReadLine();
            }

            
            Console.WriteLine($"\nHere are the results!\n");

            //Determine most and least efficient chemicals
            Console.WriteLine($"{allChemicals[topChemical - 1]} has the highest efficiency rating of {topEfficiency}, and {allChemicals[lowChemical - 1]} has the lowest efficiency rating of {lowestEfficiency}!");
        }
    }
}
