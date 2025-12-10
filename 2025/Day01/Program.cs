string[] lines = File.ReadAllLines("input.txt");

int Solve()
{
    int pos = 50;
    int hits = 0;

    foreach (var line in lines)
    {
        char dir = line[0];
        int amount = int.Parse(line[1..]);
        int step = dir == 'R' ? 1 : -1;

        for (int i = 0; i < amount; i++)
        {
            pos = (pos + step + 100) % 100;
            if (pos == 0)
                hits++;
        }
    }

    return hits;
}

Console.WriteLine(Solve());
