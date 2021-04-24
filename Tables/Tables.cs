using System;
using static System.Console;
using System.Globalization;

/*
 * Name: Dakota Dyche
 * Date: 04/23/2021
*/

class Tables
{

    static void Main()
    {
        int chairs = 0;
        double totalPrice = 0.00;
        string woodType = "";
        string FinalString = "";

        chairs = getAmountChairs(chairs);

        woodType = getWoodType(woodType);

        totalPrice = totalCost(totalPrice, woodType, chairs);

        FinalOutput(FinalString, woodType, chairs, totalPrice);

        ReadKey();
    }

    // Asks user to input a value 2 or more and validates the value.
    // added handler to make a blank value equal 0 and if a letter is entered by mistake value will equal 0
    public static int getAmountChairs(int chairs)
    {
        int validate = 0;
        string chairsAsString;
        string[] invalidArray = {"a","b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                , "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

        Write("Enter number of chairs >> ");
        chairsAsString = ReadLine();

        for(int i = 0; i < invalidArray.Length; i++)
        {
            if (chairsAsString == invalidArray[i])
            {
                chairsAsString = "0";
            }
        }

        if (chairsAsString == "")
        {
            chairs = 0;
        }

        else
        {
            chairs = Convert.ToInt32(chairsAsString);
        }

        if (chairs >= 2)
        {
            validate = 1;
        }

        while (validate == 0)
        {
            WriteLine("You must order at least two chairs.");
            Write("Enter number of chairs >> ");
            chairsAsString = ReadLine();

            for (int i = 0; i < invalidArray.Length; i++)
            {
                if (chairsAsString == invalidArray[i])
                {
                    chairsAsString = "0";
                }
            }

            if (chairsAsString == "")
            {
                chairs = 0;
            }

            else
            {
                chairs = Convert.ToInt32(chairsAsString);
            }

            if(chairs < 2)
            {
                validate = 0;
            }
            else if(chairs >= 2)
            {
                validate = 1;
            }
        }        

        return chairs;
    }

    // Need to fix infinite loop issue when woodType is out of range.
    // fixed issue 4/21/2021 added validation value

    /* gets user input for type of wood the table will use and validates the data with the woodValue array then outputs the woodType value
     *      with the correct name to the Main Method.    
    */
    public static string getWoodType(string woodType)
    {
        string[] woodValue = { "p", "m", "o", "P", "M", "O", "pine", "maple", "oak" };


        Write("Enter type of wood - p, m or o >> ");
        woodType = ReadLine();

        int validate = 0;

        while (validate < 1)
        {

            if (woodType == woodValue[0] || woodType == woodValue[3])
            {
                woodType = woodValue[6];
                validate = 1;
            }

            else if (woodType == woodValue[1] || woodType == woodValue[4])
            {
                woodType = woodValue[7];
                validate = 1;
            }

            else if (woodType == woodValue[2] || woodType == woodValue[5])
            {
                woodType = woodValue[8];
                validate = 1;
            }

            else if(validate == 0)
            {
                WriteLine("You have entered an invalid wood type.");
                Write("Enter type of wood - p, m or o >> ");
                woodType = ReadLine();
                validate = 0;
            }

        }

        return woodType;
    }

    // adds the total cost of the users values to tell them how much their order will be.
    public static double totalCost(double totalPrice, string woodType, int chairs)
    {
        const int perChairCost = 50;
        const int pineWoodCost = 250;
        const int mapleWoodCost = 300;
        const int allOtherWoodCost = 350;

        totalPrice = 0;

        totalPrice += chairs * perChairCost;

        if(woodType == "pine")
        {
            totalPrice += pineWoodCost;
        }

        else if(woodType == "maple")
        {
            totalPrice += mapleWoodCost;
        }

        else
        {
            totalPrice += allOtherWoodCost;
        }

        return totalPrice;
    }

    // returns order values with total to the user.
    public static string FinalOutput(string FinalString, string woodType, int chairs, double totalPrice)
    {
            WriteLine("You have ordered a {0} table with {1} chairs", woodType, chairs);
            WriteLine("");
            WriteLine("Total price is {0}", totalPrice.ToString("C"));


        return FinalString;
    }
}
