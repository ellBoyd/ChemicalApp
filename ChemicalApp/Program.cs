//imports
using System;

namespace ChemicalApp
{
    class Program
    {
        //global variables
        
        //methods and/or functions


        static void OneChemical()
        {
            

            //User choose chemical and display

            Console.WriteLine("Choose a chemical from the list below by entering its corrosponding number:");
            Console.WriteLine("\n1. White vinegar\n2. Baking soda\n3. Bleach\n4. Ethanol\n5. Hydrogen Peroxide\n6. Lemon\n7. Detergent\n8. Eucalyptus oil\n9. Lavender oil\n10. Peppermint oil\n");


            int chemical = Convert.ToInt32(Console.ReadLine());

            //Loop 5 time (below)
            for (int test = 0; test < 5; test++)
            {
                //Randomly generate amount of live germs
                Random rndGerms = new Random();
                int intialGerms = rndGerms.Next(500, 1000);



                //Display amount of live germs
                Console.WriteLine($"\n{intialGerms} live germs are being used to test the chemical");



                //Randomly generate amount of time taken
                Random rndTime = new Random();
                int time = rndTime.Next(600, 900);
                

                //After an amount of time the number of live germs is again measured
                Random aftGerm = new Random();
                int afterGerm = aftGerm.Next(0, intialGerms);

                Console.WriteLine($"After {time} secs, {afterGerm} germs remained");

                //Determine the efficiency rating of the chemical killed the germs
                


                //Calculate efficiency rating
                


            }




        }



        static void Main(string[] args)
        {
            string flag = "";
            while (!flag.Equals("X"))
            {
                //Loop OneChemical() until user enters "X"

                OneChemical();

                Console.WriteLine("Press enter to add new chemical or enter 'X' to end program");
                flag = Console.ReadLine();
            }


            //Determine most and least efficient chemicals


        }
    }
}
