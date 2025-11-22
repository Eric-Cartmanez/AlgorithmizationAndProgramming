namespace Tasks.RomeNumbers;

public class RomeNumbersAlternative : IRomeNumbersSolution
{
    public void Run()
    {
        byte num = byte.Parse(Console.ReadLine());
        string res = Convert(num);
        Console.WriteLine(res);
    }

    public string Convert(int num)
    {
        if (num < 1 || num > 100) throw new ArgumentOutOfRangeException(nameof(num), "[1, 100]");

        const string hBitLetters = "XLC";
        const string lBitLetters = "IVX";
        int hBit = num / 10;
        int lBit = hBit == 0 ? num : num % 10;

        string part1 = GenerateRomNum(hBit, hBitLetters);
        string part2 = GenerateRomNum(lBit, lBitLetters);

        return $"{part1}{part2}";
    }

    private string GenerateRomNum(int x, string l)
    {
        string result;

        switch (x)
        {
            case 0:
                result = "";
                break;
            case 1:
                result = $"{l[0]}";
                break;
            case 2:
                result = $"{l[0]}{l[0]}";
                break;
            case 3:
                result = $"{l[0]}{l[0]}{l[0]}";
                break;
            case 4:
                result = $"{l[0]}{l[1]}";
                break;
            case 5:
                result = $"{l[1]}";
                break;
            case 6:
                result = $"{l[1]}{l[0]}";
                break;
            case 7:
                result = $"{l[1]}{l[0]}{l[0]}";
                break;
            case 8:
                result = $"{l[1]}{l[0]}{l[0]}{l[0]}";
                break;
            case 9:
                result = $"{l[0]}{l[2]}";
                break;
            default:
                result = $"{l[2]}";
                break;
        }

        return result;
    }
}
