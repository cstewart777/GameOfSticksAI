//Project2Stewart
//Collin Stewart
//March 2021
//AI class

using System;
namespace Project2Stewart
{
    public class AI
    {
        //------Data Members------
        int numHats;
        int currentHats;
        public string[] contents;
        public string[] beside;

        //Constructor for AI class
        public AI()
        {
            //Initialize data members.
            numHats = 0;
            currentHats = 0;
            contents = new string[100];
            beside = new string[100];

            //For loop to initialize contents of contents. 
            for(int i = 3; i < 100; i++)
            {
                contents[i] = "123";
            }

            //For loop to initialize contents of beside. 
            for(int i = 0; i < 100; i++)
            {
                beside[i] = "";
            }

            //Setting the 0, 1, and 2 values of the array. 
            contents[0] = "";
            contents[1] = "1";
            contents[2] = "12";
        }

        //Choose from hat method. 
        public int ChooseFromHat(int hatNum)
        {
            //Create a new random number.
            Random randomNum = new Random();

            //Variable to gather length of contents into hatNum.
            int choose = contents[hatNum].Length;

            //Random number chosen from contents. 
            int index = randomNum.Next(choose);

            //Makes it a char. 
            char newNumber = contents[hatNum][index];

            beside[hatNum] += contents[hatNum][index];

            contents[hatNum].Remove(index, 1);

            return newNumber - '0';
        }

        //Function that adds contents to array depending on
        //if the AI won or not. 
        public void WinLose(bool aiWon)
        {
            //If the AI wins, then it will store that win in memory. 
            if(aiWon == true)
            {
                //Adds the contents of the beside array to contents. 
                for (int i = 0; i < contents.Length; i++)
                {
                    //Doubles the beside value into contents
                    //so that the AI has a better probability
                    //of choosing a better number.
                    contents[i] = contents[i] + beside[i] + beside[i];
                }
            }
            //Else if the AI does not win. 
            else
            {
                //For loop puts the number taken from content
                //back into the beside array. 
                for (int i =0; i < contents.Length; i++)
                {
                    if (contents[i].Contains(beside[i]) == false)
                    {
                        //Adds beside back into contents. 
                        contents[i] = contents[i] + beside[i];
                    }
                }
                
            }
            for (int i = 0; i < contents.Length; i++)
            {
                //Makes the beside array empty again. 
                beside[i] = "";
            }

        }
    }
}
