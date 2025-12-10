string[] lines = File.ReadAllLines("input.txt");

int start = 50;

int GetPassword(int start)
{
    int count = 0;

    foreach (string line in lines)
    {
        char direction = line[0];
        int amount = int.Parse(line[1..]);

        if (direction == 'L')
            start -= amount;
        else
            start += amount;

        // stay between 0–99
        start = (start % 100 + 100) % 100;

        if (start == 0)
            count++;
    }

    return count;
}

Console.WriteLine(GetPassword(start));
