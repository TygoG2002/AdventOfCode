using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string[] inputLines = File.ReadAllLines("input.txt");

        int totalRowCount = inputLines.Length;
        int totalColumnCount = inputLines[0].Length;

        char[,] paperGrid = new char[totalRowCount, totalColumnCount];

        for (int rowIndex = 0; rowIndex < totalRowCount; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < totalColumnCount; columnIndex++)
            {
                paperGrid[rowIndex, columnIndex] = inputLines[rowIndex][columnIndex];
            }
        }

        int accessibleRollCount = 0;

        for (int rowIndex = 0; rowIndex < totalRowCount; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < totalColumnCount; columnIndex++)
            {
                if (paperGrid[rowIndex, columnIndex] != '@')
                    continue;

                int adjacentRollCount = CountAdjacentPaperRolls(
                    paperGrid,
                    rowIndex,
                    columnIndex,
                    totalRowCount,
                    totalColumnCount
                );

                if (adjacentRollCount < 4)
                    accessibleRollCount++;
            }
        }

        Console.WriteLine($"Part 1: {accessibleRollCount}");

        int totalRemovedRollCount = 0;

        while (true)
        {
            List<(int rowIndex, int columnIndex)> rollsToRemove = new();

            for (int rowIndex = 0; rowIndex < totalRowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < totalColumnCount; columnIndex++)
                {
                    if (paperGrid[rowIndex, columnIndex] != '@')
                        continue;

                    int adjacentRollCount = CountAdjacentPaperRolls(
                        paperGrid,
                        rowIndex,
                        columnIndex,
                        totalRowCount,
                        totalColumnCount
                    );

                    if (adjacentRollCount < 4)
                        rollsToRemove.Add((rowIndex, columnIndex));
                }
            }

            if (rollsToRemove.Count == 0)
                break;

            foreach (var (rowIndex, columnIndex) in rollsToRemove)
            {
                paperGrid[rowIndex, columnIndex] = '.';
                totalRemovedRollCount++;
            }
        }

        Console.WriteLine($"Part 2: {totalRemovedRollCount}");
    }

    static int CountAdjacentPaperRolls(char[,] paperGrid, int centerRowIndex, int centerColumnIndex, int totalRowCount, int totalColumnCount)
    {
        int adjacentPaperRollCount = 0;

        for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
        {
            for (int columnOffset = -1; columnOffset <= 1; columnOffset++)
            {
                if (rowOffset == 0 && columnOffset == 0)
                    continue;

                int neighborRowIndex = centerRowIndex + rowOffset;
                int neighborColumnIndex = centerColumnIndex + columnOffset;

                if (neighborRowIndex >= 0 &&
                    neighborRowIndex < totalRowCount &&
                    neighborColumnIndex >= 0 &&
                    neighborColumnIndex < totalColumnCount)
                {
                    if (paperGrid[neighborRowIndex, neighborColumnIndex] == '@')
                        adjacentPaperRollCount++;
                }
            }
        }

        return adjacentPaperRollCount;
    }
}
