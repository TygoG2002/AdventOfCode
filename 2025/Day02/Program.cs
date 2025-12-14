using Day02;

string input = File.ReadAllText("input.txt").Trim();
long sum = 0;


//TODO finish second part of the puzzle  

foreach (var range in input.SplitBasedOnSeparator(','))
{
    var parts = range.SplitBasedOnSeparator('-');

    long start = long.Parse(parts[0]);
    long end = long.Parse(parts[1]);

    int maxDigits = end.ToString().Length;

    for (int fullDigits = 2; fullDigits <= maxDigits; fullDigits += 2)
    {
        int halfDigits = fullDigits / 2;

        long minHalf = (long)Math.Pow(10, halfDigits - 1);
        long maxHalf = (long)Math.Pow(10, halfDigits) - 1;

        for (long half = minHalf; half <= maxHalf; half++)
        {

          
            long full = long.Parse(half.ToString() + half.ToString());

            if (full < start)
                continue;   

            if (full > end)
                break;

            sum += full;
        }
    }
}

Console.WriteLine(sum);
