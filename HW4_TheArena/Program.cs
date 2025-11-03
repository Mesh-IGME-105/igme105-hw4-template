/***
 * YOUR NAME
 * 
 * HW 4 - The Arena
 * Write-up: https://docs.google.com/document/d/1Sc9KvIcOTGVNI1tMb3ncLlmZrvjryeyHiQQ04mSkhlA/edit?usp=sharing
 *
 */

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

    internal class Program
    {
        // Main is intentionally uncommented.
        static void Main(string[] args)
        {
            const int MaxPoints = 10;
            int strength = 0;
            int dexterity = 0;
            int constitution = 0;
            string name = "???";

            // TODO: Prompt the player for their name and stat allocations in order to create a Player object

            // Do not change anything below this line
            Player player = new Player(name, strength, dexterity, constitution);
            player.Print();

            Console.WriteLine("\nPress any key to start the game.");
            Console.ReadKey();

            Arena arena = new Arena(player);

            do
            {
                Console.Clear();
                arena.Print();
                player.Print();
            }
            while (arena.Move());

        }

    }
}