using Assignment2MorganLaymon;
using System.Runtime.CompilerServices;

// Initialization

string rootFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
string filePath = "";
int counter = 0;
int userInput;
bool fileFound = false;

List<VideoGame> vgList = new List<VideoGame>();

// Execute

InputFile();
vgList.Sort();
MainMenu();

void InputFile()
{
    Console.WriteLine("Please enter the name of the file you would like to open: (Example: FileName.csv)\nNote: This file must be held within the same folder as the Project Files.");
    var parseFileName = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(parseFileName))
    {
        Console.WriteLine("Error: Invalid File Directory. Please try again.");
        parseFileName = Console.ReadLine();
    }
    filePath = rootFolder + Path.DirectorySeparatorChar + parseFileName;
    while (fileFound == false)
    {
        try
        {
            using (StreamReader newReader = new StreamReader(filePath))
            {
                List<string> lines = new List<string>();
                while (!newReader.EndOfStream)
                {
                    lines.Add(newReader.ReadLine());
                }
                for (int i = 1; i < lines.Count; i++)
                {
                    string nextVG = lines[i];
                    string[] vgProperties = nextVG.Split(',');

                    VideoGame newVG = new VideoGame(vgProperties[0], vgProperties[1], Convert.ToInt32(vgProperties[2]), vgProperties[3], vgProperties[4], Convert.ToDouble(vgProperties[5]), Convert.ToDouble(vgProperties[6]), Convert.ToDouble(vgProperties[7]), Convert.ToDouble(vgProperties[8]), Convert.ToDouble(vgProperties[9]));
                    vgList.Add(newVG);
                }
                newReader.Close();
            }
            fileFound = true;
            Console.WriteLine("Success! File: " + parseFileName + " found. \n");
        }
        catch
        {
            Console.WriteLine("Error: File not found. Please try again.");
            parseFileName = Console.ReadLine();
            filePath = rootFolder + Path.DirectorySeparatorChar + parseFileName;
        }
    }
}

void MainMenu()
{
    Console.WriteLine("Welcome to the Video Game Analyzer:\n" +
                      "-----------------------------------\n" +
                      "[1] - Search Library (Dictionary)\n" +
                      "[2] - Highest Grossing Games (Stack)\n" +
                      "[3] - Lowest Grossing Games (Queues)\n" +
                      "[0] - Exit\n");
    var parseUserInput = Console.ReadLine();
    while (!Int32.TryParse(parseUserInput, out userInput) || userInput > 3 || userInput < 0)
    {
        Console.WriteLine("Error: Invalid Input. Please Try Again.");
        parseUserInput = Console.ReadLine();
    }
    userInput = Convert.ToInt32(parseUserInput);
    switch (userInput)
    {
        case 0:
            Console.WriteLine("\nThank you for using the program.");
            break;
        case 1:
            Console.Clear();
            LibrarySearch();
            break;
        case 2:
            Console.Clear();
            HGG();
            break;
        case 3:
            Console.Clear();
            LGG();
            break;
        default:
            Console.WriteLine("Error: Unacceptable Option.");
            break;
    }
}

void LibrarySearch()
{
    var userInput = "";
    while(userInput == "")
    {
        Console.Clear();
        counter = 0;
        var publisherDict = new Dictionary<string, Stack<VideoGame>>();
        foreach (VideoGame vg in vgList)
        {
            if (!publisherDict.ContainsKey(vg.publisher))
            {
                var publisherStack = new Stack<VideoGame>();
                publisherStack.Push(vg);
                publisherDict.Add(vg.publisher, publisherStack);
            }
            else if (publisherDict.ContainsKey(vg.publisher))
            {
                publisherDict[vg.publisher].Push(vg);
            }
        }
        foreach (var item in publisherDict)
        {
            counter++;
            Console.WriteLine(counter + ": " + item.Key);
        }
        Console.WriteLine("Here is a listing of all 577 Publishers within the Videogames. \nWhich developer would you like to view games for? (Please insert the full publisher name.)");
        var userPublisher = Console.ReadLine();
        while (publisherDict.ContainsKey(userPublisher) != true)
        {
            Console.WriteLine("Error: Publisher not found. Please try again: ");
            userPublisher = Console.ReadLine();
        }
        Console.Clear();
        Stack<VideoGame> stack = publisherDict[userPublisher];
        foreach (VideoGame vg in stack)
        {
            Console.WriteLine(vg);
        }
        Console.WriteLine("Here are all titles published by " + userPublisher + ".\nPress Enter to search for another Publisher, or insert anything to return to the Main Menu.");
        userInput = Console.ReadLine();
        Console.Clear();
    }
    MainMenu();
}

