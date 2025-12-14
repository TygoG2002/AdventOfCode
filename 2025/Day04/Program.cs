string[] lines = File.ReadAllLines("input.txt");

int totalNumberOfPaperRolls = 0;

for(int i = 0; i < lines.Length; i++){

    string currentLine = lines[i];
    string? previousLine = i > 0 ? lines[i - 1] : null;
    string? nextLine = i < lines.Length - 1 ? lines[i + 1] : null;

    int currentLineIndex = i;

    for (int j = 0; j< currentLine.Length; j++)
    {
        int neighborCount = 0;

        if (currentLine[j] != '@')
            continue;


        int indexOfCurrentValue = j;

        bool left = indexOfCurrentValue != 0 && currentLine[j - 1] == '@';
        bool right = indexOfCurrentValue != (currentLine.Length-1) && currentLine[j + 1] == '@';
        bool top = previousLine != null && previousLine[j] == '@';
        bool bottom = nextLine != null && nextLine[indexOfCurrentValue] == '@';
        bool currentValue = currentLine[j] == '@';

        bool topLeft = previousLine != null && indexOfCurrentValue != 0 && previousLine[j - 1] == '@';
        bool topRight = previousLine != null && indexOfCurrentValue != (currentLine.Length - 1) && previousLine[j + 1] == '@';
        bool bottomLeft = nextLine != null && indexOfCurrentValue != 0 && nextLine[j - 1] == '@';
        bool bottomRight = nextLine != null && indexOfCurrentValue != (currentLine.Length - 1) && nextLine[j + 1] == '@';

        if (left) neighborCount++;
        if (right) neighborCount++;
        if (top) neighborCount++;
        if (bottom) neighborCount++;
        if (topLeft) neighborCount++;
        if (topRight) neighborCount++;
        if (bottomLeft) neighborCount++;
        if (bottomRight) neighborCount++;

        if (neighborCount < 4)
        {
            totalNumberOfPaperRolls++;
        }

    }
}

Console.WriteLine(totalNumberOfPaperRolls);