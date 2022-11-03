using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Threading;
class Program
{
    public string Question1(int q1Number)
    {
        switch(q1Number)
        {
            case 1:
                return "7 / 3 * 12";
                break;
            case 2:
                return "sqrt(49) * 3";
                break;
            case 3:
                return "What are the first 3 digits of pi? (Excluding the 3.)";
                break;
            case 4:
                return "6 / 2(1 + 2)";
            default:
                return "23 * 30";
                break;
        }
    }
    public int Q1Answer(string q1Question)
    {
        if (q1Question == "7 / 3 * 12")
        {
            return 25;
        }
        else if (q1Question == "sqrt(49) * 3")
        {
            return 21;
        }
        else if (q1Question == "What are the first 3 digits of pi? (Excluding the 3.)")
        {
            return 141;
        }
        else if (q1Question == "6 / 2(1 + 2)")
        {
            return 9;
        }
        else
        {
            return 690;
        }
    }
    public string Question2(int q2Number)
    {
        switch (q2Number)
        {
            case 1:
                return "Finish the quote. 'What came first, the chicken or the ___?";
                break;
            case 2:
                return "Instead of a foot, what do animals have? (A ___)";
                break;
            default:
                return "What do you see out of? (Your ___)";
                break;
        }
    }
    public string Q2Answer(string q2Question)
    {
        switch (q2Question)
        {
            case "Finish the quote. 'What came first, the chicken or the ___?":
                return "egg";
                break;
            case "Instead of a foot, what do animals have? (A ___)":
                return "paw";
                break;
            default:
                return "eye";
                break;
        }
    }
    public static void Main(string[] args)
    {
        Program p = new Program();
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Random random = new Random();
    int q1Number = random.Next(1, 6);
    int q2Number = random.Next(1, 4);
    string q1Question = p.Question1(q1Number);
    string q2Question = p.Question2(q2Number);
    int q1Answer = p.Q1Answer(q1Question);
    string q2Answer = p.Q2Answer(q2Question);
    string response = "";
    bool escaped = false;
    bool wordPuzzleComplete = false;
    bool numPuzzleComplete = false;
    Stopwatch sw = new Stopwatch();
    sw.Start();
    Console.WriteLine("Welcome to the escape room. Your only goal is to escape. \nYou're welcome to survey the room, but you only have a limited time until you are permanantly stuck here. What would you like to examine? \n1. Door \n2. Wall");
    while (escaped == false && sw.Elapsed.TotalSeconds <= 180)
    {
    invalidResponse:
    Console.ForegroundColor = ConsoleColor.DarkMagenta;

        response = Console.ReadLine();

            if (response.ToLower().Equals("door"))
            {
                doorInteraction:
                Console.WriteLine("You see 2 locks. One has a 3 letter input and the other has a number pad. \nWhat would you like to examine? \n 1. Wall \n 2. Numpad \n 3. Letter lock");
                response = Console.ReadLine();
                    if (response.ToLower().Equals("numpad"))
                    {
                    Console.WriteLine("");
                    Console.WriteLine("The numpad requires an input. What do you input?");
                        response = Console.ReadLine();
                        if (response == Convert.ToString(q1Answer))
                        {
                            numPuzzleComplete = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("");
                        Console.WriteLine("The numpad flashes a green light.");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        }
                        else
                        {
                        Console.WriteLine("");
                        Console.WriteLine("The numpad flashes a red light");
                        }
                    }
                    else if (response.ToLower().Equals("letter lock"))
                    {
                    Console.WriteLine("");
                    Console.WriteLine("The letter lock has 3 characters. What do you input?");
                        response = Console.ReadLine();
                        if (response == q2Answer)
                        {
                            wordPuzzleComplete = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("");
                        Console.WriteLine("The letter lock flashes a green light.");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        }
                        else
                        {
                        Console.WriteLine("");
                        Console.WriteLine("The letter lock flashes a red light");
                        }
                    }
                    else
                    {
                        
                    }
            }
            else if (response.ToLower().Equals("wall"))
            {
                wallInteraction:
                Console.WriteLine("");
                Console.WriteLine("You notice 3 screens embedded into the wall. The first says " + q1Question + "\nThe next one says " + q2Question + "\nAnd the last displays " + Math.Floor(sw.Elapsed.TotalSeconds) + "s");

                
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Invalid response.");
                goto invalidResponse;
            }
        if (numPuzzleComplete == true && wordPuzzleComplete == true)
        {
            escaped = true;
        }
        else
        {
                Console.WriteLine("");
                Console.WriteLine("What would you like to examine? \n1. Door \n2. Wall");
        }
    }
    if (sw.Elapsed.TotalSeconds > 180)
    {
            Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("A thick metal sheet covers the door and walls. You're trapped. \n(Bad End 1/4)");
    }
    else
    {
            Console.WriteLine("");
            Console.WriteLine("You escaped. Well done! \nBut you aren't sure if you should leave this mystery alone. You feel that if you don't find and stop whoever, or whatever, put you here, that others will have to go through this. \nDo you run, or do you stay to figure out this mystery? \n  Stay \n  Run");
        Checkpoint:
        response = Console.ReadLine();
        if (response.ToLower().Equals("run"))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You run, never to return. You hear of more people going missing, and a small percent returning from the same woods you emerged from. (Neutral Ending)");
            Environment.Exit(0);
        }
        else if(response.ToLower().Equals("stay"))
        {
            Console.WriteLine("You understand the risk of further investigation, but its your duty as a citizen to put an end to this.");
        }
        else
        {
            Console.WriteLine("Invalid response.");
            goto Checkpoint;
        }

    }
    Thread.Sleep(5000);
    Console.Clear();
        Console.WriteLine("You turn around and begin to run back towards the camouflaged metal building in the woods. \nBefore you get there, you feel a sharp poke in your neck.");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("");
        Console.WriteLine("You fall unconscious");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Thread.Sleep(3000);
        Console.WriteLine("You wake up. Where are you?");
        Thread.Sleep(3000);
        Console.WriteLine("You can't move. You are completely bound to a chair. You hear a voice come from a speaker.");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Thread.Sleep(3000);
        Console.WriteLine("Welcome! You escaped my original trap, and for that I applaud you. \nHowever, you did make one...");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Thread.Sleep(5000);
        Console.WriteLine("fatal");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Thread.Sleep(3000);
        Console.WriteLine("mistake.");
        Thread.Sleep(3000);
        Console.WriteLine("You came back. Truly, you should've just ran off. I wish you good luck.");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Thread.Sleep(5000);
        Console.Clear();
        Console.WriteLine("The straps binding you to the chair unlock.");
        Console.WriteLine("You have two minutes. Escape.");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        bool room2esc = false;
        bool room2hallEsc = false;
        bool tapedPaperAcquired = false;
        bool tapeAcquired = false;
        bool tapedCamera = false;
        bool paperAcquired = false;
        bool paperAcquirable = true;
        bool scissorsAcquired = false;
        sw.Restart();
        Console.WriteLine("Looking around, you see a camera, a notebook, a desk, a candle, a trash bin, and a door. What do you examine? \nOr, you can try to craft.");
        while (room2esc == false && sw.Elapsed.TotalSeconds <= 120)
        {
        introDone:
            Console.WriteLine("");

            Console.WriteLine("What do you examine next? (Or craft)");
            response = Console.ReadLine();
            if (response.ToLower() == "camera")
            {
                if (tapedCamera == false)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Theres a camera mounted to the ceiling, it appears to be pointed towards the door.");
                    if (tapedPaperAcquired == true)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You cover the camera with the large sheet of paper you taped together.");
                        tapedCamera = true;
                        goto introDone;
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You can't do anything here yet.");
                        goto introDone;
                    }
                }
                else
                {
                    Console.WriteLine("Theres nothing else to do here.");
                    goto introDone;
                }

            }
            else if (response.ToLower() == "notebook")
            {
                if (scissorsAcquired == true && paperAcquirable == true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("You cut out some papers from the notebook. Maybe they'll come in handy?");
                    paperAcquirable = false;
                    paperAcquired = true;
                    goto introDone;
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Its an empty notebook.");
                    goto introDone;
                }
            }
            else if (response.ToLower() == "desk")
            {
                if (tapeAcquired == false)
                {
                    Console.WriteLine("You find a roll of tape.");
                    tapeAcquired = true;
                    goto introDone;
                }
                else
                {
                    Console.WriteLine("Theres nothing else in here");
                    goto introDone;
                }
            }
            else if (response.ToLower() == "candle")
            {
                Console.WriteLine("The candle grows ever shorter as it burns, as does your time.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("(" + Math.Floor(120 - sw.Elapsed.TotalSeconds) + " Seconds remain)");
                goto introDone;
            }
            else if (response.ToLower() == "trash bin")
            {
                if (scissorsAcquired == false)
                {
                    Console.WriteLine("You find a pair of scissors in the bin.");
                    scissorsAcquired = true;
                    goto introDone;
                }
                else
                {
                    Console.WriteLine("Theres nothing else in here.");
                    goto introDone;
                }
            }
            else if (response.ToLower() == "door")
            {
                Console.WriteLine("The door doesn't appear to be locked. Open it? (Y or N)");
                doorResp:
                response = Console.ReadLine();
                if (response.ToLower() == "y")
                {
                    if (tapedCamera == true)
                    {
                        Console.WriteLine("You enter the hallway, the door closes behind you.");
                        room2esc = true;
                    }                 
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("As you exit the room, you feel a sharp pain in your chest. You begin to bleed. \nBefore you lose consciousness, you hear a voice");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("I can see you. \n(Bad End 2/4)");
                        Environment.Exit(0);
                    }
                }
                else if (response.ToLower() == "n")
                {
                    goto introDone;
                }
                else
                {
                    Console.WriteLine("Invalid Response");
                    goto doorResp;
                }
            }
            else if (response.ToLower() == "craft")
            {
                if (paperAcquired == true && tapeAcquired == true)
                {
                    Console.WriteLine("You tape some of the paper together to make a larger sheet. \nSurely this will help somehow.");
                    tapedPaperAcquired = true;
                    paperAcquired = false;
                }
                else
                {
                    Console.WriteLine("You have nothing to craft");
                    goto introDone;
                }
            }
        }
        if (sw.Elapsed.TotalSeconds > 120)
        {
            Console.Clear();
            Console.WriteLine("The door locks and the walls begin to close in. You hear a voice in the speaker");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("You've should've ran while you could. \n(Bad End 3/4)");
        }
            hallIntro:        
        while (room2hallEsc == false)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine("Do you turn left or right? (Checkpoint Saved)");
            response = Console.ReadLine();
            if (response.ToLower() == "left")
            {
                goto hallDeath;
            }
            else if (response.ToLower() == "right")
            {
                hall2:
                Console.WriteLine("");
                Console.WriteLine("Do you turn left or right?");
                response = Console.ReadLine();
                if (response.ToLower() == "left")
                {
                    goto hallDeath;
                }
                else if (response.ToLower() == "right")
                {
                hall3:
                    Console.WriteLine("");
                    Console.WriteLine("Do you turn left or right?");
                    response = Console.ReadLine();
                    if (response.ToLower() == "left")
                    {
                        room2hallEsc = true;
                    }
                    else if (response.ToLower() == "right")
                    {
                        goto hallDeath;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Response");
                        goto hall3;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Response");
                    goto hall2;
                }
            }
            else
            {
                Console.WriteLine("Invalid Response");
                goto hallIntro;
            }
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("You see a door at the end of the hallway, you begin to run towards it.");
        Thread.Sleep(1500);
        Console.WriteLine("You break into the room. You see a chair facing a wall covered in monitors. \nYou've finally found the culprit.");
        Thread.Sleep(1500);
        Console.WriteLine("Scissors in hand, you turn the chair, finally facing the mastermind behind this operation.");
        Thread.Sleep(1500);
        Console.WriteLine("Its...");
        Thread.Sleep(3000);
        Console.WriteLine("..a loaf of bread? This can't be, thats not possible!");
        Thread.Sleep(1500);
        Console.WriteLine("The world around you begins to warp. Whats happening..?");
        Thread.Sleep(1500);
        Console.WriteLine("You wake up. You're in a padded cell.");
        Console.WriteLine("You were dreaming. Of course you were, this happens every night. Another side effect of your brain injury.");
        Console.WriteLine("You go through your day as normal, just to do this all over again tonight. (Good(?) End)");
        Environment.Exit(0);
    hallDeath:
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Dead End. \nA large thing that can only be described as a monster appears before you. You are consumed, torn apart in its jaws. (Bad End 4/4)");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Checkpoint or Quit?");
        CheckpointOrQuit:
        response = Console.ReadLine();
        if (response.ToLower() == "checkpoint")
        {
            goto hallIntro;
        }
        else if (response.ToLower() == "quit")
        {
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Invalid Response");
            goto CheckpointOrQuit;
        }

    }

}