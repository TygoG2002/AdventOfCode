string[] lines = File.ReadAllLines("input.txt");

int totalSum = 0;

foreach (string line in lines)
{
    int maxForThisLine = 0;

    for (int i = 0; i < line.Length; i++)
    {
        for (int j = i + 1; j < line.Length; j++)
        {
            int firstDigit = int.Parse(line[i].ToString());
            int secondDigit = int.Parse(line[j].ToString());
            int value = firstDigit * 10 + secondDigit;

            maxForThisLine = Math.Max(maxForThisLine, value);
        }
    }

    totalSum += maxForThisLine;
}

Console.WriteLine(totalSum);
