using System;

public class Pig
{

    public static void Main(String[] args)
    {

        Console.WriteLine("The Game of Pig");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("1. Human vs. Human");
        Console.WriteLine("2. Human vs. Computer");
        Console.WriteLine("3. Computer vs. Computer");
        Console.WriteLine("");
        Console.WriteLine("What kind of game do you want to play? ");

        int choice = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
        if (choice == 1)
        {
            playGame(true, true);
        }
        else if (choice == 2)
        {
            playGame(true, false);
        }
        else if (choice == 3)
        {
            playGame(false, false);
        }
    }
    public static void playGame(bool player1, bool player2)
    {
        int player1Score = 0;
        int player2Score = 0;
        int counter = 0;
        while (player1Score < 100 && player2Score < 100)
        {
            Console.WriteLine("Player 1 Score: " + player1Score);
            Console.WriteLine("Player 2 Score: " + player2Score);
            // Code to switch between Player 1 and Player 2 turns.
            if (counter % 2 == 0)
            {
                // Variable to assign player's score after the playTurn method has run.
                player1Score = player1Score + playTurn(player1, 1, player1Score);
            }
            else
            {
                player2Score = player2Score + playTurn(player2, 2, player2Score);
            }
            counter += 1;
        }
        // Outputs each player's score after a hold or a roll of 1.
        Console.WriteLine("Player 1 Score: " + player1Score);
        Console.WriteLine("Player 2 Score: " + player2Score);
        // once either player reaches 100 or more the program the loop stops and outputs a winner.
        if (player1Score > player2Score)
        {
            Console.WriteLine("Player 1 Wins!");
        }
        else
        {
            Console.WriteLine("Player 2 Wins!");
        }
    }

    public static int playTurn(bool player, int number, int totalScore)
    {
        // a variable to hold the decision to roll or hold. Roll = true, Hold = false.
        bool decision = true;
        int dieCount = 0;
        int turnScore = 0;
        String identifier = "";
        if (player == true)
        {
            identifier = "(Human)";
        }
        else
        {
            identifier = "(Computer)";
        }
        if (number == 1)
        {
            Console.WriteLine("");
            Console.WriteLine("Player 1's Turn " + identifier);
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("Player 2's Turn " + identifier);
        }
        // Loop through while the player continues to roll and not hold.
        while (decision == true)
        {
            // variable to hold the number of the die roll.
            Random rnd = new Random();
            dieCount = (int)(rnd.Next(1, 7));
            if (dieCount == 1)
            {
                turnScore = 0;
                Console.WriteLine("Rolled a " + dieCount);
                Console.WriteLine("Turn Over");
                Console.WriteLine("");
                return turnScore;
            }
            Console.WriteLine("Rolled a " + dieCount);
            turnScore = turnScore + dieCount;
            Console.WriteLine("Turn Score: " + turnScore);
            // Call the getDecsion method to see if the player wants to hold or roll.
            decision = getDecision(player, turnScore, totalScore);
        }

        Console.WriteLine("Turn over");
        Console.WriteLine("");

        return turnScore;
    }

    public static bool getDecision(bool player, int turnScore, int totalScore)
    {
        bool decision = true;
        String choice = "";

        if (player == true)
        {
            Console.WriteLine("Hold or Roll? (h or r) ");

            choice = (Console.ReadLine());


            if (choice.Equals("r"))
            {
                Console.WriteLine("Human player rolls");
                decision = true;
            }
            else
            {
                Console.WriteLine("Human player holds");
                decision = false;
            }
        }
        // If the player is a computer and he has scored 20 or more in a turn he will hold.
        if (player == false)
        {
            if (turnScore >= 20 || turnScore + totalScore >= 100)
            {
                Console.WriteLine("Computer player holds");
                decision = false;
            }
            else
            {
                Console.WriteLine("Computer player rolls");
            }
        }
        return decision;
    }
}