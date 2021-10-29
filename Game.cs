//Project2Stewart
//Collin Stewart
//March 2021
//Game class

using System;
namespace Project2Stewart
{
    //A class that represents a game to pick up sticks. 
    public class Game
    {
        //------Data Members------
        const int defaultSticks = 10;
        const int minSticks = 10;
        const int maxSticks = 100;
        int totalSticks;
        int currentSticks;
        int turn;
        bool playingAI;
        string p1Name;
        string p2Name;

        //Constructor for game class. 
        public Game()
        {
            //Initialize data members.
            totalSticks = 100;
            currentSticks = 10;
            turn = 0;
            playingAI = false;
            p1Name = "Player 1";
            p2Name = "Player 2";
        }

        //Getter for current sticks.
        public int getSticks()
        {
            return currentSticks;
        }

        //Setter for new sticks on table. 
        public void setSticks (int newSticks)
        {
            currentSticks = newSticks;
        }

        //Function to subtract taken sticks from pile.
        public void RemoveSticks(int numSticks)
        {
            currentSticks = currentSticks - numSticks; 
        }

        //Function to return to the user how many sticks are on the board. 
        public string Status()
        {
            return "There are " + currentSticks + " sticks on the board.";
        }

        //Getter for player 1 name.
        public string getFirstUser()
        {
            return p1Name;
        }

        //Setter for player 1 name.
        public void setFirstUser (string newNameOne)
        {
            p1Name = newNameOne;
        }

        //Getter for player 2 name.
        public string getSecondUser()
        {
            return p2Name;
        }

        //Setter for player 2 name.
        public void setSecondUser (string newNameTwo)
        {
            p2Name = newNameTwo;
        }
    }
}
