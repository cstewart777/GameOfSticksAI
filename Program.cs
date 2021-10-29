//Project2Stewart
//Collin Stewart
//March 2021
//Game of sticks! PvP PvAI PvSuperAI

using System;

namespace Project2Stewart
{
    class Program
    {
        static void Main(string[] args)
        {
            //Welcoming statement.
            Console.WriteLine("Welcome to the game of sticks!");

            //Prompt user for the number of sticks.
            Console.WriteLine("How many sticks are there on the table initially (10-100)?");

            //Read user input and check to see if number or not. 
            int numSticks = int.Parse(Console.ReadLine());

            //Create an instance of game class. 
            Game myGame = new Game();

            //Created instance of an AI class. 
            AI myAI = new AI();
            AI newAI = new AI();

            //Sets sticks 
            myGame.setSticks(numSticks);
            Console.WriteLine(myGame.Status());

            //Message to prompt user to choose who they want to play.
            Console.WriteLine("Options:");
            Console.WriteLine("Play against a friend(1)");
            Console.WriteLine("Play against the computer(2)");
            Console.WriteLine("Play against a trained AI(3)");
            Console.WriteLine("Which option do you take(1-3)");

            //Variable to read users input for playing option. 
            int playerOption = int.Parse(Console.ReadLine());

            if (playerOption == 1)
            {
                //Prompt user to enter in player names.
                Console.WriteLine("Enter name for player 1: ");
                string userOne = Console.ReadLine();
                Console.WriteLine("Enter name for player 2: ");
                string userTwo = Console.ReadLine();

                //Write out welcoming statement to users. 
                Console.WriteLine("Welcome " + userOne + "(P1) and " + userTwo + "(P2)!");

                //Beginning statement.
                Console.WriteLine("Let's begin!");

                //Boolean for player turn. 
                bool playerOneTurn = true;

                //Begin the game.
                while (true)
                {
                    //Prints out to console how many sticks are currently on the board. 
                    Console.WriteLine(myGame.Status());

                    //If statement to determine which players turn it is. 
                    if (playerOneTurn == true)
                    {
                        Console.WriteLine(userOne + "(P1): How many sticks do you take (1-3)?");
                    }
                    else
                    {
                        Console.WriteLine(userTwo + "(P2): How many sticks do you take (1-3)?");
                    }

                    //Variable to read sticks. 
                    int theSticks = int.Parse(Console.ReadLine());

                    //If sticks are between 1 and 3.
                    if ((theSticks >= 1) && (theSticks <= 3))
                    {
                        //Removes sticks from count. 
                        myGame.RemoveSticks(theSticks);
                    }
                    //If the number entered is not between 1 and 3. 
                    else
                    {
                        Console.WriteLine("Please enter a number between 1 and 3.");
                    }

                    //If statement to switch players turns. 
                    if (playerOneTurn == true)
                    {
                        playerOneTurn = false;
                    }
                    else
                    {
                        playerOneTurn = true;
                    }

                    //When stick count is 0 and game is over.
                    if (myGame.getSticks() <= 0)
                    {
                        Console.WriteLine("There are no sticks remaining on the board.");
                        if (playerOneTurn == true)
                        {
                            Console.WriteLine(userOne + " Wins!");

                            //Asks user if they would like to play again. 
                            Console.WriteLine("Would you like to play again (y or n)?");
                            string playMore = Console.ReadLine();

                            //When user enters a y to play again and resets game. 
                            if (playMore == "y")
                            {
                                Console.WriteLine("Restarting game...");
                                myGame.setSticks(numSticks);
                                Console.WriteLine(myGame.Status());
                                playerOneTurn = true;
                            }

                            //If user enters anything but a y it will end game. 
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine(userOne + " lost.");
                            //Asks user if they would like to play again. 
                            Console.WriteLine("Would you like to play again (y or n)?");
                            string playMore = Console.ReadLine();

                            //When user enters a y to play again and resets game. 
                            if (playMore == "y")
                            {
                                Console.WriteLine("Restarting game...");
                                myGame.setSticks(numSticks);
                                Console.WriteLine(myGame.Status());
                                playerOneTurn = true;
                            }

                            //If user enters anything but a y it will end game. 
                            else
                            {
                                break;
                            }
                        } 
                        
                    }
                }
            }
            //Else if for when game option equals 2 (Human vs AI)
            else if (playerOption == 2)
            {
                //Gather player 1 name. 
                Console.WriteLine("Enter name for Player 1:");
                string userOne = Console.ReadLine();

                //Welcoming statement. 
                Console.WriteLine("Welcome " + userOne + "(P1) and AI(P2)");
                Console.WriteLine("Let's begin!");

                //Initialize i.
                int i = 0;

                //While loop to execute game. 
                while (true)
                {
                    //Prints out how many sticks are on the board. 
                    Console.WriteLine(myGame.Status());

                    //Decider for player turn or AI turn. 
                    int decider = i % 2;

                    //If the it is the players turn. 
                    if (decider == 0)
                    {
                        //Prompt user for how many sticks to take. 
                        Console.WriteLine(userOne + "(P1): How many sticks do you take (1-3)?");
                        int theSticks = int.Parse(Console.ReadLine());

                        //If the sticks chosen are between 1 and 3. 
                        if ((theSticks >= 1) && (theSticks <= 3))
                        {
                            //Removes sticks from count. 
                            myGame.RemoveSticks(theSticks);

                            //Adds to I to change to AI's turn. 
                            i++;
                        }
                        //Error handling if number is outside of range. 
                        else
                        {
                            Console.WriteLine("Please enter a number between 1 and 3.");
                        }
                    }

                    //When decider is not zero AI will run. 
                    else 
                    {
                        int aiTakes = myAI.ChooseFromHat(myGame.getSticks());
                        Console.WriteLine("AI takes " + aiTakes + " sticks.");
                        myGame.RemoveSticks(aiTakes);
                        i++;
                    }
                        //When the sticks remaining on the table is zero. 
                    if (myGame.getSticks() <= 0)
                    {
                        if (decider == 1)
                        {
                            //Message to tell user who won. 
                            Console.WriteLine("There are no sticks remaining on the board.");
                            Console.WriteLine(userOne + " Won!");

                            //Sets the AI as a loss. 
                            myAI.WinLose(false);

                            //Asks user if they would like to play again. 
                            Console.WriteLine("Would you like to play again (y or n)?");
                            string playAgain = Console.ReadLine();

                            //When user enters a y to play again.
                            if (playAgain == "y")
                            {
                                Console.WriteLine("Restarting game...");
                                myGame.setSticks(numSticks);
                                Console.WriteLine(myGame.Status());
                                i = 0;
                                decider = 0;
                            }
                            //Breaks if anything entered is not a y. 
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            //Message to tell user that the AI won. 
                            Console.WriteLine("AI Won!");

                            //Sets AI as a win to store memory. 
                            myAI.WinLose(true);

                            //Asks user if they would like to play again. 
                            Console.WriteLine("Would you like to play again (y or n)?");
                            string playMore = Console.ReadLine();

                            //When user enters a y to play again and resets game. 
                            if(playMore == "y")
                            {
                                Console.WriteLine("Restarting game...");
                                myGame.setSticks(numSticks);
                                Console.WriteLine(myGame.Status());
                                i = 0;
                                decider = 0;
                            }

                            //If user enters anything but a y it will end game. 
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }

            //If user chooses to play against the trained AI. 
            else if (playerOption == 3)
            {
                //Gather player 1 name. 
                Console.WriteLine("Enter name for Player 1:");
                string userOne = Console.ReadLine();

                //Training the AI message
                Console.WriteLine("Please wait....training the AI.");


                //For loop to have myAI and newAI play against each other. 
                for (int i = 0; i < 10000; i++)
                {
                    //A and aiDecider handle switching the AI's turn. 
                    int a = 0;
                    int aiDecider = a % 2;

                    //myAI goes first then switches to newAI.
                    if (aiDecider == 0)
                    {
                        int aiHats = myAI.ChooseFromHat(myGame.getSticks());
                        myGame.RemoveSticks(aiHats);
                        a++;
                    }
                    else
                    {
                        int aiSticks = newAI.ChooseFromHat(myGame.getSticks());
                        myGame.RemoveSticks(aiSticks);
                        a++;
                    }

                    //When each instance of a game is completed and
                    //stick count is zero. 
                    if (myGame.getSticks() <= 0)
                    {
                        if (aiDecider == 1)
                        {
                            //Makes myAI set as a loss and newAI
                            //set as a win. 
                            myAI.WinLose(false);
                            newAI.WinLose(true);

                            //Sets stick count back to initial stick value. 
                            myGame.setSticks(numSticks);
                        }
                        else
                        {
                            //Sets myAI as a win and sets newAI
                            //as a loss. 
                            myAI.WinLose(true);
                            newAI.WinLose(false);

                            //Sets stick count back to initial stick value. 
                            myGame.setSticks(numSticks);
                        }
                    }
                }

                //Message to print out how many games were played.
                Console.WriteLine("10,000 games completed");

                //Sets stick count to numSticks. 
                myGame.setSticks(numSticks);

                //Declaring c which changes player turns. 
                int c = 0;

                //While loop to execute game vs Trained AI. 
                while (true)
                {
                    //Prints out how many sticks are on the board. 
                    Console.WriteLine(myGame.Status());

                    //Decider for player turn or Trained AI turn. 
                    int decider = c % 2;

                    //If the it is the players turn. 
                    if (decider == 0)
                    {
                        //Prompt user for how many sticks to take. 
                        Console.WriteLine(userOne + "(P1): How many sticks do you take (1-3)?");
                        int theSticks = int.Parse(Console.ReadLine());

                        //If the sticks chosen are between 1 and 3. 
                        if ((theSticks >= 1) && (theSticks <= 3))
                        {
                            //Removes sticks from count. 
                            myGame.RemoveSticks(theSticks);

                            //Adds to I to change to Trained AI's turn. 
                            c++;
                        }
                        //Error handling if number is outside of range. 
                        else
                        {
                            Console.WriteLine("Please enter a number between 1 and 3.");
                        }
                    }

                    //When decider is not zero Trained AI will run. 
                    else
                    {
                        int newAITakes = myAI.ChooseFromHat(myGame.getSticks());
                        Console.WriteLine("Trained AI takes " + newAITakes + " sticks.");
                        myGame.RemoveSticks(newAITakes);
                        c++;
                    }
                    //When the sticks remaining on the table is zero. 
                    if (myGame.getSticks() <= 0)
                    {
                        if (decider == 1)
                        {
                            //Message to tell user who won. 
                            Console.WriteLine("There are no sticks remaining on the board.");
                            Console.WriteLine(userOne + " Won!");

                            //Asks user if they would like to play again. 
                            Console.WriteLine("Would you like to play again (y or n)?");
                            string playAgain = Console.ReadLine();

                            //When user enters a y to play again.
                            if (playAgain == "y")
                            {
                                Console.WriteLine("Restarting game...");
                                myGame.setSticks(numSticks);
                                Console.WriteLine(myGame.Status());
                                c = 0;
                                decider = 0;
                            }
                            //Breaks if anything entered is not a y. 
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            //Message to tell user that the AI won. 
                            Console.WriteLine("Trained AI(P2) Won!");

                            //Asks user if they would like to play again. 
                            Console.WriteLine("Would you like to play again (y or n)?");
                            string playMore = Console.ReadLine();

                            //When user enters a y to play again and resets game. 
                            if (playMore == "y")
                            {
                                Console.WriteLine("Restarting game...");
                                myGame.setSticks(numSticks);
                                Console.WriteLine(myGame.Status());
                                c = 0;
                                decider = 0;
                            }

                            //If user enters anything but a y it will end game. 
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }

            //If user enters an invalid number. 
            else
            {
                //Error handling message. 
                Console.WriteLine("Please enter a 1, 2, or 3 to choose who to play.");
            }
        }
    }
}
