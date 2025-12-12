using System.Runtime.CompilerServices;
using Day02;

string input = File.ReadAllText("input.txt");



List<string> myIDList = input.SplitBasedOnSeparator(',');
Dictionary<long, long> invalidIDs = new Dictionary<long, long>();
long sum = 0;

foreach (string ID in myIDList)
{
    List<string> test = ID.SplitBasedOnSeparator('-');


    if (!long.TryParse(test[0], out long startSearchRange) ||
        !long.TryParse(test[1], out long endSearchRange))
    {
        throw new ArgumentException("Invalid range values");
    }




    for (long i = startSearchRange; i <= endSearchRange; i++)
    {
        if (i.IsInvalidId())
            sum += i;
    }






    {
    }


}
Console.WriteLine(sum);














