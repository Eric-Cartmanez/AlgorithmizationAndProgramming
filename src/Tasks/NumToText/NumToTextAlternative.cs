namespace Tasks.NumToText;

public class NumToTextAlternative : INumToTextSolution
{
    public void Run()
    {
        bool isCorrectValue = int.TryParse(Console.ReadLine(), out int input);

        Console.WriteLine(!isCorrectValue ? "input is not an int number" : Convert(input));
    }

    public string Convert(int nun)
    {
        if (nun < 1 || nun > 99) return "error";

        int x = nun / 10;
        int y = nun % 10;

        switch (x)
        {
            case 0:
                return GetPart2(y);
            case 1:
                return GetTeens(x, y);
            default:
                return y == 0 ? $"{GetPart1(x)}" : $"{GetPart1(x)} {GetPart2(y)}";
        }
    }

    private string GetTeens(int x, int y)
    {
        if (y == 0) return GetPart1(x);

        string temp = GetPart2(y);
        if (temp.Length > 3 && temp != GetPart2(1)) temp = temp[..^1];
        if (temp == GetPart2(2)) temp = $"{temp[..^1]}е";

        return $"{temp}надцать";
    }

    private string GetPart1(int num)
    {
        switch (num)
        {
            case 1: return "десять";
            case 2:
            case 3: return $"{GetPart2(num)}дцать";
            case 4: return "сорок";
            case 9: return "девяносто";
            default: return $"{GetPart2(num)}десят";
        }
    }

    private string GetPart2(int num)
    {
        switch (num)
        {
            case 1: return "один";
            case 2: return "два";
            case 3: return "три";
            case 4: return "четыре";
            case 5: return "пять";
            case 6: return "шесть";
            case 7: return "семь";
            case 8: return "восемь";
            case 9: return "девять";
            default: return "";
        }
    }
}
