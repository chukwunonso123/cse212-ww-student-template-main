using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step-by-step plan:
        // 1. Create an array of type double with size equal to 'length'.
        // 2. Use a loop from 0 to length - 1.
        // 3. For each index i, calculate the value as number * (i + 1).
        // 4. Store that value in the array at index i.
        // 5. After the loop ends, return the filled array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 
    /// then the list after the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step-by-step plan:
        // 1. Get the number of items in the list (data.Count).
        // 2. Use GetRange to get the last 'amount' elements from the list.
        // 3. Use GetRange to get the first (Count - amount) elements.
        // 4. Clear the original list.
        // 5. Add the last part first (rotation).
        // 6. Then add the first part.
        // 7. This modifies the original list in-place.

        int n = data.Count;

        List<int> lastPart = data.GetRange(n - amount, amount);
        List<int> firstPart = data.GetRange(0, n - amount);

        data.Clear();
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}