void HGG()
{
    Console.WriteLine("What option would you like to view the Highest Grossing Games for?\n" +
                  "-----------------------------------\n" +
                  " - North America\n" +
                  " - Europe\n" +
                  " - Japan\n" +
                  " - Global\n");
    var parseUserInput = Console.ReadLine();
    while (String.IsNullOrWhiteSpace(parseUserInput) || parseUserInput.ToUpper() != "NORTH AMERICA" && parseUserInput.ToUpper() != "EUROPE" && parseUserInput.ToUpper() != "JAPAN" && parseUserInput.ToUpper() != "GLOBAL" && parseUserInput.ToUpper() != "ALL")
    {
        Console.WriteLine("Error: Invalid Input. Please Try Again.");
        parseUserInput = Console.ReadLine();
    }
    switch (parseUserInput.ToUpper())
    {
        case "NORTH AMERICA":
            Console.Clear();
            HGGCountry("NORTH AMERICA");
            Console.Clear();
            MainMenu();
            break;
        case "EUROPE":
            Console.Clear();
            HGGCountry("EUROPE");
            Console.Clear();
            MainMenu();
            break;
        case "JAPAN":
            Console.Clear();
            HGGCountry("JAPAN");
            Console.Clear();
            MainMenu();
            break;
        case "GLOBAL":
            Console.Clear();
            HGGCountry("GLOBAL");
            Console.Clear();
            MainMenu();
            break;
        default: 
            Console.WriteLine("Error: Unacceptable Option.");
            MainMenu();
            break;
    }
}

void LGG()
{
    Console.WriteLine("What option would you like to view the Lowest Grossing Games for?\n" +
                  "-----------------------------------\n" +
                  " - North America\n" +
                  " - Europe\n" +
                  " - Japan\n" +
                  " - Global\n");
    var parseUserInput = Console.ReadLine();
    while (String.IsNullOrWhiteSpace(parseUserInput) || parseUserInput.ToUpper() != "NORTH AMERICA" && parseUserInput.ToUpper() != "EUROPE" && parseUserInput.ToUpper() != "JAPAN" && parseUserInput.ToUpper() != "GLOBAL" && parseUserInput.ToUpper() != "ALL")
    {
        Console.WriteLine("Error: Invalid Input. Please Try Again.");
        parseUserInput = Console.ReadLine();
    }
    switch (parseUserInput.ToUpper())
    {
        case "NORTH AMERICA":
            Console.Clear();
            LGGCountry("NORTH AMERICA");
            Console.Clear();
            MainMenu();
            break;
        case "EUROPE":
            Console.Clear();
            LGGCountry("EUROPE");
            Console.Clear();
            MainMenu();
            break;
        case "JAPAN":
            Console.Clear();
            LGGCountry("JAPAN");
            Console.Clear();
            MainMenu();
            break;
        case "GLOBAL":
            Console.Clear();
            LGGCountry("GLOBAL");
            Console.Clear();
            MainMenu();
            break;
        default:
            Console.WriteLine("Error: Unacceptable Option.");
            MainMenu();
            break;
    }
}

