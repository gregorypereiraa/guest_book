using System.Text;
using Spectre.Console;

namespace GuestBook;

public class GuestLogic
{
    private static string WelcomeMessage()
    {
        var sb = new StringBuilder();
        sb.Append("\n");
        sb.Append("****************************************\n");
        sb.Append("Welcome to GuestBook App created by Greg\n");
        sb.Append("****************************************\n");
        return sb.ToString();
    }

    private static string GetName()
    {
        var output = AnsiConsole.Ask<string>("What is your name: ");
        return output;
    }

    private static int GetNumber()
    {
        var output = AnsiConsole.Ask<int>("How many people are with you: ");
        return output;
    }

    private static bool IsPartyOver()
    {
        var correctinput = false;
        var isPartyOver = "";
        do
        {
            Console.Write("Are there more guest coming (yes/no): ");
            isPartyOver = Console.ReadLine();
            if (isPartyOver.ToLower() == "yes" || isPartyOver.ToLower() == "no")
                correctinput = true;
            else Console.WriteLine("Wrong Input please start again");
        } while (correctinput is false);

        var output = isPartyOver.ToLower() != "no";
        return output;
    }

    private static (List<string>, int) GetAllData()
    {
        var outputName = new List<string>();
        var outputNumber = 0;
        do
        {
            outputName.Add(GetName());
            outputNumber += GetNumber();
            ;
        } while (IsPartyOver());

        return (outputName, outputNumber);
    }

    public static void Display()
    {
        var sb = new StringBuilder();
        Console.WriteLine(WelcomeMessage());
        var (names, number) = GetAllData();
        Console.Clear();
        sb.Append("\n");
        sb.Append("At this party, there are exactly " + number + " people having a wonderful night\r");
        sb.Append('\n');
        sb.Append("The groups of people having a Great night are \r\n");
        foreach (var output in names)

        {
            sb.Append(output + "'s group\r");
            sb.Append('\n');
        }

        Console.WriteLine(sb.ToString());
    }
}