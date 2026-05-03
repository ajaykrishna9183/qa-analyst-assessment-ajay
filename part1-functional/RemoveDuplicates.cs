/* This solution contains the Implementation of the Remove Duplicates problem
  using the Brute Force approach and the Optimized approach.*/

// 1. Brute Force Approach:
// The below approach is the brute-force way to remove duplicates from a list. 
// This is not efficient with Time Complexity O(n^2).
using System;
using System.Collections.Generic;

public class RemoveDuplicates
{
    public static List<int> RemoveDuplicatesBruteForce(List<int> input)
    {
        // We are creating a new list to store the final result.
        // This ensures we are NOT modifying the original input (pure function requirement).
        List<int> result = new List<int>();

        // Loop through each element using the Foreach loop
        foreach (int item in input)
        {
            // Assume item is not duplicate
            bool isDuplicate = false;

            /* Now we manually check if the current item is already present
             in the result list by looping through all existing elements.*/
            foreach (int existing in result)
            {
                if (existing == item)
                {
                    isDuplicate = true;
                    // We can stop checking further since we already found a duplicate.
                    break;
                }
            }

            // If after checking all elements, we did NOT find a duplicate,
            // then we add the current item to the result list.
            if (!isDuplicate)
            {
                result.Add(item);
            }
            // If it was duplicate, we simply skip it and move to next element
        }

        // Finally, we return the new list which contains only unique elements
        // while preserving the original order.
        return result;
    }
}
/* 2. Optimized Approach:
 The below approach is the optimized way to remove duplicates from a list using HashSet. 
 This is efficient with Time Complexity O(n).
*/

public class RemoveDuplicatesHashSet
{
    public static List<int> RemoveDuplicatesOptimal(List<int> input)
    {
        // HashSet is used to store elements we have already seen.
        // It provides very fast lookup (O(1)), which helps improve performance.
        HashSet<int> seen = new HashSet<int>();

         // This list will store the final result with unique elements.
        List<int> result = new List<int>();

        // Loop through input list
        foreach (int item in input)
        {
             // Check if the current item is already present in the HashSet.
            // If it is NOT present, it means this is the first time we are seeing it.
            if (!seen.Contains(item))
            {
                seen.Add(item);     // Mark as seen
                result.Add(item);   // Add to result
            }
            // If the item is already in HashSet,
            // it means it's a duplicate, so we skip it.
        }

        // Return the result list which contains unique elements
        // in the same order as they appeared in input.
        return result;
    }
}