void HGGCountry(string countryName)
{
    var userSelection = "";
    var numRuns = -1;
    var hggList = vgList.OrderBy(x => x);
    if (countryName == "NORTH AMERICA")
    {
        hggList = vgList.OrderBy(x => x.naSales);
    }
    else if (countryName == "EUROPE")
    {
        hggList = vgList.OrderBy(x => x.euSales);
    }
    else if (countryName == "JAPAN")
    {
        hggList = vgList.OrderBy(x => x.jpSales);
    }
    else if (countryName == "GLOBAL")
    {
        hggList = vgList.OrderBy(x => x.globalSales);
    }
    Stack<VideoGame> hgg = new Stack<VideoGame>(hggList);
    while (userSelection == "")
    {
        Console.Clear();
        numRuns++;
            for (int i = 0; i < 5; i++)
            {
                var game = hgg.Pop();
                if (countryName == "NORTH AMERICA")
                {
                    Console.WriteLine(((i + 1) + (numRuns * 5)) + " - Title: " + game.name + "\n" +
                                  "Sales in " + countryName + ": " + game.naSales + "\n");
                }
                else if (countryName == "EUROPE")
                {
                    Console.WriteLine(((i + 1) + (numRuns * 5)) + " - Title: " + game.name + "\n" +
                                  "Sales in " + countryName + ": " + game.euSales + "\n");
                }
                else if (countryName == "JAPAN")
                {
                    Console.WriteLine(((i + 1) + (numRuns * 5)) + " - Title: " + game.name + "\n" +
                                  "Sales in " + countryName + ": " + game.jpSales + "\n");
                }
                else if (countryName == "GLOBAL")
                {
                    Console.WriteLine(((i + 1) + (numRuns * 5)) + " - Title: " + game.name + "\n" +
                                  "Sales in " + countryName + ": " + game.globalSales + "\n");
                }
            }
            Console.WriteLine("Would you like to view the next 5 highest grossing games?\n" +
                "Press Enter to Continue, or anything else to Exit to Main Menu.");
            userSelection = Console.ReadLine();
    }
}

void LGGCountry(string countryName)
{
    var userSelection = "";
    var numRuns = -1;
    var lggList = vgList.OrderBy(x => x);
    if (countryName == "NORTH AMERICA")
    {
        lggList = vgList.OrderBy(x => x.naSales);
        lggList.Reverse();
    }
    else if (countryName == "EUROPE")
    {
        lggList = vgList.OrderBy(x => x.euSales);
        lggList.Reverse();
    }
    else if (countryName == "JAPAN")
    {
        lggList = vgList.OrderBy(x => x.jpSales);
        lggList.Reverse();
    }
    else if (countryName == "GLOBAL")
    {
        lggList = vgList.OrderBy(x => x.globalSales);
        lggList.Reverse();
    }
    Queue<VideoGame> hgg = new Queue<VideoGame>(lggList);
    while (userSelection == "")
    {
        Console.Clear();
        numRuns++;
        for (int i = 0; i < 5; i++)
        {
            var game = hgg.Dequeue();
            if (countryName == "NORTH AMERICA")
            {
                Console.WriteLine(((i + 1) + (numRuns * 5)) + " - Title: " + game.name + "\n" +
                              "Sales in " + countryName + ": " + game.naSales + "\n");
            }
            else if (countryName == "EUROPE")
            {
                Console.WriteLine(((i + 1) + (numRuns * 5)) + " - Title: " + game.name + "\n" +
                              "Sales in " + countryName + ": " + game.euSales + "\n");
            }
            else if (countryName == "JAPAN")
            {
                Console.WriteLine(((i + 1) + (numRuns * 5)) + " - Title: " + game.name + "\n" +
                              "Sales in " + countryName + ": " + game.jpSales + "\n");
            }
            else if (countryName == "GLOBAL")
            {
                Console.WriteLine(((i + 1) + (numRuns * 5)) + " - Title: " + game.name + "\n" +
                              "Sales in " + countryName + ": " + game.globalSales + "\n");
            }
        }
        Console.WriteLine("Would you like to view the next 5 lowest grossing games?\n" +
            "Press Enter to Continue, or anything else to Exit to Main Menu.");
        userSelection = Console.ReadLine();
    }
}