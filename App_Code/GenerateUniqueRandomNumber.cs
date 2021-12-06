using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GenerateUniqueRandomNumber
/// </summary>
public class GenerateUniqueRandomNumber
{
    Random m_random = new Random();

    int m_newRandomNumber = 0;

    List<int> RemainingNumbers;

    // Constructor
    public GenerateUniqueRandomNumber(int requiredRangeLow, int requiredRangeHi)
    {
        // Get the range
        int range = (requiredRangeHi - requiredRangeLow);

        // Initialise array that will hold the numbers within the range
        int[] rangeNumbersArr = new int[range + 1];

        // Assign array element values within range
        for (int count = 0; count < rangeNumbersArr.Length; count++)
        {
            rangeNumbersArr[count] = requiredRangeLow + count;
        }

        // Initialize the List and populate with values from rangeNumbersArr
        RemainingNumbers = new List<int>();
        RemainingNumbers.AddRange(rangeNumbersArr);
    }

    /// <summary>
    /// This method returns a random integer within the given range. Each call produces a new random number
    /// </summary>
    /// <returns></returns>
    public int NewRandomNumber()
    {
        if (RemainingNumbers.Count != 0)
        {
            // Select random number from list
            int index = m_random.Next(0, RemainingNumbers.Count);
            m_newRandomNumber = RemainingNumbers[index];

            // Remove selected number from Remaining Numbers List
            RemainingNumbers.RemoveAt(index);

            return m_newRandomNumber;
        }
        else
        {
            throw new System.InvalidOperationException("All numbers in the range have now been used. Cannot continue selecting random numbers from a list with no members.");
        }
    }
}