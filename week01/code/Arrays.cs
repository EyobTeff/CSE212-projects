using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array of the required length to store the multiples
        double[] result = new double[length];

        // Step 2: Loop through each index from 0 to length - 1
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple of 'number' at this position
            // Multiply the number by (i + 1) because first multiple is number * 1
            result[i] = number * (i + 1);
        }

        // Step 4: Return the array containing all multiples
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Determine the index where the split happens
        // The last 'amount' elements will be moved to the front
        int splitIndex = data.Count - amount;

        // Step 2: Get the two parts of the list
        // Part 1: elements that will move to the front
        List<int> endPart = data.GetRange(splitIndex, amount);

        // Part 2: elements that will follow
        List<int> startPart = data.GetRange(0, splitIndex);

        // Step 3: Clear the original list to prepare for re-insertion
        data.Clear();

        // Step 4: Add the last 'amount' elements to the front
        data.AddRange(endPart);

        // Step 5: Add the remaining elements after the moved elements
        data.AddRange(startPart);

        // Step 6: List is now rotated to the right by 'amount'
    }
}