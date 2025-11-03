/// <summary>
/// DO NOT CHANGE ANY CODE IN THIS FILE **EXCEPT** in the TODO sections!!!
/// 
/// But it's definitely worth reading it to get an understanding of 
/// how/when your methods will be called.
/// 
/// AND it's okay to *temporarily* comment out chunks of code until 
/// you're ready for them to run to make it easier to test other things.
/// </summary>
namespace HW4_TheArena
{
    internal class Arena
    {

        // *** These constants are defined for you to make your code more readable AND help ensure it works
        //     with the code given to you. Do NOT change these! ***

        // Arena constraints
        private const int ArenaMinSize = 6;
        private const int ArenaMaxSize = 25;
        private const double EnemyChance = 0.02;

        // Tile Types
        private const char Empty = ' ';
        private const char Wall = '#';
        private const char Enemy = 'E';
        private const char PlayerIcon = '@';
        private const char PlayerStart = 's';
        private const char Exit = '*';

        // Movement Directions
        private const char Up = 'w';
        private const char Down = 's';
        private const char Left = 'a';
        private const char Right = 'd';

        // *** Class Fields ***

        // The arena layout
        private char[,] arena;

        // Number of enemies left
        private int numEnemiesLeft;

        // The current player
        private Player player;

        // The player's location as [row, col] (NOT x, y)
        private int[] playerLoc = { 1, 1 };

        // Possible enemy names
        private string[] enemyTypes = { "goblin", "troll", "skeleton", "angry goat" };

        // Random number generator
        Random rng = new Random();


        /// <summary>
        /// Constructor. Builds the arena and places the player.
        /// </summary>
        /// <param name="numRows">The number of rows in the arena</param>
        /// <param name="numCols">The number of columns in each row</param>
        /// <param name="player">A reference to a player instance</param>
        public Arena(Player player)
        {
            // TODO: Implement the Arena constructor
            char[,] arena = null; // replace this. it's just so the starter code compiles.
        }

        /// <summary>
        /// Print the arena to the console, showing the player's current location.
        /// </summary>
        public void Print()
        {
            // TODO: Implement the Print method
        }

        /// <summary>
        /// Prompts the player for a move direction and attempts to move them.
        /// </summary>
        /// <returns>True if the game can continue after this move</returns>
        public bool Move()
        {
            // Get the desired direction
            char direction = SmartConsole.PromptForChoice(
                    $"\n Where would you like to go? {Up}/{Left}/{Down}/{Right} >",
                    new char[] { Up, Left, Down, Right });
            Console.WriteLine();

            // Figure out what is there, but don't move yet
            int[] nextLoc = { playerLoc[0], playerLoc[1] };
            switch (direction)
            {
                case Up:
                    nextLoc[0]--; // row--
                    break;

                case Down:
                    nextLoc[0]++; // row++
                    break;

                case Left:
                    nextLoc[1]--; // col --
                    break;

                case Right:
                    nextLoc[1]++; // col ++
                    break;
            }

            // Act based on what is in the next location (row, col)
            switch (arena[nextLoc[0], nextLoc[1]])
            {
                // Do nothing. We're stuck.
                case Wall:
                    Console.WriteLine("\n You can't go there...");
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    break;

                // Move to that spot
                case Empty:
                    playerLoc = nextLoc;
                    break;

                // Launch a new fight and determine how to proceed based on the result
                case Enemy:
                    Enemy enemy = new Enemy(enemyTypes[rng.Next(enemyTypes.Length)], rng);
                    switch (player.Fight(enemy))
                    {
                        // Take over the enemy's spot if we win
                        case Player.Win:
                            playerLoc = nextLoc;
                            arena[playerLoc[0], playerLoc[1]] = Empty;
                            numEnemiesLeft--;
                            break;

                        // A loss or draw is game over
                        case Player.Lose:
                        case Player.Draw:
                            return false; // game over

                        // Run back to the start and regain half health
                        case Player.Run:
                            playerLoc = new int[] { 1, 1 };
                            player.Retreat();
                            break;
                    }
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    break;

                case Exit:
                    if (numEnemiesLeft > 0)
                    {
                        Console.WriteLine("You must defeat all enemies before you can escape.");
                    }
                    else
                    {
                        Console.WriteLine("You made it to the exit! Congratulations!");
                        return false; // game over
                    }
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();
                    break;
            }

            return true; // keep playing
        }
    }
}
