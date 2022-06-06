int consoliumHealth = 15;
int tRexHealth = 10;
int round = 1;

Random random = new Random();
int tRexLoc = random.Next(100) + 1;

Console.WriteLine("Commander, we request your aid in the Defense of Consolium Prime!");
Console.WriteLine();
Console.WriteLine("After a fierce space battle over Consolium Prime, the Imperial Fleet has managed to disable the Chaos Battleship Terminus Rex.");
Console.WriteLine("However, only at a great cost - our ship's sensors and engines are also disabled...");
Console.WriteLine( "...and the Terminus Rex is preparing a last ditch effort to purge all life from Consolium Prime via Viral Bombardment!") ;
Console.WriteLine("Determine the location of the Terminus Rex by fireing blind, and finish it off before the planet destroyed!");
Console.WriteLine("");
Console.WriteLine("Some ammunication payloads are better than others- good luck Captain! For the Emperor");
Console.WriteLine("");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("(***WARNING - EARLY BULID - only input whole numbers for Range!!***** ");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("(Press enter to continue)");

Console.ReadLine();

Console.Clear();

while (consoliumHealth > 0 && tRexHealth > 0)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("-------------------------------------------------");
    DisplayStatus(round, consoliumHealth, tRexHealth);

    int damage = DamageForRound(round);
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"Our cannons are expected to deal {damage} this round.");

    Console.ForegroundColor = ConsoleColor.White;
    int targetRange = AskForNumber("My Lord, enter a desired cannon range between 1 and 100:", 1, 100);



    Console.ForegroundColor = ConsoleColor.Blue;
    displayOverOrUnder(targetRange, tRexLoc);

    if (targetRange == tRexLoc) tRexHealth -= damage;

    if (tRexHealth > 0) consoliumHealth--;

    round++;


}

bool won = consoliumHealth > 0;
DisplayWinOrLose(won);

void DisplayWinOrLose(bool won)
{
    if (won)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("We've destroyed the Terminus Rex and the planet is saved! Praise the Emperor");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The Terminus Rex has achieved orbital bombardment, and the planet is lost.");
    }
}

void displayOverOrUnder(int targetRange, int range)
{
    if (targetRange < range) Console.WriteLine("MISS - Your estimation was BELOW the target!!");
    else if (targetRange > range) Console.WriteLine("MISS - You overestimated the location! The shot went too HIGH!");
    else Console.WriteLine("DIRECT HIT!  Stay targeted on that location! For the Emperor!");

}

void DisplayStatus(int round, int consoliumHealth, int tRexHealth)
{
    Console.WriteLine($"STATUS: Round: {round} Time Remaining: {consoliumHealth} Terminus Rex: {tRexHealth}/10");
}

int DamageForRound(int roundNumber)
{
    if (roundNumber % 5 == 0 && roundNumber % 3 == 0) return 10;
    else if (roundNumber % 5 == 0) return 3;
    else if (roundNumber % 3 == 0) return 3;
    return 1;
}

int AskForNumber(string text, int min, int max)
    {
     while (true)
        {
            Console.WriteLine(text + " ");
            Console.ForegroundColor = ConsoleColor.Cyan;
        int number = 0;
        string incomingData = Console.ReadLine();
        try
        {
            int.TryParse(incomingData, out number);
            if (number == 0)
                Console.WriteLine("Our cogitaters are unable to accept that input!");
            if (number >= min && number < max)
                return number;
        }
        catch (Exception ex) { }
        }
        

    }