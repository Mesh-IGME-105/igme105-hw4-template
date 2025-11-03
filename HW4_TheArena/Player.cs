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
    /// <summary>
    /// Stores information about the player character
    /// </summary>
    internal class Player
    {
        // *** These constants are defined for you to make your code more readable AND help ensure it works
        //     with the code given to you. Do NOT change these!

        // Possible fight outcomes
        public const int Win = 0;
        public const int Lose = 1;
        public const int Run = 2;
        public const int Draw = 3;

        // *** Other constants
        // TODO: It's okay to tweak these numbers a bit to balance your game and/or add new ones.
        // (But don't delete what is here.)
        private const int HealthMult = 5;
        private const int DamageMult = 5;

        // *** Class Fields ***

        // Player's name
        private string name;

        // Player stats
        private int strength;
        private int dexterity;
        private int constitution;
        private int health;

        /// <summary>
        /// Setup a new player with the given name and stats.
        /// Health is calculated based on constitution.
        /// </summary>
        public Player(string name, int strength, int dexterity, int constitution)
        {
            this.name = name;
            this.strength = strength;
            this.dexterity = dexterity;
            this.constitution = constitution;
            health = HealthMult * constitution;

        }

        /// <summary>
        /// Retreats to the starting area of the arena to recover health.
        /// </summary>
        public void Retreat()
        {
            Console.WriteLine("You retreat to the starting area of the arena to heal up.");
            health += (constitution * HealthMult) / 2;
            health = Math.Clamp(health, 0, constitution * HealthMult); // cap at max health
        }

        /// <summary>
        /// Display the player's stats to the console.
        /// </summary>
        public void Print()
        {
            Console.WriteLine(
                $"\n{name}, your stats are: " +
                $"Strength {strength}, " +
                $"Dexterity {dexterity}, " +
                $"Constitution {constitution}, " +
                $"Health {health}");
        }

        /// <summary>
        /// Simulate a fight between the player and the given enemy.
        /// </summary>
        /// <returns>An integer representing the outcome of the fight:
        /// 0 = Win, 1 = Lose, 2 = Run, 3 = Draw</returns>
        public int Fight(Enemy enemy)
        {
            // TODO: Implement the Fight method
            return 0; // replace this. it's just so the starter code compiles.
        }

    }
}
